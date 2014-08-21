using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NavigateDataSource : DataSourceBase<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "Starters",
                Icon = "/Assets/DataImages/Item-bb9b89f8-376f-4751-aafc-e5d3c2ab303b.png",
                Target = "StartersPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Mains",
                Icon = "/Assets/DataImages/Item-5b7e62bf-29b9-4305-a5e3-cf2f06db3d5d.png",
                Target = "Main1Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Desserts",
                Icon = "/Assets/DataImages/Item-40aec9cb-9618-4bc1-9fe1-e777bd20efaa.png",
                Target = "DessertsPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Beverages",
                Icon = "/Assets/DataImages/Item-683d5acd-2bac-4f1a-ac48-32c4a7d1c968.png",
                Target = "BeveragesPage",
            },
		};

        protected override string CacheKey
        {
            get { return "NavigateDataSource"; }
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
