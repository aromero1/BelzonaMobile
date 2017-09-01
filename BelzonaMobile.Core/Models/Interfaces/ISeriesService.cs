using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Models
{
    public interface ISeriesService
    {
    Task<IEnumerable<SeriesModel>> GetAllAsync(int? LanguageId = null);
    }
}
