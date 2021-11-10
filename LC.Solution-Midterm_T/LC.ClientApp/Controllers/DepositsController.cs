using LC.Models.DataViewModels.BankingManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LC.ClientApp.Controllers
{
    public class DepositsController : Controller
    {
        static HttpClient client = new HttpClient();
        string BaseURL = "https://localhost:44315/api/Deposits";
        // GET: Deposits
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(BaseURL).Result;
                List<DepositDTO> ct = new List<DepositDTO>();
                if (response.IsSuccessStatusCode)
                {
                    ct = JsonConvert.DeserializeObject<List<DepositDTO>>(response.Content.ReadAsStringAsync().Result);
                }
                return View(ct);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult();
            }
        }
        

        // GET: Deposits/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deposits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deposits/Create
        [HttpPost]
        public ActionResult Create(DepositDTO deposit)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                string output = JsonConvert.SerializeObject(deposit);
                var stringContent = new StringContent(output, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(BaseURL, stringContent).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "მოხდა შეცდომა ანაბრის დამატების დროს";
                return View();
            }
        }

        // GET: Deposits/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deposits/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deposits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?id=" + id).Result;
            PersonDTO ct = new PersonDTO();
            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<PersonDTO>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // POST: Deposits/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
