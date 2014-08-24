using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

namespace AppStudio.Data
{
    public class SpecialOffersDataSource : DataSourceBase<SpecialOffersSchema>
    {
        private readonly MobileService<SpecialOffersSchema> _mobileService = new MobileService<SpecialOffersSchema>();
        protected override string CacheKey
        {
            get { return "SpecialOffersDataSource"; }
        }
        public override bool HasStaticData
        {
            get { return false; }
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
            return await _mobileService.Table.ToListAsync();
        }

        public override async Task DeleteAsync(SpecialOffersSchema currentItem)
        {
            await _mobileService.Table.DeleteAsync(currentItem);
            await UpdateCache();
        }

        public override async Task SaveAsync(SpecialOffersSchema currentItem)
        {
            if (currentItem.IsNew)
            {
                await _mobileService.Table.InsertAsync(currentItem);
            }
            else
            {
                await _mobileService.Table.UpdateAsync(currentItem);
            }
            currentItem.IsNew = false;
            await UpdateCache();
        }
    }
}
