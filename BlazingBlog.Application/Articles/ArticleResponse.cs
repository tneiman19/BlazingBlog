﻿namespace BlazingBlog.Application.Articles
{
	public record struct ArticleResponse(
		 int Id,
		 string Title,
		 string? Content,
		 DateTime DatePublished,
		 bool IsPublished
		)
	{
	}
}
