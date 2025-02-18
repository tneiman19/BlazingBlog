﻿using BlazingBlog.Domain.Articles;

namespace BlazingBlog.Application.Articles
{
	public class ArticleService : IArticleService
	{
		private readonly IArticleRepository _articleRepository;

		public ArticleService(IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public async Task<List<Article>> GetAllArticlesAsync()
		{
			return await _articleRepository.GetAllArticlesAsync();
		}
	}
}
