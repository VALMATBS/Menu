using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class StartersDataSource : DataSourceBase<StartersSchema>
    {
        protected override string CacheKey
        {
            get { return "StartersDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<StartersSchema> _data = new StartersSchema[]
		{
            new StartersSchema
            {
                Subtitle = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam. " +
    "",
                Title = "Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ul" +
    "lamcorper vehicula imperdiet. ",
                Image = "/Assets/DataImages/Item-d3de8689-45e1-4f9c-b07b-8b82680e103d.jpg",
                Description = @"uisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut vitae eleifend dolor, nec elementum nibh.

Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id venenatis nunc. Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. Sed ac nibh commodo, blandit arcu a, facilisis metus. ",
            },
            new StartersSchema
            {
                Subtitle = "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a a" +
    "rcu at dictum. Suspendisse viverra diam at felis vehicula gravida.",
                Title = "Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mau" +
    "ris, ornare vitae ultricies quis, molestie vitae metus. Sed velit velit, condime" +
    "ntum porta congue id, varius ac erat.",
                Image = "/Assets/DataImages/Item-ca3c4a86-0c71-47ca-af18-f02a12e86b25.jpg",
                Description = "Phasellus vehicula ultricies elementum. Aenean eros ligula, vestibulum vitae feli" +
    "s vel, commodo volutpat augue.\n\nNulla facilisi. Mauris neque odio, egestas ac sc" +
    "elerisque a, ullamcorper id nibh. Fusce ut mollis massa. ",
            },
            new StartersSchema
            {
                Subtitle = "Phasellus non cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a " +
    "nisi.",
                Title = @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus orn",
                Image = "/Assets/DataImages/Item-10dc3d9e-5320-4a8f-89c1-93dc9834460f.jpg",
                Description = "Nunc venenatis nisi sed consequat pulvinar. Maecenas volutpat tincidunt ante, qui" +
    "s ornare massa euismod nec. Etiam euismod sapien justo, vel tincidunt massa pulv" +
    "inar vel. Morbi auctor risus eget suscipit sodales.",
            },
            new StartersSchema
            {
                Subtitle = "Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit a" +
    "met elit vel, facilisis bibendum libero. ",
                Title = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
    "lus eu, rhoncus risus. Suspendisse potenti. ",
                Image = "/Assets/DataImages/Item-a4af80ef-45ce-461c-a008-0a803c8ebb13.jpg",
                Description = " Aliquam erat volutpat. Sed non metus purus. Donec dignissim tincidunt justo a ma" +
    "lesuada.\n\nSed sodales sagittis feugiat. Proin sit amet suscipit orci. In non sag" +
    "ittis mi. Integer sollicitudin fermentum suscipit. Etiam ut condimentum nunc. ",
            },
		};

        public async override Task<IEnumerable<StartersSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
