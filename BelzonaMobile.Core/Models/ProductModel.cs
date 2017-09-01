using System;
using System.Collections.Generic;

namespace BelzonaMobile.Core.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
		public string ShortDescription { get; set; }
        public int LanguageId { get; set; }
        public int SeriesId { get; set; }
        public int IsActive { get; set; }
        public string Thumbnail { get; set; }
        public List<ProductDocumentModel> Documents { get; set; }
        public ProductDetailModel ProductDetail { get; set; }
        public List<ProductVideoModel> Videos { get; set; }
        public override string ToString()
        {
            return Name.ToUpper();
        }
    }
    
    
    
}
