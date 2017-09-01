using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BelzonaMobile.Core.Models
{
    public interface IYouTubeVideoService
    {
    Task<IEnumerable<Item<Id>>> GetAllAsync(string productName);
    Task<IEnumerable<Item<string>>> GetVideoFullDetailAsync(string videoId);
    }
}
