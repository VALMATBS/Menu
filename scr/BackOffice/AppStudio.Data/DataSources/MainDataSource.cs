using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class MainDataSource : DataSourceBase<MainSchema>
    {
        protected override string CacheKey
        {
            get { return "MainDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<MainSchema> _data = new MainSchema[]
		{
            new MainSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                ImageUrl = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<MainSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
