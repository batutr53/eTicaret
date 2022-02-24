using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string TelNumber { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public int UserRoleId { get; set; }
    }
}
