using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int? ColorID { get; set; }
        public int? SeasonID { get; set; }
        public int? OccasionID { get; set; }

        public virtual Color Color { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

        public virtual ICollection<Outfit> Outfit { get; set; }
    }
}