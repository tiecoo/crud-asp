using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTestGit.Models;
using System.Net;

namespace MvcTestGit.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> listaDeProdutos = new List<Product>
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public ActionResult Index()
        {
            return View(listaDeProdutos);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = listaDeProdutos.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product produto)
        {
            try
            {
                listaDeProdutos.Add(produto);
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO: Redirect to a error page
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = listaDeProdutos.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product produto)
        {
            try
            {
                Product product = listaDeProdutos.Find(x => x.Id == produto.Id);
                product.Name = produto.Name;
                product.Category = produto.Category;
                product.Price = produto.Price;
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO: Redirect to a error page
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = listaDeProdutos.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = listaDeProdutos.Find(x => x.Id == id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                listaDeProdutos.Remove(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
