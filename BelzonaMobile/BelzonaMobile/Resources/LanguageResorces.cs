using System;
using System.Collections.Generic;


namespace BelzonaMobile.Resources
{
    public class LanguageResources
    {


        public static TextResourceModel[] TextResources
        {

            get
            {
                var data = new TextResourceModel[]{
                
                #region PageTitles
                
                //English - UK
                new TextResourceModel(){LanguageId = 1, Text = "Products", ElementName = ElementName.ProductPageTitle },
                //English - USA
                new TextResourceModel(){LanguageId = 2, Text = "Products", ElementName = ElementName.ProductPageTitle },
                //Spanish
                new TextResourceModel(){LanguageId = 3, Text = "Productos", ElementName = ElementName.ProductPageTitle },
                
                #endregion
                
                 #region LeftMenu Items
                
                //English - UK
                new TextResourceModel(){LanguageId = 1, Text = "Language", ElementName = ElementName.Languages },
                //English - USA
                new TextResourceModel(){LanguageId = 2, Text = "Language", ElementName = ElementName.Languages },
                //Spanish
                new TextResourceModel(){LanguageId = 3, Text = "Idiomas", ElementName = ElementName.Languages },
                
                #endregion
                
                
                
                
                
                

       #region HomeTextElements
                
                //English - UK
                new TextResourceModel(){LanguageId = 1, Text = "Products", ElementName = ElementName.ProductButton },
                new TextResourceModel(){LanguageId = 1, Text = "Industries", ElementName = ElementName.IndustriesButton },
                new TextResourceModel(){LanguageId = 1, Text = "Applications", ElementName = ElementName.ApplicationButton},
                new TextResourceModel(){LanguageId = 1, Text = "Videos", ElementName = ElementName.VideoButton },

                //English - USA
                new TextResourceModel(){LanguageId = 2, Text = "Products", ElementName = ElementName.ProductButton },
                new TextResourceModel(){LanguageId = 2, Text = "Industries", ElementName = ElementName.IndustriesButton },
                new TextResourceModel(){LanguageId = 2, Text = "Applications", ElementName = ElementName.ApplicationButton },
                new TextResourceModel(){LanguageId = 2, Text = "Videos", ElementName = ElementName.VideoButton },    
														
                //Spanish - LA						  
                new TextResourceModel(){LanguageId = 3, Text = "Productos", ElementName = ElementName.ProductButton },
                new TextResourceModel(){LanguageId = 3, Text = "Industrias", ElementName = ElementName.IndustriesButton },
                new TextResourceModel(){LanguageId = 3, Text = "Aplicaciones", ElementName = ElementName.ApplicationButton },
                new TextResourceModel(){LanguageId = 3, Text = "Videos", ElementName = ElementName.VideoButton },
														
                //Spanish - Spain 					  
                new TextResourceModel(){LanguageId = 4, Text = "Productos", ElementName = ElementName.ProductButton },
                new TextResourceModel(){LanguageId = 4, Text = "Industrias", ElementName = ElementName.IndustriesButton },
                new TextResourceModel(){LanguageId = 4, Text = "Aplicaciones", ElementName = ElementName.ApplicationButton },
                new TextResourceModel(){LanguageId = 4, Text = "Videos", ElementName = ElementName.VideoButton }









       #endregion

            };
                return data;
            }

        }
    }
}
