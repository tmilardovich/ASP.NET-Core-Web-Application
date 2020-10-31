using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace news.Models.AuthModel
{
    public class LoginData
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        
    }
}
