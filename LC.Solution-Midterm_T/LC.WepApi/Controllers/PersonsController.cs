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
    public class PersonsController : ApiController
    {
        // GET: api/Persons
        PersonManagement person = new PersonManagement();
        // GET: api/Courses
        public IEnumerable<PersonDTO> Get() => person.GetAllPerson();

        // GET: api/Courses/5
        public PersonDTO Get(int id) => person.GetPerson(id);

        // POST: api/Courses
        public void Post([FromBody] PersonDTO c) => person.AddPerson(c);
        // PUT: api/Courses/5
        public void Put(int id, [FromBody] PersonDTO c) => person.EditPerson(id, c);

        // DELETE: api/Courses/5
        public void Delete(int id) => person.DeletePerson(id);
    }
}
