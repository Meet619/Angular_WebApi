using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Models
{
    public class TrainingPlan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string TrainingTopic { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string TrainingLocation { get; set; }
    }
}
