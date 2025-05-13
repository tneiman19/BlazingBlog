﻿using BlazingBlog.Application.Users;
using BlazingBlog.Domain.Users;

namespace BlazingBlog.Application.Articles.GetArticles
{
	public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, List<ArticleResponse>>
	{
		private readonly IArticleRepository _articleRepository;
		private readonly IUserRepository _userRepository;
		private readonly IUserService _userService;

		public GetArticlesQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository, IUserService userService)
		{
			_articleRepository = articleRepository;
			_userRepository = userRepository;
			_userService = userService;
		}

		public async Task<Result<List<ArticleResponse>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
		{
			var articles = await _articleRepository.GetAllArticlesAsync();
			var response = new List<ArticleResponse>();

			foreach (var article in articles)
			{
				var articleResponse = article.Adapt<ArticleResponse>();
				if (article.UserId is not null)
				{
					var author = await _userRepository.GetUserByIdAsync(article.UserId);
					articleResponse.UserName = author?.UserName ?? "Unknown";
					articleResponse.UserId = article.UserId;
					articleResponse.CanEdit = await _userService.CurrentUserCanEditArticleAsync(article.Id);
				}
				else
				{
					articleResponse.UserName = "Unknown";
				}
				response.Add(articleResponse);
			}

			return response.OrderByDescending(a => a.DatePublished).ToList(); ;
		}
	}
}
