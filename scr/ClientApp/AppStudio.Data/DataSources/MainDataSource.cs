using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class MainDataSource : DataSourceBase<MainSchema>
    {
        protected override string CacheKey
        {
            get { return "MainDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        private readonly IEnumerable<MainSchema> _data = new MainSchema[]
		{
            new MainSchema
            {
                Title = "Main 1",
                Subtitle = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
    "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
    "natis nunc. Phasellus at odio vitae ante luctus facilisis. ",
                Image = "/Assets/DataImages/Item-773b932e-b49b-49cb-8671-87953a94480a.jpg",
                Description = "Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu qui" +
    "s quam. Nullam ut tellus vel purus luctus ornare.",
            },
            new MainSchema
            {
                Title = "Main 2",
                Subtitle = "Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id v" +
    "enenatis nunc. Phasellus at odio vitae ante luctus facilisis.",
                Image = "/Assets/DataImages/Item-ce8c2ecc-7f46-41b2-a575-15feda69b7ca.jpg",
                Description = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
    " vitae eleifend dolor, nec elementum nibh.",
            },
            new MainSchema
            {
                Title = "Main 3",
                Subtitle = "[Enter name]",
                Image = "/Assets/DataImages/Item-982c0af7-7f8d-4a76-9a86-9bf8ac2259c9.jpg",
                Description = "Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id v" +
    "enenatis nunc. Phasellus at odio vitae ante luctus facilisis.",
            },
            new MainSchema
            {
                Title = "Main 4",
                Subtitle = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
    " vitae eleifend dolor, nec elementum nibh.",
                Image = "/Assets/DataImages/Item-786c691a-a3b3-443f-b62f-6120ef68cb9e.jpg",
                Description = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
    "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
    "natis nunc. Phasellus at odio vitae ante luctus facilisis. ",
            },
		};

        public async override Task<IEnumerable<MainSchema>> LoadDataAsync()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }
    }
}
