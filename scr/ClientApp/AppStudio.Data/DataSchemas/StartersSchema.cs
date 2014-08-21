using System;
using System.Collections;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the StartersSchema class.
    /// </summary>
    public class StartersSchema : BindableSchemaBase, IEquatable<StartersSchema>
    {
        private string _subtitle;
        private string _title;
        private string _image;
        private string _description;
         
        public string Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value); }
        }
 
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
 
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
 
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public override string DefaultTitle
        {
            get { return Subtitle; }
        }

        public override string DefaultSummary
        {
            get { return Title; }
        }

        public override string DefaultImageUrl
        {
            get { return Image; }
        }

        public override string DefaultContent
        {
            get { return Title; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "subtitle":
                        return String.Format("{0}", Subtitle); 
                    case "title":
                        return String.Format("{0}", Title); 
                    case "image":
                        return String.Format("{0}", Image); 
                    case "description":
                        return String.Format("{0}", Description); 
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


        public bool Equals(StartersSchema other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Subtitle == other.Subtitle && this.Title == other.Title && this.Image == other.Image && this.Description == other.Description;
        }
    }
}
