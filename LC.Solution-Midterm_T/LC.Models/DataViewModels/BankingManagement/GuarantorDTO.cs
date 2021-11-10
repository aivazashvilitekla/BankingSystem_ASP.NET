using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Models.DataViewModels.BankingManagement
{
    public class GuarantorDTO
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
        [Display(Name = "ტელეფონის ნომერი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ტელეფონის ნომრის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "ტელეფონის ნომერი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Phone { get; set; }


        [Display(Name = "კავშირი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "კავშირის მითითება სავალდებულოა")]
        public string Relation { get; set; }
    }
}
