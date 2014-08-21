using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DashboardDataSource : DataSourceBase<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "Starters",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "StartersPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Main",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Main1Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Desserts",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "DessertsPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Beverages",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "BeveragesPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "SpecialOffers",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "SpecialOffersPage",
            },
		};

        protected override string CacheKey
        {
            get { return "DashboardDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<MenuSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
