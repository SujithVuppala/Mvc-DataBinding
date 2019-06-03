using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDataBinding.Models;
using System.Net;


namespace MvcDataBinding.Controllers
{
    public class ProductsController : Controller
    {
        ProductsContext db = new ProductsContext();
        public ViewResult Index()
        {
            return View(db.ProductTable.ToList());
        }
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id is required");

            }
            Product product = db.ProductTable.Find(id);
            if(product==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmCollection)

        {
            Product product = new Product();
            product.Name = frmCollection["Name"];
            product.Price = Convert.ToDecimal(frmCollection["Price"]);

            db.ProductTable.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id is required");

            }
            Product product = db.ProductTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);

        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Product product = db.ProductTable.Find(id);
            UpdateModel(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id is required");

            }
            Product product = db.ProductTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        [HttpPost]
        
         public ActionResult Delete(int id)
        {

            Product product = db.ProductTable.Find(id);
            db.ProductTable.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        
    }



    }
}