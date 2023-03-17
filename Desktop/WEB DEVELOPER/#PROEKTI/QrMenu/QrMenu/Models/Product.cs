using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenu.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = "/";

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; } = "/";

        [Display(Name = "Product Status")]
        public string ProductStatus { get; set; } = "Активен";

        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        //Relationships
        public int CategoryId { get; set; } = 101;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

   

    }



}
