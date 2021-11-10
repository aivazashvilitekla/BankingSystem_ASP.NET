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
    public class LoanManagement : ILoanManagement
    {
        BSContext db = new BSContext();
        public bool AddLoan(LoanDTO loan)
        {
            if (db.Loan.Any(i => i.ID.Equals(loan.ID)))
                throw new Exception($"Loan with ID {loan.ID} already exists!");

            Loan udt = new Loan
            {
                Amount = loan.Amount,
                CreationDate = loan.CreationDate,
                Duration = loan.Duration,
                PersonID = loan.PersonID,
                GuarantorID = loan.GuarantorID,
            };
            db.Loan.Add(udt);
            db.SaveChanges();
            return true;
        }

        public bool DeleteLoan(int id)
        {
            if (db.Loan.Any(i => i.ID.Equals(id)))
                throw new Exception($"Loan with ID {id} not found!");
            var udt = db.Loan.Where(i => i.ID.Equals(id)).First();
            db.Loan.Remove(udt);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<LoanDTO> GetAllDeposit()
        {
            return db.Loan.Select(i => new LoanDTO
            {
                ID = i.ID,
                Amount = i.Amount,
                CreationDate = i.CreationDate,
                Duration = i.Duration,
                PersonID = i.PersonID,
                GuarantorID = i.GuarantorID
            });
        }

        public LoanDTO GetDeposit(int id)
        {
            return db.Loan.Where(i => i.ID.Equals(id)).Select(i => new LoanDTO
            {
                ID = i.ID,
                Amount = i.Amount,
                CreationDate = i.CreationDate,
                Duration = i.Duration,
                PersonID = i.PersonID,
                GuarantorID = i.GuarantorID
            }).FirstOrDefault();
        }
    }
}
