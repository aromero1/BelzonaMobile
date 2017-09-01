using System;
namespace BelzonaMobile
{
    public class TextResourceModel
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public ElementName ElementName { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }
	
    public enum ElementName
	{
    
        //Page Titles
        ProductPageTitle,
        
        //Home Page
        ProductButton,
        IndustriesButton,
        ApplicationButton,
        VideoButton,

        //LeftMenu
        Languages,
        Distributors,
		Preferences,
        ContactUs
    }
}

