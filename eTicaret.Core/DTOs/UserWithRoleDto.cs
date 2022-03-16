﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class UserWithRoleDto:UserDto
    {
        public UserRoleDto UserRole { get; set; }
        public List<UserAddressDto> UserAddresses  { get; set; }
    }
}
