using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
	// MAPPING
	// 1. Manual mapping
	// 2. Mapping with external library ( Automapper in our case )

	// Mapping with Automapper
	// Class for mapping configurations MUST extend Profile class ( From Automapper )
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// IF we don't tell automapper specifically what to map, he will try to map properties by name ( same name match )
			CreateMap<Reminder, ReminderDTO>()
				.ReverseMap() // This creates a map for the reverese situation as well
				.IgnoreAllPropertiesWithAnInaccessibleSetter() // Ignores empty properties or no properties on destination
				.IgnoreAllSourcePropertiesWithAnInaccessibleSetter(); // Ignores empty properties or no properties on source

			CreateMap<User, UserDTO>()
				.ReverseMap()
				.IgnoreAllPropertiesWithAnInaccessibleSetter() 
				.IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

			// We can configure every map direction separately
			//CreateMap<ReminderDTO, Reminder>();
		}
	}

	// Manual mapping example
	// Mapping in it's core is just changing the data from one class to another
	public class ManualMappingExample
	{
		public UserDTO MapUserToUserDTO(User user)
		{
			var mapped = new UserDTO()
			{
				Username = user.Username,
				Password = user.Password,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Id = user.Id
			};
			return mapped;
		}
	}
}
