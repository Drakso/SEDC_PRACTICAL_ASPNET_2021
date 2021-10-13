using Application;
using Application.Utilities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Configurations
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<RegisterViewModel, UserDTO>()
				.ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
				.ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
				.ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
				.ForMember(dest => dest.FirstName, x => x.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, x => x.MapFrom(src => src.LastName))
				.ReverseMap()
				.ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
				.ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
				.ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
				.ForMember(dest => dest.FirstName, x => x.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, x => x.MapFrom(src => src.LastName))
				.ForMember(dest => dest.ConfirmPassword, x => x.Ignore());

			CreateMap<LoginViewModel, UserDTO>()
				.ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
				.ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
				.ForMember(dest => dest.Email, x => x.Ignore())
				.ForMember(dest => dest.FirstName, x => x.Ignore())
				.ForMember(dest => dest.LastName, x => x.Ignore())
				.ReverseMap()
				.ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
				.ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password));

			CreateMap<ReminderDTO, ReminderViewModel>()
				.ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
				.ForMember(dest => dest.Title, x => x.MapFrom(src => src.Title))
				.ForMember(dest => dest.Description, x => x.MapFrom(src => src.Description))
				.ForMember(dest => dest.DateTime, x => x.MapFrom(src => src.DateTime))
				.ForMember(dest => dest.Priority, x => x.MapFrom(src => src.Priority))
				.ForMember(dest => dest.PriorityName, x => x.MapFrom(src => src.Priority.GetName()))
				.ForMember(dest => dest.Color, x => x.MapFrom(src => src.Priority.GetColor()))
				.ReverseMap()
				.ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
				.ForMember(dest => dest.Title, x => x.MapFrom(src => src.Title))
				.ForMember(dest => dest.Description, x => x.MapFrom(src => src.Description))
				.ForMember(dest => dest.Priority, x => x.MapFrom(src => src.Priority))
				.ForMember(dest => dest.DateTime, x => x.MapFrom(src => DateTime.Parse(src.DateTime)))
				.ForMember(dest => dest.Id, x => x.Ignore())
				.ForMember(dest => dest.UserId, x => x.Ignore());
		}
	}
}
