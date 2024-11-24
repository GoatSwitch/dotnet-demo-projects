﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eShopLegacyMVC.Models
{
    public class CatalogItem
    {
        public const string DefaultPictureName = "dummy.png";

        public CatalogItem()
        {
            PictureFileName = DefaultPictureName;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "The field Price must be a positive number with maximum two decimals.")]
        [Range(0, 1000000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Picture name")]
        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        [Display(Name = "Type")]
        public int CatalogTypeId { get; set; }

        [Display(Name = "Type")]
        public CatalogType CatalogType { get; set; }

        [Display(Name = "Brand")]
        public int CatalogBrandId { get; set; }

        [Display(Name = "Brand")]
        public CatalogBrand CatalogBrand { get; set; }

        // Quantity in stock
        [Display(Name = "Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "The stock cannot be negative")]
        public int AvailableStock { get; set; }

        // Available stock at which we should reorder
        [Display(Name = "Restock")]
        [Range(0, int.MaxValue, ErrorMessage = "The restock threshold cannot be negative")]
        public int RestockThreshold { get; set; }

        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        [Display(Name = "Max stock")]
        [Range(0, int.MaxValue, ErrorMessage = "The maximum stock threshold cannot be negative")]
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// </summary>
        public bool OnReorder { get; set; }
    }
}