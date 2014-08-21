
using Microsoft.WindowsAzure.Mobile.Service;

namespace AppStudio.Menu.BackEnd.DataObjects
{
    /// <summary>
    /// Implementation of the SpecialOffersSchema class.
    /// </summary>
    public class SpecialOffersSchema : EntityData
    {
        public string Dessert1 { get; set; }

        public string Main1 { get; set; }

        public string Starter1 { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }
    }
}
