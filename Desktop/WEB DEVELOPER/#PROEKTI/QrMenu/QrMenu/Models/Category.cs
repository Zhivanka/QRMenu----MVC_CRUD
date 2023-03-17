

using System.ComponentModel.DataAnnotations;

namespace QrMenu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name:")]
        public string CategoryName { get; set; } = "Name";

        [Display(Name = "Category Type:")]
        public string CategoryType { get; set; } = "Type";

        [Display(Name = "Category Status:")]
        public string CategoryStatus { get; set; } = "Status";

       //relationships
        public List<Product> Products { get; set; }


    }

   
}
