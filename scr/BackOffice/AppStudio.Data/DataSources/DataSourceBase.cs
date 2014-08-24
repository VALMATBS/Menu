using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public abstract class DataSourceBase<T> where T : BindableSchemaBase
    {
        private const int ContentExpirationHours = 0;
        private const int ContentExpirationMinutes = 5;

        protected abstract string CacheKey { get; }

        public abstract Task<IEnumerable<T>> LoadDataAsync();

        public abstract Task DeleteAsync(T item);

        public abstract Task SaveAsync(T item);
        
        public abstract bool HasStaticData { get; }

        public async Task<DateTime> LoadDataAsync(ObservableCollection<T> viewItems, bool forceRefresh)
        {
            DateTime timeStamp = DateTime.Now;

            if (HasStaticData)
            {
                viewItems.AddRangeUnique(await LoadDataAsync());
            }
            else
            {
                var dataInCache = await AppCache.GetItemsAsync<T>(CacheKey);
                if (dataInCache != null)
                {
                    timeStamp = dataInCache.TimeStamp;

                    viewItems.AddRangeUnique(dataInCache.Items);
                }

                if (NetworkInterface.GetIsNetworkAvailable() && DataNeedToBeUpdated(forceRefresh, dataInCache))
                {
                    var freshData = await UpdateCache();

                    viewItems.AddRangeUnique(freshData.Items);
                    timeStamp = freshData.TimeStamp;
                }
            }
            return timeStamp;
        }

        internal async Task<DataSourceContent<T>> UpdateCache()
        {
            var freshData = new DataSourceContent<T>()
            {
                TimeStamp = DateTime.Now,
                Items = await LoadDataAsync()
            };

            await AppCache.AddItemsAsync(CacheKey, freshData);
            return freshData;
        }


        private bool DataNeedToBeUpdated(bool forceRefresh, DataSourceContent<T> dataInCache)
        {
            return dataInCache == null || forceRefresh || IsContentExpirated(dataInCache.TimeStamp);
        }

        private bool IsContentExpirated(DateTime timeStamp)
        {
            return (DateTime.Now - timeStamp) > new TimeSpan(ContentExpirationHours, ContentExpirationMinutes, 0);
        }
    }
}
