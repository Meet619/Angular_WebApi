using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Models
{
    public class AuthLogin
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
