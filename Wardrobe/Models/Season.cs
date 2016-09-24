using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Season
    {
        [Key]
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
    }
}