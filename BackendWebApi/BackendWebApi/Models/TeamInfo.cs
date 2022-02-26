using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Models
{
    public class TeamInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string MemberName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
    }
}
