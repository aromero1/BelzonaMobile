using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.Core.Services.Mocks
{
    public class YouTubeVideoService : IYouTubeVideoService
    {
        IConnectionService conn;
        private static string apiKey = "AIzaSyBntYhpGm6hksN7sYYm91CFZJBrxVywRlk";
        public YouTubeVideoService(IConnectionService conn)
        {
            this.conn = conn;
        }

        public async Task<IEnumerable<Item<Id>>> GetAllAsync(string productName)
        {
            var url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UClET5RmP8cXoQFUS-Sh488Q&maxResults=50&q={productName}&key={apiKey}";
            return (await conn.GetAsync<SearchResults>(url)).items;
        }

        public async Task<IEnumerable<Item<string>>> GetVideoFullDetailAsync(string videoId)
        {
            var url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet&id={videoId}&key={apiKey}";
            var data = (await conn.GetAsync<VideoDetailResults>(url)).items;
            return data;
        }
    }
}
