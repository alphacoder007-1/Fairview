using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Products")]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        public decimal Unitprice { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        //navigation property
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

}
