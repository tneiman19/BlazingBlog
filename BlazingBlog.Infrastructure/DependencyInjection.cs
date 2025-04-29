﻿using BlazingBlog.Application.Authentication;
using BlazingBlog.Domain.Articles;
using BlazingBlog.Infrastructure.Authentication;
using BlazingBlog.Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingBlog.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>

				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			AddAuthentication(services);


			services.AddScoped<IArticleRepository, ArticleRepository>();

			return services;
		}

		private static void AddAuthentication(IServiceCollection services)
		{
			services.AddScoped<IAuthenticationService, AuthenticationService>();

			services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

			services.AddCascadingAuthenticationState();

			services.AddAuthorization();
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
				.AddIdentityCookies();

			services.AddIdentityCore<User>()
			   .AddEntityFrameworkStores<ApplicationDbContext>()
			   .AddSignInManager()
			   .AddDefaultTokenProviders();

		}
	}
}
