using LC.BLL.Contracts;
using LC.Models.DataViewModels.BankingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LC.DAL.EF;
namespace LC.BLL.Services
{
    public class PersonManagement : IPersonManagement
    {
        BSContext db = new BSContext();
        public bool AddPerson(PersonDTO person)
        {
            if (db.Person.Any(i => i.IDNumber.Equals(person.IDNumber)))
                throw new Exception($"Person with ID Number {person.IDNumber} already exists!");

            Person udt = new Person
            {
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Gender = person.Gender,
                IDNumber = person.IDNumber,
                Birthdate = person.Birthdate,
                CountryID = person.CountryID,
                CityID = person.CityID,
                Phone = person.Phone,
                Email = person.Email,
                GuarantorID = person.GuarantorID
            };
            db.Person.Add(udt);
            db.SaveChanges();
            return true;
        }

        public bool DeletePerson(int id)
        {
            if (!db.Person.Any(i => i.PersonID.Equals(id)))
                throw new Exception($"Person with ID Number {id} not found!");

            var udt = db.Person.Where(i => i.PersonID.Equals(id)).First();
            db.Person.Remove(udt);
            db.SaveChanges();
            return true;
        }

        public bool EditPerson(int id, PersonDTO person)
        {
            if (!db.Person.Any(i => i.PersonID.Equals(id)))
                throw new Exception($"Person with ID Number {id} not found!");

            var udt = db.Person.Where(i => i.PersonID.Equals(id)).First();

            udt.Firstname = person.Firstname;
            udt.Lastname = person.Lastname;
            udt.Gender = person.Gender;
            udt.IDNumber = person.IDNumber;
            udt.Birthdate = person.Birthdate;
            udt.CountryID = person.CountryID;
            udt.CityID = person.CityID;
            udt.Phone = person.Phone;
            udt.Email = person.Email;
            udt.GuarantorID = person.GuarantorID;

            db.SaveChanges();
            return true;
        }

        public IEnumerable<PersonDTO> GetAllPerson()
        {
            return db.Person.Select(i => new PersonDTO
            {
                ID = i.PersonID,
                Firstname = i.Firstname,
                Lastname = i.Lastname,
                Gender = i.Gender,
                IDNumber = i.IDNumber,
                Birthdate = i.Birthdate,
                CountryID = i.CountryID,
                CityID = i.CityID,
                Phone = i.Phone,
                Email = i.Email,
                GuarantorID = i.GuarantorID
            });
        }

        public PersonDTO GetPerson(int id)
        {
            return db.Person.Where(i => i.PersonID.Equals(id)).Select(i => new PersonDTO
            {
                ID = i.PersonID,
                Firstname = i.Firstname,
                Lastname = i.Lastname,
                Gender = i.Gender,
                IDNumber = i.IDNumber,
                Birthdate = i.Birthdate,
                CountryID = i.CountryID,
                CityID = i.CityID,
                Phone = i.Phone,
                Email = i.Email,
                GuarantorID = i.GuarantorID
            }).FirstOrDefault();
        }
    }
}
