using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Imp.Admin.Models.Doc;
using Imp.Admin.Models.Users;
using Imp.Core.Domain.Files;
using Imp.Core.Domain.Users;

namespace Imp.Admin.Infrastructure
{
    public class AutoMapperStartup
    {
        public static void Execute()
        {
            // role
            Mapper.CreateMap<Role, RoleModel>();

            // user
            Mapper.CreateMap<User, UserModel>();

            // directory
           
        }
    }
}