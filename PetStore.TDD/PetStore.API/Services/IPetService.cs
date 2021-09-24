using PetStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public interface IPetService
	{
		bool Add(Pet pet);
		Pet Get(int id);
		bool ChangeName(int id, string name);
		string Adopt(int id);
	}
}
