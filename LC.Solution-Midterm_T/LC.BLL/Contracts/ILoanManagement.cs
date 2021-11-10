using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.BLL.Contracts
{
    public interface ILoanManagement
    {
        IEnumerable<LoanDTO> GetAllDeposit();
        LoanDTO GetDeposit(int id);
        bool AddLoan(LoanDTO loan);
        bool DeleteLoan(int id);
    }
}
