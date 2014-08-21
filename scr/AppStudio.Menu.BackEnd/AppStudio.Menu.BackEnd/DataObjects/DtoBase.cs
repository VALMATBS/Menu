using Microsoft.WindowsAzure.Mobile.Service;

namespace AppStudio.Menu.BackEnd.DataObjects
{
    public class DtoBase : EntityData
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}