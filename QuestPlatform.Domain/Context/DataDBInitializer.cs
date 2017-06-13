using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Enums;
using Store.Models;

namespace QuestPlatform.Domain.Context
{
    public class DataDbInitializer : DropCreateDatabaseIfModelChanges<DataDbContext>
    {
        protected override void Seed(DataDbContext context)
        {
            #region [Initialize default identity roles]
            var roleStore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(roleStore);

            var identityRoles = new List<IdentityRole>()
            {
                new IdentityRole() {Name = RoleTypes.Admin},
                new IdentityRole() {Name = RoleTypes.Manager},
                new IdentityRole() {Name = RoleTypes.Visitor}
            };

            foreach (var role in identityRoles)
            {
                rolemanager.Create(role);
            }
            #endregion

            #region [Initialize default user for each role]
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            foreach (var role in identityRoles)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = role.Name + "@ow.com",
                    UserName = role.Name + "@ow.com"
                };
                userManager.Create(user, "P@ssw0rd");
                userManager.AddToRole(user.Id, role.Name);
            }
            #endregion

            #region [Create park]
            var admin = userManager.FindByEmail("Admin@ow.com");
            var park = new Park() { Description = "Очень красивый парк", Name = "Голосеевский парк", Manager = admin };
            context.Parks.Add(park);
            #endregion

            #region [Create bluetooth beacons] 
            var beacons = new[]
            {
                new Beacon() {UUID = "00:15:83:00:72:27", TresholdRSSI = 85},
                new Beacon() {UUID = "00:15:83:00:70:47", TresholdRSSI = 85},
                new Beacon() {UUID = "00:15:83:00:54:E0", TresholdRSSI = 85},
                new Beacon() {UUID = "00:15:83:00:A0:E4", TresholdRSSI = 85}
            };
            context.Beacons.AddRange(beacons);
            #endregion

            #region [Add Beacons to Park]
            for (int i = 0; i < beacons.Length; i++)
            {
                var beaconInPark = new BeaconInPark()
                {
                    Park = park,
                    Beacon = beacons[i],
                    SequenceNumber = i,
                    NextBeaconLocationTip = "Не останавливайся и двигайся дальше - следующий маячок находится возле ..."
                };
                context.BeaconsInPark.Add(beaconInPark);
            }
            #endregion

            #region [Init questions]
            var questions = new[]
            {
                new Question()
                {
                    Title =
                        "Многие средневековые русские актёры (скоморохи), веселящие народ в ту пору, во время своих выступлений использовали погремушки, изготовленные из бычьего пузыря и находящихся внутри него плодов одного растения. Плоды, какого растения использовались при изготовлении этих погремушек?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "мак"
                        },
                        new Option()
                        {
                            Content = "кукуруза"
                        },
                        new Option()
                        {
                            Content = "фасоль"
                        },
                        new Option()
                        {
                            Content = "горох",
                            IsCorrect = true
                        },
                        new Option()
                        {
                            Content = "орехи"
                        }
                    }
                },
                new Question()
                {
                    Title =
                        "Если в 12 часов ночи в Киеве идет дождь, то какая вероятность того, что через 72 часа будет солнечная погода?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "32%"
                        },
                        new Option()
                        {
                            Content = "0%",
                            IsCorrect = true
                        },
                        new Option()
                        {
                            Content = "60%"
                        },
                        new Option()
                        {
                            Content = "72%"
                        },
                        new Option()
                        {
                            Content = "12%"
                        }
                    }
                },
                new Question()
                {
                    Title =
                        "Чтобы попасть на закрытый аукцион, шпиону необходимо пройти через охрану. Но  пароль ему не известен. На вопрос охранника «Двадцать два?» первый участник аукциона ответил «Одиннадцать». На вопрос «Двадцать восемь?» второй сказал «Четырнадцать». Шпион подошел к охране, и на вопрос «Сорок два?» ответил «Двадцать один», после чего получил пулю в голову. Что должен был ответить шпион, чтобы остаться в живых и попасть на аукцион?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "2"
                        },
                        new Option()
                        {
                            Content = "84"
                        },
                        new Option()
                        {
                            Content = "21"
                        },
                        new Option()
                        {
                            Content = "12"
                        },
                        new Option()
                        {
                            Content = "8",
                            IsCorrect = true
                        }
                    }
                },
                new Question()
                {
                    Title = "Какое море не имеет берегов?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "Кельтское"
                        },
                        new Option()
                        {
                            Content = "Северное"
                        },
                        new Option()
                        {
                            Content = "Тасманово"
                        },
                        new Option()
                        {
                            Content = "Саргассово",
                            IsCorrect = true
                        },
                        new Option()
                        {
                            Content = "Арафурское"
                        }
                    }
                },
                new Question()
                {
                    Title = "Какое число содержит одинаковое количество букв в названии и цифр в написании?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "1000"
                        },
                        new Option()
                        {
                            Content = "3"
                        },
                        new Option()
                        {
                            Content = "1000000",
                            IsCorrect = true
                        },
                        new Option()
                        {
                            Content = "11"
                        },
                        new Option()
                        {
                            Content = "40"
                        }
                    }
                },
                new Question()
                {
                    Title =
                        "С борта парохода был спущен стальной трап, нижние 4 ступеньки которого погрузились в воду. Каждая ступенька имеет толщину 5 см. Расстояние между двумя соседними ступеньками составляет 30 см. Во время прилива уровень воды поднимается со скоростью 40 см/час. Сколько ступенек будут погружены в воду через 2 часа после начала прилива?",
                    Options = new[]
                    {
                        new Option()
                        {
                            Content = "7"
                        },
                        new Option()
                        {
                            Content = "6"
                        },
                        new Option()
                        {
                            Content = "0"
                        },
                        new Option()
                        {
                            Content = "4",
                            IsCorrect = true
                        },
                        new Option()
                        {
                            Content = "5"
                        }
                    }
                }
            };
            #endregion

            #region [Add questions]
            foreach (var question in questions)
            {
                context.Options.AddRange(question.Options);
                context.Questions.Add(question);
            }
            #endregion

            base.Seed(context);
        }
    }
}
