using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using firstproject.Models;


namespace firstproject.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<testingtable> tbl = new List<testingtable>();
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.GetAsync("NewApi");
            res.Wait();
            var result = res.Result;
           if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<testingtable>>();
                display.Wait();
                tbl = display.Result;
            }
            return View(tbl);
        }
        [HttpGet]
        public ActionResult createdata()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createdata( testingtable tbl)
        {

            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.PostAsJsonAsync<testingtable>("NewApi", tbl);
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("createdata");
        }

        public ActionResult Details(int id)
        {
            testingtable e = null;
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.GetAsync("NewApi?id="+id.ToString());
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<testingtable>();
                display.Wait();
                e= display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            testingtable e = null;
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.GetAsync("NewApi?id=" + id.ToString());
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<testingtable>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(testingtable tbl)
        {
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.PutAsJsonAsync<testingtable>("NewApi", tbl);
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            testingtable e = null;
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.GetAsync("NewApi?id=" + id.ToString());
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<testingtable>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:57727/api/NewApi");
            var res = client.DeleteAsync("NewApi/"+id.ToString());
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }
    }
}
