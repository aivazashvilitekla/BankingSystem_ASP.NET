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
    public class DepositsController : ApiController
    {
        // GET: api/Deposits
        DepositManagement deposit = new DepositManagement();
        // GET: api/Courses
        public IEnumerable<DepositDTO> Get() => deposit.GetAllDeposit();

        // GET: api/Courses/5
        public DepositDTO Get(int id) => deposit.GetDeposit(id);

        // POST: api/Courses
        public void Post([FromBody] DepositDTO c) => deposit.AddDeposit(c);
        // PUT: api/Courses/5
        //public void Put(int id, [FromBody] DepositDTO c) => deposit.EditPerson(id, c);

        // DELETE: api/Courses/5
        public void Delete(int id) => deposit.DeleteDeposit(id);
    }
}
