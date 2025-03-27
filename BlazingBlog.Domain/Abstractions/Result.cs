﻿namespace BlazingBlog.Domain.Abstractions
{
    public class Result
    {
		public bool Success { get; }

		public bool Failure => !Success;

		public string? Error { get;  }

		protected Result(bool success, string? errorMessage = null)
		{
			Success = success;
			Error = errorMessage;
		}

		public static Result Ok() => new(true);

		public static Result Fail(string errorMessage) => new(false, errorMessage);
	}
}
