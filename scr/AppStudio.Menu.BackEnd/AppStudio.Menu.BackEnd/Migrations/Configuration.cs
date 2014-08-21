// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity.Migrations;
using System.Linq;
using AppStudio.Data;
using AppStudio.Menu.BackEnd.DataObjects;
using AppStudio.Menu.BackEnd.Models;

namespace AppStudio.Menu.BackEnd.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppStudio.Menu.BackEnd.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(MobileServiceContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data.
            if (!context.BeveragesSchemas.Any() &&
                !context.DessertsSchemas.Any() &&
                !context.MainSchemas.Any() &&
                !context.SpecialOffersSchemas.Any() &&
                !context.StartersSchemas.Any())
            {
                AddOrUpdateBeveragesSchemas(context);
                AddOrUpdateDessertsSchemas(context);
                AddOrUpdateMainSchemas(context);
                AddOrUpdateSpecialOffersSchemas(context);
                AddOrUpdateStartersSchemas(context);
            }
        }

        private static void AddOrUpdateStartersSchemas(MobileServiceContext context)
        {
            context.StartersSchemas.AddOrUpdate(p => p.Id, new StartersSchema
            {
                Id = Guid.NewGuid().ToString(),
                Subtitle = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam. " +
                           "",
                Title = "Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ul" +
                        "lamcorper vehicula imperdiet. ",
                Image = "/Assets/DataImages/Item-d3de8689-45e1-4f9c-b07b-8b82680e103d.jpg",
                Description =
                    @"uisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut vitae eleifend dolor, nec elementum nibh.

Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id venenatis nunc. Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. Sed ac nibh commodo, blandit arcu a, facilisis metus. ",
            },
                new StartersSchema
                {
                    Id = Guid.NewGuid().ToString(),
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
                    Id = Guid.NewGuid().ToString(),
                    Subtitle = "Phasellus non cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a " +
                               "nisi.",
                    Title =
                        @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus orn",
                    Image = "/Assets/DataImages/Item-10dc3d9e-5320-4a8f-89c1-93dc9834460f.jpg",
                    Description = "Nunc venenatis nisi sed consequat pulvinar. Maecenas volutpat tincidunt ante, qui" +
                                  "s ornare massa euismod nec. Etiam euismod sapien justo, vel tincidunt massa pulv" +
                                  "inar vel. Morbi auctor risus eget suscipit sodales.",
                },
                new StartersSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Subtitle = "Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit a" +
                               "met elit vel, facilisis bibendum libero. ",
                    Title = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
                            "lus eu, rhoncus risus. Suspendisse potenti. ",
                    Image = "/Assets/DataImages/Item-a4af80ef-45ce-461c-a008-0a803c8ebb13.jpg",
                    Description = " Aliquam erat volutpat. Sed non metus purus. Donec dignissim tincidunt justo a ma" +
                                  "lesuada.\n\nSed sodales sagittis feugiat. Proin sit amet suscipit orci. In non sag" +
                                  "ittis mi. Integer sollicitudin fermentum suscipit. Etiam ut condimentum nunc. ",
                });
        }

        private static void AddOrUpdateSpecialOffersSchemas(MobileServiceContext context)
        {
            context.SpecialOffersSchemas.AddOrUpdate(p => p.Id,
                new SpecialOffersSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Daily menu special",
                    Dessert1 = "orem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam.",
                    Main1 = "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a a" +
                            "rcu at dictum. Suspendisse viverra diam at felis vehicula gravida. Phasellus non" +
                            " cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a nisi. ",
                    Starter1 = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
                               " vitae eleifend dolor, nec elementum nibh. ",
                    Subtitle = "Price: $10",
                },
                new SpecialOffersSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Kids menu",
                    Dessert1 = "Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit a" +
                               "met elit vel, facilisis bibendum libero. ",
                    Main1 = "molestie vitae metus. Sed velit velit, condimentum porta congue id, varius ac era" +
                            "t. Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. I" +
                            "nteger facilisis sapien non turpis volutpat viverra.",
                    Starter1 = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
                               "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
                               "natis nunc.",
                    Subtitle = "Price: $5",
                },
                new SpecialOffersSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Menu for two",
                    Dessert1 = "Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ul" +
                               "lamcorper vehicula imperdiet. ",
                    Main1 = "Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu qui" +
                            "s quam. Nullam ut tellus vel purus luctus ornare. ",
                    Starter1 = " Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. " +
                               "Sed ac nibh commodo, blandit arcu a, facilisis metus. Phasellus vehicula ultrici" +
                               "es elementum. Aenean eros ligula, vestibulum vitae felis vel, commodo volutpat a" +
                               "ugue. ",
                    Subtitle = "Price: $18",
                },
                new SpecialOffersSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Menu for four",
                    Dessert1 = "Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mau" +
                               "ris, ornare vitae ultricies quis,[Enter name]",
                    Main1 = " Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus te" +
                            "llus eu, rhoncus risus. Suspendisse potenti. ",
                    Starter1 = "Nulla facilisi. Mauris neque odio, egestas ac scelerisque a, ullamcorper id nibh." +
                               " Fusce ut mollis massa. Nunc venenatis nisi sed consequat pulvinar. ",
                    Subtitle = "Price: $35",
                });
        }

        private static void AddOrUpdateMainSchemas(MobileServiceContext context)
        {
            context.MainSchemas.AddOrUpdate(p => p.Id, new MainSchema
            {
                Id = Guid.NewGuid().ToString(),
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
                    Id = Guid.NewGuid().ToString(),
                    Title = "Main 2",
                    Subtitle = "Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id v" +
                               "enenatis nunc. Phasellus at odio vitae ante luctus facilisis.",
                    Image = "/Assets/DataImages/Item-ce8c2ecc-7f46-41b2-a575-15feda69b7ca.jpg",
                    Description = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
                                  " vitae eleifend dolor, nec elementum nibh.",
                },
                new MainSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Main 3",
                    Subtitle = "[Enter name]",
                    Image = "/Assets/DataImages/Item-982c0af7-7f8d-4a76-9a86-9bf8ac2259c9.jpg",
                    Description = "Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id v" +
                                  "enenatis nunc. Phasellus at odio vitae ante luctus facilisis.",
                },
                new MainSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Main 4",
                    Subtitle = "Quisque consequat auctor urna tincidunt bibendum. Quisque vitae commodo neque. Ut" +
                               " vitae eleifend dolor, nec elementum nibh.",
                    Image = "/Assets/DataImages/Item-786c691a-a3b3-443f-b62f-6120ef68cb9e.jpg",
                    Description = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
                                  "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
                                  "natis nunc. Phasellus at odio vitae ante luctus facilisis. ",
                });
        }

        private static void AddOrUpdateDessertsSchemas(MobileServiceContext context)
        {
            context.DessertsSchemas.AddOrUpdate(p => p.Id,
                new DessertsSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam.",
                    Subtitle = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
                               "lus eu, rhoncus risus. Suspendisse potenti.",
                    Image = "/Assets/DataImages/Item-c162122b-f143-425b-99e8-11d0f228bc8e.jpg",
                    Description = "Duis sodales elementum lacus id suscipit. Nunc eget justo porttitor, faucibus tel" +
                                  "lus eu, rhoncus risus. Suspendisse potenti. Qui",
                },
                new DessertsSchema
                {
                    Id = Guid.NewGuid().ToString(),
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
                    Id = Guid.NewGuid().ToString(),
                    Title = "dictum a nisi. Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula" +
                            ", dapibus sit amet elit vel, facilisis bibendum libero. Praesent sagittis imperd" +
                            "iet vulputate. ",
                    Subtitle = "Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. S" +
                               "ed ac nibh commodo, blandit arcu a, facilisis metus",
                    Image = "/Assets/DataImages/Item-83b00868-c5c5-4645-88b2-8bc1c88ec925.jpg",
                    Description =
                        @"Vestibulum vitae sagittis ipsum. Nulla non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id venenatis nunc. Phasellus at odio vitae ante luctus facilisis. Fusce imperdiet viverra aliquam. Sed ac nibh commodo, blandit arcu a, facilisis metus.",
                },
                new DessertsSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mau" +
                            "ris, ornare vitae ultricies quis, molestie vitae metus. Sed velit velit, condime" +
                            "ntum porta congue id, varius ac erat.",
                    Subtitle = "Phasellus vehicula ultricies elementum. Aenean eros ligula, vestibulum vitae feli" +
                               "s vel, commodo volutpat augue. ",
                    Image = "/Assets/DataImages/Item-f5a74e7a-d859-47ee-a883-dd8a3986c3fe.jpg",
                    Description =
                        @"Phasellus vehicula ultricies elementum. Aenean eros ligula, vestibulum vitae felis vel, commodo volutpat augue.

Nulla facilisi. Mauris neque odio, egestas ac scelerisque a, ullamcorper id nibh. Fusce ut mollis massa. Nunc venenatis nisi sed consequat pulvinar. Maecenas volutpat tincidunt ante, quis ornare massa euismod nec.",
                },
                new DessertsSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title =
                        @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus orn",
                    Subtitle = "Etiam euismod sapien justo, vel tincidunt massa pulvinar vel. Morbi auctor risus " +
                               "eget suscipit sodales. Aliquam erat volutpat. Sed non metus purus. Donec digniss" +
                               "im tincidunt justo a malesuada. ",
                    Image = "/Assets/DataImages/Item-80b27450-54f7-4597-a15b-cbaeb1a7e266.jpg",
                    Description = "Etiam euismod sapien justo, vel tincidunt massa pulvinar vel. Morbi auctor risus " +
                                  "eget suscipit sodales. Aliquam erat volutpat. Sed non metus purus. Donec digniss" +
                                  "im tincidunt justo a malesuada. ",
                });
        }

        private static void AddOrUpdateBeveragesSchemas(MobileServiceContext context)
        {
            context.BeveragesSchemas.AddOrUpdate(p => p.Id,
                new BeveragesSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Beverage 1",
                    Subtitle = "Rum and coke",
                    Image = "/Assets/DataImages/Item-ab11f8ac-f4e5-4965-9cc2-489799e45266.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec quis rutrum quam. " +
                                  "Cras porttitor est justo, sit amet rutrum orci facilisis ac. Quisque sagittis a " +
                                  "arcu at dictum. ",
                },
                new BeveragesSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Beverage 2",
                    Subtitle = "Whisky",
                    Image = "/Assets/DataImages/Item-5b137a92-ae0c-47d0-9b71-1e73257c8ca9.jpg",
                    Description =
                        @"Suspendisse viverra diam at felis vehicula gravida. Phasellus non cursus magna. Phasellus nunc nisl, congue et pharetra eu, dictum a nisi. Vivamus sagittis purus vel elementum suscipit. Nulla lectus ligula, dapibus sit amet elit vel, facilisis bibendum libero.",
                },
                new BeveragesSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Beverage 3",
                    Subtitle = "Water",
                    Image = "/Assets/DataImages/Item-6e5a2641-5b35-43db-92a1-ffe0f3cd05f8.jpg",
                    Description =
                        @"Praesent sagittis imperdiet vulputate. In hac habitasse platea dictumst. Donec ullamcorper vehicula imperdiet.

