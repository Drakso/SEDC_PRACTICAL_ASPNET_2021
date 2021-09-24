using PetStore.API.Data;
using PetStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public class PetService : IPetService
	{
		private bool IsNull(Pet pet) => pet == null;

		public bool Add(Pet pet)
		{
			if (IsNull(pet)) return false;

			Db.Pets.Add(pet);
			return true;
		}

		public Pet Get(int id)
		{
			var pet = Db.Pets.FirstOrDefault(x => x.Id == id);

			if (IsNull(pet)) throw new Exception("Id does not exist!");

			return pet;
		}

		public bool ChangeName(int id, string name)
		{
			var pet = Db.Pets.FirstOrDefault(x => x.Id == id);

			if (IsNull(pet)) throw new Exception("Id does not exist!");

			pet.Name = name;
			Db.Pets[Db.Pets.IndexOf(pet)] = pet;

			return true;
		}

		public string Adopt(int id)
		{
			var pet = Db.Pets.FirstOrDefault(x => x.Id == id);
			if (IsNull(pet)) throw new Exception("Id does not exist!");

			var name = pet.Name;

			Db.Pets.Remove(pet);

			return name;
		}
	}
}
