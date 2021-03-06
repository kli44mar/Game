using System;
using System.Collections.Generic;
using System.Text;
using ThiefWorld.Architecture;

namespace ThiefWorld.Interface
{
    public class Levels
    {
        public Level Level1 { get; private set; }
        public Level Level2 { get; private set; }
        public Level Level3 { get; private set; }
        public Level Level4 { get; private set; }
        public Level Level5 { get; private set; }
        
        public Levels()
        {
            Level1 = new Level(new Dictionary<(int, string), string>
            {
                [(1, "7 + 3" )] = "10",
                [(1, "12 + 3")] = "15",
                [(1, "9 + 11")] = "20",
                [(1, "17 + 6")] = "23",
                [(1, "34 + 8")] = "42",
                [(1, "87 + 6")] = "93",
                [(1, "58 + 3")] = "61",
                [(1, "77 + 6")] = "83",

                [(2, "72 + 43")] = "115",
                [(2, "203 - 7")] = "196",
                [(2, "18 + 15")] = "33",
                [(2, "48 + 72")] = "120",
                [(2, "476 - 25")] = "451",
                [(2, "487 - 103")] = "384",
                [(2, "22 + 55")] = "77",
                [(2, "34 - 90")] = "-56",

                [(3, "268 + 608 + 72")] = "948",
                [(3, "98 - 67 + 85")] = "116",
                [(3, "130 - 13 + 423")] = "540",
                [(3, "256 - 34 - 213")] = "9",
                [(3, "709 + 43 - 15")] = "737",
                [(3, "2 + 4 - 13")] = "-7",
                [(3, "89 - 17 - 23")] = "49",
                [(3, "308 + 873 + 415")] = "1596"
            },
            8,
            new List<string>
            {
                 "1 2 3 4 5" ,
                "11 13 12 15 14",
                 "29 28 27 26 25" ,
                 "32 34 36 38 40" ,
                 "51 53 55 57 59" ,
                 "13 26 39 52 65" ,
                 "1 10 100 1000 10000" ,
                 "78 87 89 98" ,
                 "12 23 34 45" ,
                 "aa bb cc dd" ,
                 "ab ba bc cb" ,
                 "t tt ttt t" ,
                 "tm tmt tmtmt" ,
                 "a1 b2 c3 d4",
                 "1a1 2b2 3c3 4d4" ,
                 "abc bac bca"
            },
            8,
            new Dictionary<string, string>
            {
                ["Гуси шли на водопой гуськом(один за другим). " +
                "Один гусь посмотрел вперёд-перед ним 17 голов. " +
                "Посмотрел назад-за ним 36 лап. " +
                "Сколько всего гусей шло на водопой?"] = "36",
                ["Москву раньше называли белокаменной. А какой город называли чёрным?"] = "Чернигов",
            },
            1,
            new List<string> { "Initial" },
            null) ;

            Level2 = new Level(new Dictionary<(int, string), string>
            {
                [(1, "8 * 10")] = "80",
                [(1, "8 / 8")] = "1",
                [(1, "6 * 4")] = "24",
                [(1, "60 / 10")] = "6",
                [(1, "6 * 7")] = "42",
                [(1, "70 / 10")] = "7",

                [(2, "32 * 50")] = "1600",
                [(2, "9600 * 90")] = "864000",
                [(2, "390 * 40")] = "15600",
                [(2, "102000 / 600")] = "170",
                [(2, "8720 / 4")] = "2180",
                [(2, "7150 / 55")] = "130",

                [(3, "12 * 3 / 4 * 2")] = "18",
                [(3, "9 * 5 – 36 / 6 / 2")] = "42",
                [(3, "( 7 * 4 + 33 ) – 3 * 6 / 2")] = "52",
                [(3, "54 / 9 + ( 8 + 19 ) / 3 – 32 / 4")] = "7",
                [(3, "21 / 7 + (42 – 14 ) / 4 – ( 44 – 14 ) / 5")] = "22",
                [(3, "8 * 5 – (60 – 42 ) / 3 + 9 * 2")] = "52"
            }, 
            6,
            new List<string> 
            { 
                "1 4 9 16 25", 
                "10 8 6 4 2", 
                "1 3 5 6 9 10",
                "2 4 2 -2 -4 -2",
                "1 -1 3 -3 5",
                "3 4 5 16 25",
                "ah ha hh ha aa",
                "rr rrmay mayrrr mayy",
                "trtt trtata lala aiai",
                "hj jak tii",
                "13 -13 31 -31 5",
                "13 24 35 66 25",
            },
            6,
            new Dictionary<string, string>
            {
                ["Представьте, перед вами четыре стакана, наполненных водой. " +
                "В каждом стакане находятся предметы. Так: " +
            "в первом стакане – металлические наручные часы; " +
            "во втором стакане – канцелярская скрепка; " +
            "в третьем стакане – металлические ножницы; " +
            "в четвертом стакане – ластик. " +
            "При этом уровень воды во всех стаканах одинаковый. Вопрос: в каком стакане воды больше, чем в остальных? Ответ запишите цифрой"] =
            "2",
                ["В кафе быстрого питания зашли четыре посетителя. При этом: " +
            "первый посетитель купил три бургера и заплатил 300 рублей; " +
            "второй посетитель купил один бургер и две порции картофеля фри и заплатил 200 рублей; " +
            "третий посетитель купил два куска пиццы и одну порцию картофеля фри и заплатил 90 рублей; " +
            "четвертый посетитель купил один бургер, одну порцию картофеля фри и один кусок пиццы. " +
            "Вопрос: сколько заплатил четвертый посетитель?"] = "170"
            },
            2,
            new List<string> { "Initial" },
            Level1);

            Level3 = new Level(new Dictionary<(int, string), string>
            {
                [(1, "3,3 + 2,2")] = "5,5",
                [(1,"7,6 - 2,3 + 72")] = "77,3",
                [(1, "9,3 - 2,8 + 3,3")] = "9,8",
                [(1, "5,76 - 0,8")] = "4,96",
                [(1, "0,56 + 0,34")] = "0,9",


                [(2, "9,68 + 0,06 + 8 - 4,58")] = "13,16",
                [(2, "5,6 - 4,38 + 7 + 3,94")] = "12,16",
                [(2, "4 - 3,84 + 8,13 - (4,03 - 12,5)")] = "16,76",
                [(2, "5,35 - 4,776")] = "0,574",
                [(2, "1,75 + 345,897")] = "347,647",

                [(3, "0,48 * 6")] = "2,88",
                [(3, "13,2 / 24")]= "0,55",
                [(3, "0,7 * 25")] = "17,5",
                [(3, "0,909 / 45")]= "0,0202",
                [(3, "61,699 / 158")] = "0,3905",
            },
            5,
            new List<string>
            {
                "−1 1/4 -1/9 1/16",
                "11 13 12 15 14" ,
                "126 238 247 26 275" ,
                "76 34 86 108 40" ,
                "531 543 555 567 579" ,
                "143 246 349 542 645" ,
                "13 102 1060 15000 106000" ,
                "788 877 899 988" ,
                "009 990 099 900" ,
                "78 877 59 3388" ,
            },
            5,
            new Dictionary<string, string>
            {
                ["Воинственное племя захватило странника. Вождь хотел смерти страннику и позволил ему выбирать. " +
                "Страннику разрешалось озвучить одну фразу. При правдивости фразы его сбросят с отвесной скалы. Окажись фраза лживая, и его отдадут львам на растерзание. " +
                "Но странник подобрал такую фразу, которая подарила ему свободу." +
                "Отгадайте, что это за фраза ? "] = "Меня растерзают львы",
                ["Многие средневековые русские актёры (скоморохи) веселящие народ в ту пору, во время своих выступлений использовали погремушки, изготовленные из бычьего пузыря и находящихся внутри него плодов одного растения." +
                "Плоды, какого растения использовались при изготовлении этих погремушек?"] = "Горох"
            },
            3,
            new List<string> { "Initial" },
            Level2);

            Level4 = new Level(new Dictionary<(int, string), string>
            {
                [(1, "log {3} 4 / log {3} 2")] = "2",
                [(1, "log {0,2} 125")] = "-3",

                [(2, "log {4} 32")] = "5/2",
                [(2, "log{12} 3 + log {12} 4 + 1")] = "2",

                [(3, "1/log {12} 18+ 1/log {27} 18")] = "2",
                [(3, "8^(log {2} 3) + 9^(log {3} 4)")] = "43"
            },
            3,
            new List<string>
            {
                "1adf e2fd rrr3 kj4 kl5",
                "1//1 1..3. 1././/2 /..15",
                "20.0.9 2/./....8 2000.7 2.../6 25//",
                "3a/a2 38a4 3bb6 38c c40" ,
                "5991 53kk 55ggg 577887 5..9" ,
                "13mn 26lk df39 5ty2 6jj5" ,
            },
            3,
            new Dictionary<string, string>
            {
                ["Один джентльмен, показывая своему другу портрет, нарисованный по его заказу одним художником, сказал: " +
                "У меня нет ни сестер, ни братьев, но отец этого человека был сыном моего отца" +
                ". Кто был изображен на портрете?"] = "Сын",
                ["Для того чтобы получить краску оранжевого цвета, " +
                "необходимо смешать краски желтого цвета (6 частей) и красного цвета (2 части). " +
                "Сколько грамм краски оранжевого цвета можно получить (максимально), " +
                "имея в наличии 3 грамма желтой и 3 грамма красной краски?"] = "4"
            },
            4,
            new List<string> { "Initial" },
            Level3);

            Level5 = new Level(new Dictionary<(int, string), string>
            {
                [(1, "(6 - x) + (12 + x) - (3 - 2x) = 15")] = "0",

                [(2, "(7x + 1)(3x - 1) - 21x^2 = 3")] = "948",

                [(3, "log {5} (3x − 11) + log {5} (x − 27) = log {5} 8 + 3")] = "37",
            },
            2,
            new List<string>
            {
                "1875hh 28hlg7 309lljj",
                "hj5 lkjh67 yu38vb",
                "cgu147 579yte1 ldj683n",
                "njch19 2njg89 8jdy62",
            },
            2,
            new Dictionary<string, string>
            {
                ["При издании книги потребовалось 2 775 цифр того, чтобы пронумеровать ее страницы. " +
                "Сколько страниц в книге?"] = "961",
                ["Какое слово начинается на три Г, а кончается на три Я?"] = "Тригонометрия"
            },
            5,
            new List<string> { "Initial" },
            Level4);
        }        
    }
}
