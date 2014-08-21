using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class StartersDataSource : DataSourceBase<StartersSchema>
    {
        protected override string CacheKey
        {
            get { return "StartersDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<StartersSchema> _data = new StartersSchema[]
		{
            new StartersSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                ImageUrl = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<StartersSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
