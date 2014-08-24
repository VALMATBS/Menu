using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

namespace AppStudio.Data
{
    public class DessertsDataSource : DataSourceBase<DessertsSchema>
    {
        private readonly MobileService<DessertsSchema> _mobileService = new MobileService<DessertsSchema>();

        protected override string CacheKey
        {
            get { return "DessertsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        private readonly IEnumerable<DessertsSchema> _data = new DessertsSchema[]
		{
            new DessertsSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                Image = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<DessertsSchema>> LoadDataAsync()
        {
            return await _mobileService.Table.ToListAsync();
        }
        
        public override async Task DeleteAsync(DessertsSchema currentItem)
        {
            await _mobileService.Table.DeleteAsync(currentItem);
            await UpdateCache();
        }

        public override async Task SaveAsync(DessertsSchema currentItem)
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
