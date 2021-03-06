using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataSources;

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
                Title = "Beverage 1",
                Subtitle = "Rum and coke",
                Image = "/Assets/DataImages/Item-ab11f8ac-f4e5-4965-9cc2-489799e45266.jpg",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam. " +
    "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a " +
    "arcu at dictum. ",
            },
            new BeveragesSchema
            {
                Title = "Beverage 2",
                Subtitle = "Whisky",
                Image = "/Assets/DataImages/Item-5b137a92-ae0c-47d0-9b71-1e73257c8ca9.jpg",
                Description = @"Suspendisse viverra diam at felis vehicula gravida. Phasellus non cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a nisi. Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit amet elit vel, facilisis bibendum libero.",
            },
            new BeveragesSchema
            {
                Title = "Beverage 3",
                Subtitle = "Water",
                Image = "/Assets/DataImages/Item-6e5a2641-5b35-43db-92a1-ffe0f3cd05f8.jpg",
                Description = @"Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ullamcorper vehicula imperdiet.

Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mauris, ornare vitae ultricies quis, molestie vitae metus. Sed velit velit, condimentum porta congue id, varius ac erat. ",
            },
            new BeveragesSchema
            {
                Title = "Beverage 4",
                Subtitle = "Orange liqueur",
                Image = "/Assets/DataImages/Item-1ef0e1e7-1288-493e-a8ba-c135cacf1dca.jpg",
                Description = @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus ornare",
            },
            new BeveragesSchema
            {
                Title = "Beverage 5",
                Subtitle = "Wine",
                Image = "/Assets/DataImages/Item-6bdb924b-5cdf-41aa-8406-610a8aad19e3.jpg",
                Description = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
    "lus eu, rhoncus risus. Suspendisse potenti. Quisque consequat auctor urna tincid" +
    "unt bibendum. Quisque vitae commodo neque. Ut vitae eleifend dolor, nec elementu" +
    "m nibh.",
            },
            new BeveragesSchema
            {
                Title = "Beverage 6",
                Subtitle = "Soft-drink",
                Image = "/Assets/DataImages/Item-dbfbc5ec-feb8-4cf3-801b-fc98bd589995.jpg",
                Description = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
    "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
    "natis nunc. Phasellus at odio vitae ante luctus facilisis. ",
            },
        };

        public async override Task<IEnumerable<BeveragesSchema>> LoadDataAsync()
        {
            var mobileService = new MobileService<BeveragesSchema>();
            return await mobileService.Table.ToListAsync();
        }
    }
}
