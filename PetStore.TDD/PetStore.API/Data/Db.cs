using PetStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Data
{
	#region Why is this static? How is static different from regular class?
	// We are simulating a database with a static class
	// This is not a replacement for a real database in a real world scenario
	// This is only for the class and for this simple example application

	// var db = new Db();
	// Memory
	// [] [] [] [] [] [] []
	// Normal class
	// [instance] [instance] [] [] [] [instance]
	// var user = new User();
	// 1. variable user
	// 2. in the heap memory it writes the user
	// 3. it remembers the address of that memory piece
	// 4. it returns the address to the varaible
	// Get(user)
	// 1. We look at the address in user variable
	// 2. We go to that address
	// 3. We take the user from the Heap memory
	// 4. We return the user
	// Ex:
	// var user1 = new User(); // in user1 there is an address
	// var user2 = user1; // in user2 we write the user1 address
	// user1 and user2 will both point to the same memory spot that we created when user1 was created
	// 
	// Static class
	// [automatic instance] [] [] [] [] [] []
	#endregion
	public static class Db
	{
		public static List<Pet> Pets { get; set; }
		public static List<User> Users { get; set; }

		static Db()
		{
			Pets = new List<Pet>();
			Users = new List<User>();

		}
	}
}
