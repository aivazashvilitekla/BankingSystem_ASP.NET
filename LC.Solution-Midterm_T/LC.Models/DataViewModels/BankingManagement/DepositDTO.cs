using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Models.DataViewModels.BankingManagement
{
    public class DepositDTO
    {
        public int ID { get; set; }
        [Display(Name = "საწყისი თანხა")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "საწყისი თანხის მითითება სავალდებულოა")]
        public int StartingAmount { get; set; }
        [Display(Name = "თარიღი")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "თარიღის მითითება სავალდებულოა")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "ხანგრძლივობა")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ხანგრძლივობის მითითება სავალდებულოა")]
        public int Duration { get; set; }
        [Display(Name = "ფიზიკური პირი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ფიზიკური პირის მითითება სავალდებულოა")]
        public int PersonID { get; set; }
    }
}
