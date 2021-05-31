using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThiefWorld
{
    public partial class Information : Form
    {
        private Button General;
        private Button Levels;
        private Button Shop;
        private Button MainScreen;
        private Label GeneralInformation;
        private Label Gener;
        private Label GeneralAdd;
        private Label Level;
        private Label ShopInf;
        private Label LevelsInformation;
        private Label ShopInformation;


        public Information()
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackgroundImage = LevelsImages.BackGroundIm;
            Load += Information_Load;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Information_Load(object sender, EventArgs e)
        {
            General = new Button
            {
                Location = new Point(40, 120),
                Text = "Общая информация",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            Levels = new Button
            {
                Location = new Point(40, 280),
                Text = "Уровни",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            Shop = new Button
            {
                Location = new Point(40, 440),
                Text = "Магазин",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            MainScreen = new Button
            {
                Location = new Point(100, 800),
                Text = "Главный экран",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(250, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            GeneralInformation = new Label
            {
                Location = new Point(550, 150),
                Text = "\"Сломай свой мозг!\" - игра, направленная на развитие вашей памяти," +
                " внимательности, способности мыслить логически и быстро находить решение." +
                " Вам предстоит играть за вора, попавшего в мир головоломок и загадок." +
                " В этом мире он не может зарабатывать на жизнь привычным образом-кражами," +
                " получить деньги возможно лишь при прохождении уровней." +
                " Как только уровни будут пройдены вор сможет вернуться обратно" +
                " с заработанными деньгами и купленной одеждой и начать жизнь с чистого листа. " +
                " Помогите ему в этом нелегком деле, а заодно прокачайтесь и сами!",
                BackColor = Color.Transparent,
                Size = new Size(1200, 220),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
            Gener = new Label
            {
                Location = new Point(850, 20),
                Text = "Общая информация",
                BackColor = Color.Transparent,
                Size = new Size(800, 100),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 32, FontStyle.Bold),
            };
            GeneralAdd = new Label
            {
                Location = new Point(550, 420),
                Text = "Игра начинается, как только вы нажимаете кнопку " +
                "\"Продолжить\" (вы продолжите с того места, на котором остановились в прошлый раз) " +
                "или \"Начать заново\" (сбрасывает предыдущее прохождение и всё начинается заново). " +
                "После нажатия на одну из кнопок описанных выше, вы попадете на карту уровней, " +
                "где сможете увидеть заработанное количество монет, выбрать уровень или зайти в магазин. " +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "Обратите внимание! Сохранение игры происходит при нажатии кнопки \"Выйти\" на главном экране.",
                BackColor = Color.Transparent,
                Size = new Size(1200, 320),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
            LevelsInformation = new Label
            {
                Location = new Point(550, 150),
                Text = "В игре вам предложено пройти пять уровней разной сложности. " +
                "Каждый из них состоит из трех блоков: математические примеры, последовательности и загадка/задача." +
                "В самом начале уровня вам нужно выбрать сложность математических примеров" +
                ", если вы не сделаете выбор, то по умолчанию она останется на отметке \"Легко\". " +
                "Проходить уровень нужно в порядке, в котором расположены кнопки: \"Примеры\"->\"Последовательности\"->\"Загадка\". " +
                "Уровень считается пройденным, если по нему набрано больше 150 очков, в противном случае следующий уровень остается недоступным для прохождения." +
                "\n" +
                "\n" +
                "\"Примеры\": " +
                "\n" +
                "Вам необходимо посчитать значение выражения, ввести ответ в поле и нажать кнопку \"Ответить\", " +
                "после чего появится правильный ответ и следующий пример, а вам в зависимости от правильности решения начислятся баллы. " +
                "Если вы решите пример верно, то сложность следующего увеличится, если нет - уменьшится." +
                "\n" +
                "\n" +
                "\"Последовательности\": " +
                "\n" +
                "В данном блоке последовательности идут по очереди. Вам нужно запомнить порядок символов, а затем ввести в поле, " +
                "появляющееся после нажатия на кнопку \"Ответить\" и вновь нажать на кнопку. После этого " +
                "высветится результат: правильно ли вы ввели последовательность или нет. Пробелы в последовательности НЕ могут стоять в начале и конце, " +
                "но между символами они есть, поэтому будьте внимательны при введении ответа." +
                "\n" +
                "\n" +
                "\"Загадка\": " +
                "\n" +
                "Здесь вам предложено решить загадку или задачу. Если ответ в виде слова или предложения" +
                ", введите его с большой буквы не ставя никаких знаков препинания. После нажатия кнопки \"Ответить\"" +
                " в зависимости от правильности ответа в поле высветится \"Верно\" или \"Неверно\"." +
                "\n" +
                "\n" +
                "При перепрохождении уровня монеты, заработанные при его решении до этого, списываются.",
                BackColor = Color.Transparent,
                Size = new Size(1200, 1120),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
            ShopInformation = new Label
            {
                Location = new Point(550, 150),
                Text = "В магазине вы можете приобрести понравившийся вам комплект при наличии достаточного количества монет." +
                "Чтобы купить костюм кликните на его картинку, а затем нажмите кнопку \"Купить\". " +
                "При нажатии на кнопку \"Выбрать\" герой в данном костюме появляется на главном экране.",
                BackColor = Color.Transparent,
                Size = new Size(1200, 220),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
            ShopInf = new Label
            {
                Location = new Point(1000, 20),
                Text = "Магазин",
                BackColor = Color.Transparent,
                Size = new Size(800, 100),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 32, FontStyle.Bold),
            };
            Level = new Label
            {
                Location = new Point(1000, 20),
                Text = "Уровни",
                BackColor = Color.Transparent,
                Size = new Size(800, 100),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 32, FontStyle.Bold),
            };
            General.Click += (sender, args) =>
            {
                Controls.Remove(Level);
                Controls.Remove(LevelsInformation);
                Controls.Add(Gener);
                Controls.Remove(ShopInf);
                Controls.Remove(ShopInformation);
                Controls.Add(GeneralInformation);
                Controls.Add(GeneralAdd);

            };
            Levels.Click += (sender, args) =>
            {
                Controls.Remove(Gener);
                Controls.Remove(GeneralInformation);
                Controls.Remove(GeneralAdd);
                Controls.Remove(ShopInf);
                Controls.Remove(ShopInformation);
                Controls.Add(Level);
                Controls.Add(LevelsInformation);

            };
            Shop.Click += (sender, args) =>
            {
                Controls.Remove(Gener);
                Controls.Remove(GeneralInformation);
                Controls.Remove(GeneralAdd);
                Controls.Remove(Level);
                Controls.Remove(LevelsInformation);
                Controls.Add(ShopInf);
                Controls.Add(ShopInformation);

            };
            MainScreen.Click += (sender, args) =>
            {
                Close();
            };
            Controls.Add(General);
            Controls.Add(Levels);
            Controls.Add(Shop);
            Controls.Add(MainScreen);
            Controls.Add(Gener);
            Controls.Add(GeneralInformation);
            Controls.Add(GeneralAdd);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.FillRectangle(Brushes.LemonChiffon, 500, 120, 1280, ClientSize.Height - 170);
        }

        
    }
}
