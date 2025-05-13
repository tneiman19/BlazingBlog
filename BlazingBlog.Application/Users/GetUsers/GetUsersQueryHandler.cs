using BlazingBlog.Domain.Users;

namespace BlazingBlog.Application.Users.GetUsers
{
	class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserResponse>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserService _userService;

		public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
		{
			_userRepository = userRepository;
			_userService = userService;
		}



		public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
		{
			if (!await _userService.IsCurrentUserInRoleAsync("Admin"))
			{
				return Result.Fail<List<UserResponse>>("You're not allowed to see all users.");
			}

			var users = await _userRepository.GetAllUsersAsync();
			var respose = users.Adapt<List<UserResponse>>();

			return respose;


		}
	}
}
