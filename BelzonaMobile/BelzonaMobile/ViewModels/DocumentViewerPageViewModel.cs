using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.ViewModels
{
    public class DocumentViewerPageViewModel : ViewModelBase
    {
        public DocumentViewerPageViewModel()
        {

        }
        public override void OnNavigatedTo(Prism.Navigation.NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters?.ContainsKey("document") == true)
            {
                Document = (ProductDocumentModel)parameters["document"];
            }
        }

        ProductDocumentModel document;
        public ProductDocumentModel Document
        {
            get { return document; }
            set { SetProperty(ref document, value); }
        }
    }
}
