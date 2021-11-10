using LC.Models.DataViewModels.BankingManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LC.ClientApp.Controllers
{
    public class LoansController : Controller
    {
        // GET: Loans
        static HttpClient client = new HttpClient();
        string BaseURL = "https://localhost:44315/api/Loans";
        // GET: Person
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(BaseURL).Result;
                List<LoanDTO> ct = new List<LoanDTO>();
                if (response.IsSuccessStatusCode)
                {
                    ct = JsonConvert.DeserializeObject<List<LoanDTO>>(response.Content.ReadAsStringAsync().Result);
                }
                return View(ct);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult();
            }
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?id=" + id).Result;
            LoanDTO ct = new LoanDTO();
            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<LoanDTO>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // GET: Person/Create
        public ActionResult Create(LoanDTO loan)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                string output = JsonConvert.SerializeObject(loan);
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
                ViewBag.ErrorMessage = "მოხდა შეცდომა სესხის დამატების დროს";
                return View();
            }
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?id=" + id).Result;

            LoanDTO ct;

            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<LoanDTO>(response.Content.ReadAsStringAsync().Result);
                return View(ct);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID, Amount, CreationDate, Duration, PersonID, GuarantorID")] LoanDTO loan)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                string output = JsonConvert.SerializeObject(loan);
                var stringContent = new StringContent(output, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(BaseURL + "?id=" + id, stringContent).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?id=" + id).Result;
            LoanDTO ct = new LoanDTO();
            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<LoanDTO>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(BaseURL + "?id=" + id).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
