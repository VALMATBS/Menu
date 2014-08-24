using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

namespace AppStudio.Data
{
    public class BeveragesDataSource : DataSourceBase<BeveragesSchema>
    {
        private readonly MobileService<BeveragesSchema> _mobileService = new MobileService<BeveragesSchema>();

        protected override string CacheKey
        {
            get { return "BeveragesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        private readonly IEnumerable<BeveragesSchema> _data = new BeveragesSchema[]
		{
			new BeveragesSchema
			{
				Title = "title",
				Subtitle = "subtitle",
				Image = "/Assets/NoImage.png",
				Description = "description",
			},
		};

        public async override Task<IEnumerable<BeveragesSchema>> LoadDataAsync()
        {

            var items = await _mobileService.Table.ToListAsync();
            return items;
        }

        public override async Task DeleteAsync(BeveragesSchema currentItem)
        {
            await _mobileService.Table.DeleteAsync(currentItem);
            await UpdateCache();
        }

        public override async Task SaveAsync(BeveragesSchema currentItem)
        {
            BeveragesSchema item = null;
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
