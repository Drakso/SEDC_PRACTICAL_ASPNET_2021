﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public interface IAuthenticationService
	{
		string GenerateToken(DateTime dateTime, Guid key);
		bool CheckToken(string token, int daysValid);
	}
}
