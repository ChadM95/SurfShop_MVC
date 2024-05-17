using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurfShop_MVC.Models;

namespace SurfShop_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private SurfShopDBEntitiesConString db = new SurfShopDBEntitiesConString();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        //VIEW ONLY products
        public ActionResult ViewOnly()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Product_Name,Product_Description,Price")] Product product, HttpPostedFileBase productImagePicker)
        {
            if (ModelState.IsValid)
            {
                if (productImagePicker != null)
                {
                    //create new array of bytes
                    product.Image = new byte[productImagePicker.ContentLength];

                    //populate the array with the image
                    productImagePicker.InputStream.Read(product.Image, 0, productImagePicker.ContentLength);
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Product_Name,Product_Description,Price")] Product product, HttpPostedFileBase productImagePicker)
        {
            if (ModelState.IsValid)
            {
                if (productImagePicker != null)
                {
                    //create new array of bytes
                    product.Image = new byte[productImagePicker.ContentLength];

                    //populate the array with the image
                    productImagePicker.InputStream.Read(product.Image, 0, productImagePicker.ContentLength);
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
