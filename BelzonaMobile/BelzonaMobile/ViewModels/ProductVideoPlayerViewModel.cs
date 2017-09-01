using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using BelzonaMobile.Core.Models;
using System.Threading.Tasks;

namespace BelzonaMobile.ViewModels
{
    public class ProductVideoPlayerViewModel : ViewModelBase
    {
        IYouTubeVideoService youtubeVideoService;
        public ProductVideoPlayerViewModel(IYouTubeVideoService youtubeVideoService)
        {
            this.youtubeVideoService = youtubeVideoService;
        }
        public override async void OnNavigatedTo(Prism.Navigation.NavigationParameters parameters)
        {
            if (parameters?.ContainsKey("video") == true)
            {
               var param = (Item<Id>)parameters["video"];
               Video = (await youtubeVideoService.GetVideoFullDetailAsync(param.id.videoId)).FirstOrDefault();
            }
            
           if (parameters?.ContainsKey("title") == true)
            {
              Title = (string)parameters["title"];
            }
            
            
        }
        Item<string> video;
        public Item<string> Video
        {
            get { return video; }
            set { SetProperty(ref video, value);
            RaisePropertyChanged("VideoUrl");
              }
        }

        //public string VideoUrl
        //{
        //    get
        //    {
        //         //return $"https://www.youtube.com/embed/{Video?.id}?rel=0&modestbranding=1&autohide=1&showinfo=0&controls=0&autoplay=1&loop=1";
        //        return "https://r3---sn-qpbpuxajvg2-jjne.googlevideo.com/videoplayback?requiressl=yes&lmt=1501253315549516&ei=rjCoWZq3DsO_-gWAl724Bw&id=o-AFWUjiZKqjA8pEfBSwx6hNiZKHTDfecRhaPSdrO7J75g&pcm2cms=yes&mn=sn-qpbpuxajvg2-jjne&mm=31&ip=186.167.251.242&key=yt6&ms=au&mv=m&mt=1504194599&ipbits=0&initcwndbps=317500&signature=2ACD831ACBD13E3EC704E20C6F4A5D40CC3DCF03.80ABE17977D2066E02A5E0A3860F3502EB931EF9&ratebypass=yes&expire=1504216334&mime=video%2Fmp4&itag=22&pl=22&dur=179.559&source=youtube&sparams=dur%2Cei%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmime%2Cmm%2Cmn%2Cms%2Cmv%2Cpcm2cms%2Cpl%2Cratebypass%2Crequiressl%2Csource%2Cexpire";
        //    }
        //}

        string title;
        public string Title
        {
            get{return title;}
            set {SetProperty(ref title,value);}
        }
        
        public double VideoHeight
        {
            get { return ((App.DeviceWidth - 40)/16) * 9; }
            
        }
        
        
      
        
    }
}
