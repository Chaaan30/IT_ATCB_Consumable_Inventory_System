using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    [Table("Z_ITCIMS_ITEMS")]
    public class Item
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }

        [Column("SUPPLIER_ID")]
        public int? SupplierId { get; set; }

        [Column("MODEL_NAME")]
        public string ModelName { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("CURRENT_QUANTITY")]
        public int CurrentQuantity { get; set; }

        [Column("UNIT_OF_MEASURE")]
        public string UnitOfMeasure { get; set; }

        [Column("CRITICAL_LEVEL")]
        public int CriticalLevel { get; set; }

        [Column("REORDER_QUANTITY")]
        public int? ReorderQuantity { get; set; }

        [Column("LAST_UPDATED")]
        public DateTime LastUpdated { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}