Curabitur accumsan tortor nibh, id viverra ante egestas non. Phasellus tortor mauris, ornare vitae ultricies quis, molestie vitae metus. Sed velit velit, condimentum porta congue id, varius ac erat. ",
                },
                new BeveragesSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Beverage 4",
                    Subtitle = "Orange liqueur",
                    Image = "/Assets/DataImages/Item-1ef0e1e7-1288-493e-a8ba-c135cacf1dca.jpg",
                    Description =
                        @"Quisque eu justo non felis luctus rhoncus sed ut risus. Nulla sed erat dui. Integer facilisis sapien non turpis volutpat viverra. Nam porttitor accumsan posuere. Morbi vehicula lorem et mi eleifend luctus eu quis quam. Nullam ut tellus vel purus luctus ornare",
                },
                new BeveragesSchema
                {
                    Id = Guid.NewGuid().ToString(),
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
                    Id = Guid.NewGuid().ToString(),
                    Title = "Beverage 6",
                    Subtitle = "Soft-drink",
                    Image = "/Assets/DataImages/Item-dbfbc5ec-feb8-4cf3-801b-fc98bd589995.jpg",
                    Description = "Duis consectetur sit amet neque in posuere. Vestibulum vitae sagittis ipsum. Null" +
                                  "a non ante sit amet eros dictum bibendum. Donec et convallis urna. Morbi id vene" +
                                  "natis nunc. Phasellus at odio vitae ante luctus facilisis. ",
                });
        }
    }
}
