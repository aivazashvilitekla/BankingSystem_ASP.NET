using LC.BLL.Contracts;
using LC.DAL.EF;
using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.BLL.Services
{
    public class DepositManagement : IDepositManagement
    {
        BSContext db = new BSContext();
        public bool AddDeposit(DepositDTO deposit)
        {
            if (db.Deposit.Any(i => i.ID.Equals(deposit.ID)))
                throw new Exception($"Deposit with ID {deposit.ID} already exists!");

            Deposit udt = new Deposit
            {
                StartingAmount = deposit.StartingAmount,
                CreationDate = deposit.CreationDate,
                Duration = deposit.Duration,
                PersonID = deposit.PersonID
            };
            db.Deposit.Add(udt);
            db.SaveChanges();
            return true;
        }

        public bool DeleteDeposit(int id)
        {
            if (db.Deposit.Any(i => i.ID.Equals(id)))
                throw new Exception($"Deposit with ID {id} not found!");
            var udt = db.Deposit.Where(i => i.ID.Equals(id)).First();
            db.Deposit.Remove(udt);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<DepositDTO> GetAllDeposit()
        {
            return db.Deposit.Select(i => new DepositDTO
            {
                ID = i.ID,
                StartingAmount = i.StartingAmount,
                CreationDate = i.CreationDate,
                Duration = i.Duration,
                PersonID = i.PersonID
            });
        }

        public DepositDTO GetDeposit(int id)
        {
            return db.Deposit.Where(i => i.ID.Equals(id)).Select(i => new DepositDTO
            {
                ID = i.ID,
                StartingAmount = i.StartingAmount,
                CreationDate = i.CreationDate,
                Duration = i.Duration,
                PersonID = i.PersonID
            }).FirstOrDefault();
        }
    }
}
