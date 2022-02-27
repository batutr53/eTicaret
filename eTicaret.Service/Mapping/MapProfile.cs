﻿using AutoMapper;
using eTicaret.Core;
using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Service.Services.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductFeature, ProductWithFeatureDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();

            CreateMap<User, UserWithRoleDto>().ReverseMap();
           
            CreateMap<Product,ProductCommentDto>().ReverseMap();
            CreateMap<ProductComment, ProductCommentDto>().ReverseMap();
       
            CreateMap<Product,CommentImageDto>().ReverseMap();
            CreateMap<CommentImage, CommentImageDto>().ReverseMap();
          
            CreateMap<Product, ProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<ProductUpdateDto,Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();


        }
    }
}
