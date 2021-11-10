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
    public class LoansController : ApiController
    {
        LoanManagement loan = new LoanManagement();

        public IEnumerable<LoanDTO> Get() => loan.GetAllDeposit();

        // GET: api/Courses/5
        public LoanDTO Get(int id) => loan.GetDeposit(id);
        // POST: api/Employees
        public void Post([FromBody] LoanDTO u) => loan.AddLoan(u);

        // DELETE: api/Employees/5
        public void Delete(int id) => loan.DeleteLoan(id);
    }
}
