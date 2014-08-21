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
                Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam.",
                Subtitle = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
    "lus eu, rhoncus risus. Suspendisse potenti.",
                Image = "/Assets/DataImages/Item-c162122b-f143-425b-99e8-11d0f228bc8e.jpg",
                Description = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
    "lus eu, rhoncus risus. Suspendisse potenti. Qui",
            },
            new DessertsSchema
            {
                Title = "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a a" +
    "rcu at dictum. Suspendisse viverra diam at felis vehicula gravida. Phasellus non" +
    " cursus magna. Phasellus nunc nisl, congue et pharetra eu, ",
                Subtitle = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
    " vitae eleifend dolor, nec elementum nibh. ",
                Image = "/Assets/DataImages/Item-61bc87fb-955b-4b04-a6ba-ce40dcde2d78.jpg",
                Description = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
    " vitae eleifend dolor, nec elementum nibh.\n\nDuis consectetur sit amet neque in p" +
    "osuere.",
            },
            new DessertsSchema
            {
                Title = "dictum a nisi. Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula" +
    ", dapibus sit amet elit vel, facilisis bibendum libero. Praesent sagittis imperd" +
    "iet vulputate. ",
                Subtitle = "Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. S" +
    "ed ac nibh commodo, blandit arcu a, facilisis metus",
                Image = "/Assets/DataImages/Item-83b00868-c5c5-4645-88b2-8bc1c88ec925.jpg",
                Description = @"Vestibulum vitae sagittis ipsum. Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id venenatis nunc. Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. Sed ac nibh commodo, blandit arcu a, facilisis metus.",
            },
            new DessertsSchema
            {
                Title = "Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mau" +
    "ris, ornare vitae ultricies quis, molestie vitae metus. Sed velit velit, condime" +
    "ntum porta congue id, varius ac erat.",
                Subtitle = "Phasellus vehicula ultricies elementum. Aenean eros ligula, vestibulum vitae feli" +
    "s vel, commodo volutpat augue. ",
                Image = "/Assets/DataImages/Item-f5a74e7a-d859-47ee-a883-dd8a3986c3fe.jpg",
                Description = @"Phasellus vehicula ultricies elementum. Aenean eros ligula, vestibulum vitae felis vel, commodo volutpat augue.

Nulla facilisi. Mauris neque odio, egestas ac scelerisque a, ullamcorper id nibh. Fusce ut mollis massa. Nunc venenatis nisi sed consequat pulvinar. Maecenas volutpat tincidunt ante, quis ornare massa euismod nec.",
            },
            new DessertsSchema
            {
                Title = @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus orn",
                Subtitle = "Etiam euismod sapien justo, vel tincidunt massa pulvinar vel. Morbi auctor risus " +
    "eget suscipit sodales. Aliquam erat volutpat. Sed non metus purus. Donec digniss" +
    "im tincidunt justo a malesuada. ",
                Image = "/Assets/DataImages/Item-80b27450-54f7-4597-a15b-cbaeb1a7e266.jpg",
                Description = "Etiam euismod sapien justo, vel tincidunt massa pulvinar vel. Morbi auctor risus " +
    "eget suscipit sodales. Aliquam erat volutpat. Sed non metus purus. Donec digniss" +
    "im tincidunt justo a malesuada. ",
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
