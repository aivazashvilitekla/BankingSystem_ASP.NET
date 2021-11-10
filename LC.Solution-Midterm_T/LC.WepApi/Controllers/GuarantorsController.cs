using LC.BLL.Services;
using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LC.WepApi.Controllers
{
    public class GuarantorsController : ApiController
    {
        // GET: api/Guarantors
        GuarantorManagement guarantor = new GuarantorManagement();
        public IEnumerable<GuarantorDTO> Get() => guarantor.GetAllGuarantor();
        // GET: api/Employees/5
        public GuarantorDTO Get(int id) => guarantor.GetGuarantor(id);

        // POST: api/Employees
        public void Post([FromBody] GuarantorDTO u) => guarantor.AddGuarantor(u);

        // PUT: api/Employees/5
        public void Put(int id, [FromBody] GuarantorDTO u) => guarantor.EditGuarantor(id, u);

        // DELETE: api/Employees/5
        public void Delete(int id) => guarantor.DeleteGuarantor(id);
    }
}
