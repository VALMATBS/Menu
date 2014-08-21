using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class SpecialOffersDataSource : DataSourceBase<SpecialOffersSchema>
    {
        protected override string CacheKey
        {
            get { return "SpecialOffersDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<SpecialOffersSchema> _data = new SpecialOffersSchema[]
		{
            new SpecialOffersSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                Starter1 = "starter1",
                Main1 = "main",
                Dessert1 = "dessert1",
            },
		};

        public async override Task<IEnumerable<SpecialOffersSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
