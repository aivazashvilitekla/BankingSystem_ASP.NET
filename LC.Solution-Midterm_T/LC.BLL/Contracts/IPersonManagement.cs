using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.BLL.Contracts
{
    public interface IPersonManagement
    {
        bool AddPerson(PersonDTO person);
        bool EditPerson(int id, PersonDTO person);
        bool DeletePerson(int id);
        IEnumerable<PersonDTO> GetAllPerson();
        PersonDTO GetPerson(int id);
    }
}
