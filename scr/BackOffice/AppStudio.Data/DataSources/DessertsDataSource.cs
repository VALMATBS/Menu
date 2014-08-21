using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DessertsDataSource : DataSourceBase<DessertsSchema>
    {
        protected override string CacheKey
        {
            get { return "DessertsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<DessertsSchema> _data = new DessertsSchema[]
		{
            new DessertsSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                ImageUrl = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<DessertsSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
