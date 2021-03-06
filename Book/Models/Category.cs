using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Category
    {  
        [Key]
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("DisplayOrder")]
        [Range(1,100,ErrorMessage ="Display orger most be between 1 and 100!")]
        public int DisplayOrder { get; set; }
        public DateTime dateTime { get; set; }  =   DateTime.Now;



    }
}
