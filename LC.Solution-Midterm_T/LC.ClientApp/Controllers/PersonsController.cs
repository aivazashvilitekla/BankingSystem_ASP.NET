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
    public class PersonsController : Controller
    {
        static HttpClient client = new HttpClient();
        string BaseURL = "https://localhost:44315/api/Persons";
        // GET: Persons
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(BaseURL).Result;
                List<PersonDTO> ct = new List<PersonDTO>();
                if (response.IsSuccessStatusCode)
                {
                    ct = JsonConvert.DeserializeObject<List<PersonDTO>>(response.Content.ReadAsStringAsync().Result);
                }
                return View(ct);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult();
            }
        }

        // GET: Persons/Details/5
        public ActionResult Details(int id)
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

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        public ActionResult Create(PersonDTO person)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                string output = JsonConvert.SerializeObject(person);
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
                ViewBag.ErrorMessage = "მოხდა შეცდომა  დამატების დროს";
                return View();
            }
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?id=" + id).Result;

            PersonDTO ct;

            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<PersonDTO>(response.Content.ReadAsStringAsync().Result);
                return View(ct);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Persons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Firstname, Lastname, Gender, IDNumber, Birthdate, CountryID, CityID, Phone, Email, GuarantorID")] PersonDTO person)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                string output = JsonConvert.SerializeObject(person);
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

        // GET: Persons/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Persons/Delete/5
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
