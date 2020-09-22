using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class DisplayDatabaseLogModel
    {
        public int DatabaseLogID { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Database user is too short")]
        [MaxLength(10,ErrorMessage ="Database user is too long")]
        public string DatabaseUser { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Database user is too long")]
        public string Event { get; set; }
        [MaxLength(100, ErrorMessage = "Database user is too long")]
        public string Schema { get; set; }
        public string PostTime { get; set; }
    }
}
