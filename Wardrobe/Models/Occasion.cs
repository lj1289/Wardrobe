using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Occasion
    {
        [Key]
        public int OccasionID { get; set; }
        public string OccasionName { get; set; }
    }
}