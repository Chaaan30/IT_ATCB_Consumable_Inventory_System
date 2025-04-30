using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    [Table("SUPPLIERS")]
    public class Supplier
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        [Required]
        public string Name { get; set; }

        [Column("CONTACT_INFO")]
        public string ContactInfo { get; set; }

        // Navigation property
        public ICollection<Item> Items { get; set; }
    }
}   