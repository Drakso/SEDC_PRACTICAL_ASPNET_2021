using Application.Configurations;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Options;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class UserService : IUserService
	{
		private readonly AppSettings _options;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public UserService(IOptions<AppSettings> options, IMapper mapper, IUserRepository userRepository)
		{
			_options = options.Value;
			_mapper = mapper; // This is where we get the mapper from the DI container so we can use it in this class
			_userRepository = userRepository;
		}

		public User LogIn(UserDTO user)
		{
			return _userRepository.GetByLoginInfo(user.Username, user.Password);
		}

		public User Register(UserDTO user)
		{
			var entity = _mapper.Map<User>(user);
			_userRepository.Insert(entity);
			return LogIn(user);
		}


		public void DoSomethingWithSecretExample()
		{
			// Use some secret from configuration
			var x = _options.Secret;
		}
	}
}
