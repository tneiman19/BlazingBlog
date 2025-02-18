using BlazingBlog.Domain.Articles;


namespace BlazingBlog.Application.Articles
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticlesAsync();
	}
}
