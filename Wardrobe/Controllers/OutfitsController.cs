using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe.Models;
using Wardrobe.ViewModel;

namespace Wardrobe.Controllers
{
    public class OutfitsController : Controller
    {
        private WardrobeContext db = new WardrobeContext();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create(int? id)
        {
            Outfit outfit = new Outfit();

            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", outfit.TopID);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Value = a.AccessoryID.ToString(),
                                     Text = a.Name
                                 }
            };

            return View(outfitViewModel);
        }

        //public ActionResult Create()
        //{
        //    ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name");
        //    ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name");
        //    ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name");
        //    ViewBag.Accessories = new SelectList(db.Accessories, "Accessories", "Name");

        //    return View();
        //}

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,TopID,BottomID,ShoeID")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                foreach (int accessoryID in SelectedAccessories)
                {
                    outfit.Accessory.Add(db.Accessories.Find(accessoryID));
                }

                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", outfit.TopID);
            //ViewBag.Accessory = new SelectList(db.Accessories, "Accessories", "Name", outfit.Accessory)

            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", outfit.TopID);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Value = a.AccessoryID.ToString(),
                                     Text = a.Name
                                  }
            };

            return View(outfitViewModel);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,TopID,BottomID,ShoeID")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                //Variable equal to the current outfit
                var existingOutfit = db.Outfits.Find(outfit.OutfitID);

                //Changes existing properties to new properties
                existingOutfit.TopID = outfit.TopID;
                existingOutfit.BottomID = outfit.BottomID;
                existingOutfit.ShoeID = outfit.ShoeID;
                existingOutfit.Accessory.Clear();

                foreach (int accessoryID in SelectedAccessories)
                {
                    //Find the accessory by its ID and add it to its existing outfit
                    existingOutfit.Accessory.Add(db.Accessories.Find(accessoryID));
                }

                //The below line takes the outfit from the user
                //and saves it directly to the database.
                //We need to attach accessories first.
                //db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
