using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Models
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync(int? LanguageId = null);
        Task<List<ProductDocumentModel>> GetAllDocumentsAsync(int LanguageId, int ProductId);
        Task<ProductDetailModel> GetProductDetailAsync(int LanguageId, int ProductId);
        Task<List<ProductVideoModel>> GetProductVideosAsync(int LanguageId, int ProductId);
    }
}
