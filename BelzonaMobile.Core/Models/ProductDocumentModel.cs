using System;
namespace BelzonaMobile.Core.Models
{
    public class ProductDocumentModel
    {
        public int ProductDocumentId { get; set; }
        public int ProductId { get; set; }
        public int LanguageId { get; set; }
        public string DocumentUrl { get; set; }
        public int DocumentTypeId { get; set; }
		public ProductDocumentTypeModel ProductDocumentType { get; set; }
        public override string ToString()
        {
            return ProductDocumentType?.Name;
        }
    }
    
    public enum DocumentTypeEnum
    {

        ChemicalResistance, //1
        ProductSpecificationSheet,//2
        InstructionsForUse,//3
        SDSBase,//4
        SDSSolidifier,//5
        SDSHGSBase,//6
        SDSGHSSolidifier,//7
        ProductFlyer//8
    }
}
