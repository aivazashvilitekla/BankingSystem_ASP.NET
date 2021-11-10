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
    public class GuarantorManagement : IGuarantorManagement
    {
        BSContext db = new BSContext();
        public bool AddGuarantor(GuarantorDTO guarantor)
        {
            if (db.Guarantor.Any(i => i.ID.Equals(guarantor.ID)))
                throw new Exception($"Guarantor with ID {guarantor.ID} already exists!");

            Guarantor udt = new Guarantor
            {
                Firstname = guarantor.Firstname,
                Lastname = guarantor.Lastname,
                Phone = guarantor.Phone,
                Relation = guarantor.Relation
            };
            db.Guarantor.Add(udt);
            db.SaveChanges();
            return true;
        }

        public bool DeleteGuarantor(int id)
        {
            if (db.Guarantor.Any(i => i.ID.Equals(id)))
                throw new Exception($"Guarantor with ID {id} already exists!");

            var udt = db.Person.Where(i => i.IDNumber.Equals(id)).First();
            db.Person.Remove(udt);
            db.SaveChanges();
            return true;
        }

        public bool EditGuarantor(int id, GuarantorDTO guarantor)
        {
            if (db.Guarantor.Any(i => i.ID.Equals(guarantor.ID)))
                throw new Exception($"Guarantor with ID {guarantor.ID} already exists!");

            var udt = db.Guarantor.Where(i => i.ID.Equals(id)).First();

            udt.Firstname = guarantor.Firstname;
            udt.Lastname = guarantor.Lastname;
            udt.Phone = guarantor.Phone;
            udt.Relation = guarantor.Relation;

            db.SaveChanges();
            return true;
        }

        public IEnumerable<GuarantorDTO> GetAllGuarantor()
        {
            return db.Guarantor.Select(i => new GuarantorDTO
            {
                ID = i.ID,
                Firstname = i.Firstname,
                Lastname = i.Lastname,
                Phone = i.Phone,
                Relation = i.Relation
            });
        }

        public GuarantorDTO GetGuarantor(int id)
        {
            return db.Guarantor.Where(i => i.ID.Equals(id)).Select(i => new GuarantorDTO
            {
                ID = i.ID,
                Firstname = i.Firstname,
                Lastname = i.Lastname,
                Phone = i.Phone,
                Relation = i.Relation
            }).FirstOrDefault();
        }

    }
}
