using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barfootPractice.Models.Dtos
{
    public class ListingUpdateDto
    {
        public int ListingId { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        //TODO: Create status entity for listing
        public string Status { get; set; }
        public string ConfidentialNote { get; set; }
        public DateTime Created { get; set; }
    }
}
