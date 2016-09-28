using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Outfit
    {
        public Outfit()
        {
            Accessory = new HashSet<Accessory>();
        }


        [Key]
        public int OutfitID { get; set; }
        public string OutfitName { get; set; }
        public int? TopID { get; set; }
        public int? BottomID { get; set; }
        public int? ShoeID { get; set; }
        public virtual ICollection<Accessory> Accessory { get; set; }

        public virtual Top Top { get; set; }
        public virtual Bottom Bottom { get; set; }
        public virtual Shoe Shoe { get; set; }
    }
}