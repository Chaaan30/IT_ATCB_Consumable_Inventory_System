using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    [Table("CATEGORIES")]
    public class Category
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        [Required]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        // Navigation property
        public ICollection<Item> Items { get; set; }
    }
}