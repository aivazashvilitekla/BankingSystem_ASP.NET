using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Models.DataViewModels.BankingManagement
{
    public class PersonDTO
    {
        public int ID { get; set; }
        [Display(Name = "სახელი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "სახელის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "სახელი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Firstname { get; set; }
        [Display(Name = "გვარი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "გვარის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "გვარი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Lastname { get; set; }
        [Display(Name = "სქესი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "სქესის მითითება სავალდებულოა")]
        public string Gender { get; set; }
        [Display(Name = "პირადი ნომერი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "პირადი ნომრის მითითება სავალდებულოა"), MaxLength(11, ErrorMessage = "პირადი ნომერი არ უნდა აღემატებოდეს 11 სიმბოლოს")]
        public string IDNumber { get; set; }
        [Display(Name = "დაბადების თარიღი")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "დაბადების თარიღის მითითება სავალდებულოა")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "ქვეყანა")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ქვეყნის მითითება სავალდებულოა")]
        public int CountryID { get; set; }
        [Display(Name = "ქალაქი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ქალაქის მითითება სავალდებულოა")]
        public int CityID { get; set; }
        [Display(Name = "ტელეფონის ნომერი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ტელეფონის ნომრის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "ტელეფონის ნომერი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Phone { get; set; }
        [Display(Name = "ელ-ფოსტა")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "ელ-ფოსტის მითითება სავალდებულოა")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "შეყვანილი ელ-ფოსტია არავალიდურია")]
        public string Email { get; set; }
        [Display(Name = "თავმდები")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "თავმდების მითითება სავალდებულოა")]
        public int GuarantorID { get; set; }
    }
}
