using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barfootPractice.Models
{
    public class ListingConfidentialViewDto:ListingViewDto
    {
        public string ConfidentialNote { get; set; }
    }
}
