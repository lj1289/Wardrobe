using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wardrobe.Models;

namespace Wardrobe.ViewModel
{
    public class OutfitViewModel
    {
        public Outfit Outfit { get; set; }
        public IEnumerable<SelectListItem> AllAccessories { get; set; }

        public List<int>_selectedAccessories;
        public List<int> SelectedAccessories
        {
            get
            {
                if (_selectedAccessories == null)
                {
                    _selectedAccessories = (from a in Outfit.Accessory
                                            select a.AccessoryID).ToList();
                }

                return _selectedAccessories;
            }
            
            set { _selectedAccessories = value; }
            
        }
    }
}