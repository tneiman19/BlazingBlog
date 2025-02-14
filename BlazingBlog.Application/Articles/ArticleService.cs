using BlazingBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlog.Application.Articles
{
	public class ArticleService : IArticleService
	{
		public List<Article> GetAllArticles()
		{
			return new List<Article>            {
				new Article
				{
					Id = 1,
					Title = "First Article",
					Content = "This is the content of the first article.",
					DatePublished = DateTime.Now,
					IsPublished = true
				},
				new Article
				{
					Id = 2,
					Title = "Second Article",
					Content = "This is the content of the second article.",
					DatePublished = DateTime.Now,
					IsPublished = false
				}
			};
		}
	}
}
