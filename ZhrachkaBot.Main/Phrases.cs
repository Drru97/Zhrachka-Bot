using System;
using System.Collections.Generic;

namespace ZhrachkaBot.Main
{
    public class Phrases
    {
        private static readonly Random _random;

        static Phrases()
        {
            _random = new Random();
        }

        public const string EatCommand = "жерти";

        public static readonly string[] EatPlacePhrases =
        {
            "Куди хавати йдем?",
            "Їсти де будем?",
            "Шо там сьогодні з харчуванням?",
            "Шо з жеровиськом?",
            "Шо з обідом?",
            "Будем ходити їсти?",
            "Йдем пожрать?",
            "Панове, їсти йдем?"
        };

        public static readonly IEnumerable<Place2> Places = new List<Place2>
        {
            new Place2("Реберня",
                "https://fastly.4sqi.net/img/general/width960/35769820_uWSqv78GXnD48JvGvEee1zHhesMrwLa0no8lZNDsbdk.jpg",
                49.8415316f, 24.0330474f, 0.1),
            new Place2("Ірена", "https://t-ec.bstatic.com/images/hotel/max1024x768/100/100887525.jpg", 49.8418076f,
                23.9997009f, 0.1),
            new Place2("Купава", "https://www.kupavahotel.com/wp-content/uploads/2018/02/UW6A9980-1.jpg", 49.8439299f,
                23.9998621f, 0.2),
            new Place2("Челентано", "http://egoisty.com/sites/default/files/gallery/celentano/img_5371.jpg", 49.8359134f,
                23.9993439f, 0.2),
            new Place2("Кебаб",
                "https://tomato.ua/image/resize/storage/restaurants//15349138795b7ced5764c28_BOfaWcog9qtlJkW4092aCZbSQS7n9G6gSqF0JBIK.jpeg",
                49.8344734f, 24.0126917f, 0.2),
            new Place2("Каюта",
                "https://s3.eu-central-1.amazonaws.com/listmusor/production/68006/gallery/big/591d862957b6c.jpg",
                49.842959f, 23.9991356f, 0.3),
            new Place2("Сезони", "https://tsina.lviv.ua/wp-content/uploads/2017/03/sezony.jpg", 49.8366503f, 24.0019747f,
                0.6)
        };

        public static string GetRandomEatPhrase()
        {
            return EatPlacePhrases[_random.Next(0, EatPlacePhrases.Length)];
        }
    }
}