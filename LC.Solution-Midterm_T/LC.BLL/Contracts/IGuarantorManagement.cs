using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.BLL.Contracts
{
    public interface IGuarantorManagement
    {
        IEnumerable<GuarantorDTO> GetAllGuarantor();
        bool AddGuarantor(GuarantorDTO guarantor);
        bool EditGuarantor(int id, GuarantorDTO guarantor);
        bool DeleteGuarantor(int id);
        GuarantorDTO GetGuarantor(int id);
    }
}
