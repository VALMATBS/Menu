using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

namespace AppStudio.Data
{
    public class StartersDataSource : DataSourceBase<StartersSchema>
    {
        private readonly MobileService<StartersSchema> _mobileService = new MobileService<StartersSchema>();
      

        protected override string CacheKey
        {
            get { return "StartersDataSource"; }
        }
        public override bool HasStaticData
        {
            get { return false; }
        }

        private readonly IEnumerable<StartersSchema> _data = new StartersSchema[]
		{
            new StartersSchema
            {
                Title = "title",
                Subtitle = "subtitle",
                Image = "/Assets/NoImage.png",
                Description = "description",
            },
		};

        public async override Task<IEnumerable<StartersSchema>> LoadDataAsync()
        {
            return await _mobileService.Table.ToListAsync();
        }

        public override async Task DeleteAsync(StartersSchema currentItem)
        {
            await _mobileService.Table.DeleteAsync(currentItem);
            await UpdateCache();
        }

        public override async Task SaveAsync(StartersSchema currentItem)
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
