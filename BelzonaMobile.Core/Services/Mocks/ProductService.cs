using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BelzonaMobile.Core.Models;
using Newtonsoft.Json;

namespace BelzonaMobile.Core.Services.Mocks
{
    public class ProductService : IProductService
    {
        
        public  async Task<IEnumerable<ProductModel>> GetAllProductsAsync(int? LanguageId = null)
        {
            await Task.Delay(50);
            var assembly = typeof(ProductService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Core.Resources.products.json");
            var reader = new System.IO.StreamReader(stream);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<ProductModel>>(json);
            return LanguageId == null ? data : data.Where(f => f.LanguageId == LanguageId).ToList();
        }

       
        public async Task<List<ProductDocumentModel>> GetAllDocumentsAsync(int LanguageId, int ProductId)
        {
            await Task.Delay(1);
            var assembly = typeof(ProductService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Core.Resources.productdocument.json");

            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<ProductDocumentModel>>(json);
            data =  data.Where(f => f.LanguageId == LanguageId && f.ProductId == ProductId).ToList();
            stream = assembly.GetManifestResourceStream("BelzonaMobile.Core.Resources.productdocumenttype.json");
            reader = new StreamReader(stream);
            json = reader.ReadToEnd();
            var types = JsonConvert.DeserializeObject<List<ProductDocumentTypeModel>>(json);
            foreach (var item in data)
            {
                item.ProductDocumentType = types.FirstOrDefault(f => f.DocumentTypeId == item.DocumentTypeId && f.LanguageId == LanguageId);
            }
            return data;

        }
         
        public async Task<ProductDetailModel> GetProductDetailAsync(int LanguageId, int ProductId)
        {
            await Task.Delay(1);
            var assembly = typeof(ProductService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Core.Resources.productdetail.json");
            List<ProductDetailModel> data;
            
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            data = JsonConvert.DeserializeObject<List<ProductDetailModel>>(json);
            
            return data.FirstOrDefault(f => f.LanguageId == LanguageId && f.ProductId == ProductId);

            
        }

        public async Task<List<ProductVideoModel>> GetProductVideosAsync(int LanguageId, int ProductId)
        {
            await Task.Delay(1);
            var assembly = typeof(ProductService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Core.Resources.productvideos.json");
            List<ProductVideoModel> data;
            
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            data = JsonConvert.DeserializeObject<List<ProductVideoModel>>(json);
            
            return data.Where(f => f.LanguageId == LanguageId && f.ProductId == ProductId).ToList();
        }
    }
}
