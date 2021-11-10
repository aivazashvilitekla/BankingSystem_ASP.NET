using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.BLL.Contracts
{
    public interface IDepositManagement
    {
        IEnumerable<DepositDTO> GetAllDeposit();
        DepositDTO GetDeposit(int id);
        bool AddDeposit(DepositDTO deposit);
        bool DeleteDeposit(int id);
    }
}
