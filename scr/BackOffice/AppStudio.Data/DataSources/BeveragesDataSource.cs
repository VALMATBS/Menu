using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class BeveragesDataSource : DataSourceBase<BeveragesSchema>
    {
        protected override string CacheKey
        {
            get { return "BeveragesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<BeveragesSchema> _data = new BeveragesSchema[]
		{
            new BeveragesSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                ImageUrl = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<BeveragesSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
