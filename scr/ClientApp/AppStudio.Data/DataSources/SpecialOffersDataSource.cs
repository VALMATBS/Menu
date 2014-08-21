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
                Title = "Daily menu special",
                dessert1 = "orem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam.",
                main1 = "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a a" +
    "rcu at dictum. Suspendisse viverra diam at felis vehicula gravida. Phasellus non" +
    " cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a nisi. ",
                starter1 = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
    " vitae eleifend dolor, nec elementum nibh. ",
                Subtitle = "Price: $10",
            },
            new SpecialOffersSchema
            {
                Title = "Kids menu",
                dessert1 = "Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit a" +
    "met elit vel, facilisis bibendum libero. ",
                main1 = "molestie vitae metus. Sed velit velit, condimentum porta congue id, varius ac era" +
    "t. Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. I" +
    "nteger facilisis sapien non turpis volutpat viverra.",
                starter1 = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
    "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
    "natis nunc.",
                Subtitle = "Price: $5",
            },
            new SpecialOffersSchema
            {
                Title = "Menu for two",
                dessert1 = "Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ul" +
    "lamcorper vehicula imperdiet. ",
                main1 = "Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu qui" +
    "s quam. Nullam ut tellus vel purus luctus ornare. ",
                starter1 = " Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. " +
    "Sed ac nibh commodo, blandit arcu a, facilisis metus. Phasellus vehicula ultrici" +
    "es elementum. Aenean eros ligula, vestibulum vitae felis vel, commodo volutpat a" +
    "ugue. ",
                Subtitle = "Price: $18",
            },
            new SpecialOffersSchema
            {
                Title = "Menu for four",
                dessert1 = "Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mau" +
    "ris, ornare vitae ultricies quis,[Enter name]",
                main1 = " Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus te" +
    "llus eu, rhoncus risus. Suspendisse potenti. ",
                starter1 = "Nulla facilisi. Mauris neque odio, egestas ac scelerisque a, ullamcorper id nibh." +
    " Fusce ut mollis massa. Nunc venenatis nisi sed consequat pulvinar. ",
                Subtitle = "Price: $35",
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
