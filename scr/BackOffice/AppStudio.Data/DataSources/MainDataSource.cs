using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

namespace AppStudio.Data
{
    public class MainDataSource : DataSourceBase<MainSchema>
    {
        private readonly MobileService<MainSchema> _mobileService = new MobileService<MainSchema>();

        protected override string CacheKey
        {
            get { return "MainDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        private readonly IEnumerable<MainSchema> _data = new MainSchema[]
		{
            new MainSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                Image = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<MainSchema>> LoadDataAsync()
        {
            return await _mobileService.Table.ToListAsync();
        }

        public override async Task DeleteAsync(MainSchema currentItem)
        {
            await _mobileService.Table.DeleteAsync(currentItem);
            await UpdateCache();
        }

        public override async Task SaveAsync(MainSchema currentItem)
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
