using System;
using System.Collections;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the SpecialOffersSchema class.
    /// </summary>
    public class SpecialOffersSchema : BindableSchemaBase, IEquatable<SpecialOffersSchema>
    {
        private string _title;
        private string _dessert1;
        private string _main1;
        private string _starter1;
        private string _subtitle;
         
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
 
        public string Dessert1
        {
            get { return _dessert1; }
            set { SetProperty(ref _dessert1, value); }
        }
 
        public string Main1
        {
            get { return _main1; }
            set { SetProperty(ref _main1, value); }
        }
 
        public string Starter1
        {
            get { return _starter1; }
            set { SetProperty(ref _starter1, value); }
        }
 
        public string Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value); }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return Dessert1; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultContent
        {
            get { return Dessert1; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "title":
                        return String.Format("{0}", Title); 
                    case "dessert1":
                        return String.Format("{0}", Dessert1); 
                    case "main1":
                        return String.Format("{0}", Main1); 
                    case "starter1":
                        return String.Format("{0}", Starter1); 
                    case "subtitle":
                        return String.Format("{0}", Subtitle); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }


        public bool Equals(SpecialOffersSchema other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Title == other.Title && this.Dessert1 == other.Dessert1 && this.Main1 == other.Main1 && this.Starter1 == other.Starter1 && this.Subtitle == other.Subtitle;
        }
    }
}
