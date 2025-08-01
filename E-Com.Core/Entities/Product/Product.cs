﻿using System.ComponentModel.DataAnnotations.Schema;

namespace E_Com.Core.Entities.Product
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(name: nameof(CategoryId))]
        public virtual Category Category { get; set; }

    }
}
