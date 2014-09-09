using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Imp.Admin.Models.Users;
using Imp.Core.Domain.Users;

namespace Imp.Admin
{
    public static class MappingExtensions
    {
        public static RoleModel ToModel(this Role role)
        {
            return Mapper.Map<Role, RoleModel>(role);
        }
    }
}