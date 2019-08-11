using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace barfootPractice.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Status { get; set; }
        public string ConfidentialNote { get; set; }
        public int StaffId { get; set; }
    }
}
