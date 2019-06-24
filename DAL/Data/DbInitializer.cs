using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Data
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            // Type

            var types = new List<Type>
            {
                new Type()
                {
                    Id = 1,
                    Name = "Дівчатка"
                },

                new Type()
                {
                    Id = 2,
                    Name = "Хлопчики"
                },

                new Type()
                {
                    Id = 3,
                    Name = "Для новонароджених"
                },

                new Type()
                {
                    Id = 4,
                    Name = "Іграшки, аксесуари"
                },

                new Type()
                {
                    Id = 5,
                    Name = "Sale"
                }
            };

            context.Types.AddRange(types);

            // Subtype

            var subtypes = new List<Subtype>
            {
                // Дівчатка

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Комплекти"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Подарункові комплекти"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Бодіки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Чоловічки, сліпи, ромпери, пісочники"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Кофти, фліски, реглани, туніки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Плаття і спіднички"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Штанці і шорти"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Комбінезони, куртки, жилетки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Піжамки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Білизна, носочки, колготки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Шапки, панамки"
                },

                new Subtype()
                {
                    TypeId = 1,
                    Name = "Взуття"
                },

                // Хлопчики

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Комплекти"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Подарункові комплекти"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Бодіки"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Чоловічки, сліпи, ромпери, пісочники"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Кофти, фліски, реглани"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Штанці і шорти"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Комбінезони, куртки, жилетки"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Піжамки"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Білизна, носочки, колготки"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Шапки, панамки"
                },

                new Subtype()
                {
                    TypeId = 2,
                    Name = "Взуття"
                },

                // Іграшки, аксесуари

                new Subtype()
                {
                    TypeId = 4,
                    Name = "Пледи, пеленки"
                },

                new Subtype()
                {
                    TypeId = 4,
                    Name = "Все для купання"
                },

                new Subtype()
                {
                    TypeId = 4,
                    Name = "Іграшки"
                },

                new Subtype()
                {
                    TypeId = 4,
                    Name = "Інше"
                },

                // Sale

                new Subtype()
                {
                    TypeId = 5,
                    Name = "Sale дівчатка"
                },

                new Subtype()
                {
                    TypeId = 5,
                    Name = "Sale хлопчики"
                }
            };

            context.Subtypes.AddRange(subtypes);

            // Size

            var sizes = new List<Size>
            {
                new Size()
                {
                    Name = "NB (до 56 см)"
                },

                new Size()
                {
                    Name = "0-3 міс"
                },

                new Size()
                {
                    Name = "3-6 міс"
                },

                new Size()
                {
                    Name = "6-9 міс"
                },

                new Size()
                {
                    Name = "9-12 міс"
                },

                new Size()
                {
                    Name = "12-18 міс"
                },

                new Size()
                {
                    Name = "18-24 міс"
                },

                new Size()
                {
                    Name = "від 2 до 3 років"
                },

                new Size()
                {
                    Name = "від 3 до 4 років"
                },

                new Size()
                {
                    Name = "від 4 до 5 років"
                },

                new Size()
                {
                    Name = "від 5 до 6 років"
                }
            };

            context.Sizes.AddRange(sizes);

            // Trade Mark

            var tradeMarks = new List<TradeMark>
            {
                new TradeMark()
                {
                    Name = "Carter’s"
                },

                new TradeMark()
                {
                    Name = "H&M"
                },

                new TradeMark()
                {
                    Name = "The Children’s Place"
                },

                new TradeMark()
                {
                    Name = "Gymboree"
                },

                new TradeMark()
                {
                    Name = "Інші"
                }
            };

            context.TradeMarks.AddRange(tradeMarks);
            base.Seed(context);
        }
    }
}