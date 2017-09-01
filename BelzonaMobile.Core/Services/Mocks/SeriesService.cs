using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.Core.Services.Mocks
{
    public class SeriesService : ISeriesService
    {
       

        public async Task<IEnumerable<SeriesModel>> GetAllAsync(int? LanguageId = null)
        {
            await Task.Delay(1);

            var data = new SeriesModel[]{
                //English
                new SeriesModel(){Id= 1, LanguageId = 1, SeriesColor = "#C4262E", Name="1000 Series" },
                new SeriesModel(){Id= 2, LanguageId = 1, SeriesColor = "#004B8D", Name="2000 Series"},
                new SeriesModel(){Id= 3, LanguageId = 1, SeriesColor = "#6AC28A", Name="3000 Series"},
                new SeriesModel(){Id= 4, LanguageId = 1, SeriesColor = "#FF6D22", Name="4000 Series"},
                new SeriesModel(){Id= 5, LanguageId = 1, SeriesColor = "#C4262E", Name="5000 Series"},
                new SeriesModel(){Id= 6, LanguageId = 1, SeriesColor = "#ADAFAF", Name="6000 Series"},
                new SeriesModel(){Id= 7, LanguageId = 1, SeriesColor = "#ADAFAF", Name="Other Products"},
                new SeriesModel(){Id= 8, LanguageId = 1, SeriesColor = "#AA9C8F", Name="Belestra"},
                new SeriesModel(){Id= 9, LanguageId = 1, SeriesColor = "#ADAFAF", Name="7000 Series"},
                
                //Spanish
                new SeriesModel(){Id= 1, LanguageId = 3, SeriesColor = "#C4262E", Name="1000 Serie"},
                new SeriesModel(){Id= 2, LanguageId = 3, SeriesColor = "#004B8D", Name="2000 Serie"},
                new SeriesModel(){Id= 3, LanguageId = 3, SeriesColor = "#6AC28A", Name="3000 Serie"},
                new SeriesModel(){Id= 4, LanguageId = 3, SeriesColor = "#FF6D22", Name="4000 Serie"},
                new SeriesModel(){Id= 5, LanguageId = 3, SeriesColor = "#C4262E", Name="5000 Serie"},
                new SeriesModel(){Id= 6, LanguageId = 3, SeriesColor = "#ADAFAF", Name="6000 Serie"},
                new SeriesModel(){Id= 7, LanguageId = 3, SeriesColor = "#ADAFAF", Name="7000 Serie"},
                new SeriesModel(){Id= 8, LanguageId = 3, SeriesColor = "#AA9C8F", Name="8000 Serie"},
                                                         
                //French
                new SeriesModel(){Id= 1, LanguageId = 2, Name="1000 Série"},
                new SeriesModel(){Id= 2, LanguageId = 2, Name="2000 Série"},
                new SeriesModel(){Id= 3, LanguageId = 2, Name="3000 Série"},
                new SeriesModel(){Id= 4, LanguageId = 2, Name="4000 Série"},
                new SeriesModel(){Id= 5, LanguageId = 2, Name="5000 Série"},
                new SeriesModel(){Id= 6, LanguageId = 2, Name="6000 Série"},
                new SeriesModel(){Id= 7, LanguageId = 2, Name="7000 Série"},
                new SeriesModel(){Id= 8, LanguageId = 2, Name="8000 Série"},
                
                //Rusian
                new SeriesModel(){Id= 1, LanguageId = 7, Name="1000 Серия"},
                new SeriesModel(){Id= 2, LanguageId = 7, Name="2000 Серия"},
                new SeriesModel(){Id= 3, LanguageId = 7, Name="3000 Серия"},
                new SeriesModel(){Id= 4, LanguageId = 7, Name="4000 Серия"},
                new SeriesModel(){Id= 5, LanguageId = 7, Name="5000 Серия"},
                new SeriesModel(){Id= 6, LanguageId = 7, Name="6000 Серия"},
                new SeriesModel(){Id= 7, LanguageId = 7, Name="7000 Серия"},
                new SeriesModel(){Id= 8, LanguageId = 7, Name="8000 Серия"},
                

            };
            
            return LanguageId  !=  null ?  data.Where(f => f.LanguageId == LanguageId) : data;
            
        }
    }
}