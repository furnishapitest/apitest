using AutoMapper;
using EuroFurnish.ApplicationCore.DtoModels.Category;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Mappers
{
    public class AppDtoMapper : Profile
    {
        public AppDtoMapper()
        {
            CategoryModelMapping();
            UserModelMapping();

        }

        private void CategoryModelMapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }

        private void UserModelMapping()
        {
            CreateMap<AppUser, UserRegisterDto>();
            CreateMap<UserRegisterDto, AppUser>();
        }
    }
}
