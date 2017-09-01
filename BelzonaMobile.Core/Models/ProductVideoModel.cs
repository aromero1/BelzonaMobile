using System;
namespace BelzonaMobile.Core.Models
{
    public class ProductVideoModel
    {
        public int ProductId { get; set; }
        public int LanguageId { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
