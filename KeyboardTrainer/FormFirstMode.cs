using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace KeyboardTrainer
{
    //1 - Крестный отец
    //2 - Хранители снов
    //3 - Великолепная семерка
    //4 - Ведьмак 2
    //5 - Хоббит: Неожиданное путешествие
    //6 - Назад в будущее
    //7 - Бэтмен: Начало
    //8 - Джентельмены
    //9 - Бешеные псы
    //10 - Во все тяжкие
    public partial class FormFirstMode : Form
    {
        int check = 0;
        int cntErr = 0;
        string title = "";
        int ind = 0;


        public FormFirstMode()
        {
            InitializeComponent();
            Random rnd = new Random();
            int ind = rnd.Next(0, 10);
            string[] text = { "text1.txt", "text2.txt", "text3.txt", "text4.txt", "text5.txt",
                "text6.txt", "text7.txt", "text8.txt", "text9.txt", "text10.txt" };
            string[] ans = { "Крестный отец", "Хранители снов", "Великолепная семерка", "Ведьмак 2: Убийца королей", "Хоббит: Неожиданное путешествие",
                "Назад в будущее", "Бэтмен: Начало", "Джентельмены", "Бешеные псы", "Во все тяжкие"};
            StreamReader sr = new StreamReader(text[ind]);
            title = ans[ind];
            labelText.Text = sr.ReadToEnd();
            sr.Close();                     //если что файл закрыт
            labelCurrentWord.Text = "Текущее слово: " + labelText.Text.Split()[0];

            inputButtonMas();
        }


        Button[] keyboard = new Button[46];
        void inputButtonMas() //вводим визуальную клавиатуру
        {
            string[] keyboardButtons = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0","-","й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з","х","ъ", "ф",
                "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э", "shift", "я", "ч", "с", "м", "и", "т", "ь", "б", "ю", ".", "space" };
            int left = 3;
            for (int i = 0; i < 46; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 11) left = 3;
                else if (i == 23) left = 3;
                else if (i == 34) left = 3;
                else if (i == 45) left = 8;
                if (i < 11) keyboard[i].Location = new Point(0, 450);
                else if (i < 23) keyboard[i].Location = new Point(0, 500); //сложные и не очень процессы ввода кнопок
                else if (i < 34) keyboard[i].Location = new Point(0, 550);
                else if (i < 45) keyboard[i].Location = new Point(0, 600);
                else
                {
                    keyboard[i].Location = new Point(0, 650);
                    keyboard[i].Text = keyboardButtons[i];
                    keyboard[i].Left = left * 45 + 15;
                    keyboard[i].Size = new Size(100, 40);                   //и это все чтобы удлинить пробел
                    base.Controls.Add(keyboard[i]);
                    break;
                }
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                base.Controls.Add(keyboard[i]);
            }
        }


        Stopwatch sw = Stopwatch.StartNew(); //таймер
        int check1 = 0;
        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            List<string> text = new List<string>(labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            //взято с инета, нужно чтобы сплитнуть ентеры. Понимаю, что плохо делать его на каждом исправлении поля ввода, но по другому не придумал
            string user = textBoxTrainingField.Text;
            if (user == "")
            {
                for (int i = 0; i < keyboard.Length; i++)
                {
                    keyboard[i].BackColor = Color.White;
                }
            }

            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < keyboard.Length; j++)
                {
                    if (user.Length <= text[check].Length)
                    {
                        if (user[i].ToString().ToLower() == keyboard[j].Text && text[check][i] == user[i])  //это кошмар, но на этом кошмаре
                            keyboard[j].BackColor = Color.Green;                                            //работает визуальная клавиатура
                        else if (user[i] == ',')
                        {
                            keyboard[34].BackColor = Color.Yellow;  //клавиши, нажимаемые парно, закрашиваются желтым, остальные зеленым
                            keyboard[44].BackColor = Color.Yellow;
                        }
                        else if (user[i] == '?' && text[check][i] == user[i])
                        {
                            keyboard[34].BackColor = Color.Yellow;
                            keyboard[6].BackColor = Color.Yellow;
                        }
                        else if (user[i] == '!' && text[check][i] == user[i])
                        {
                            keyboard[34].BackColor = Color.Yellow;
                            keyboard[0].BackColor = Color.Yellow;
                        }
                        else if (user[i].ToString().ToLower() == keyboard[j].Text && text[check][i] != user[i])
                            keyboard[j].BackColor = Color.Red;  //нерпавильные красным
                    }
                    else
                    {
                        if (keyboard[j].Text == user[i].ToString()) keyboard[j].BackColor = Color.Red;
                    }
                }
            }


            //далее основная работа программы
            if (textBoxTrainingField.Text.Split().Length > 1) //опустошаем строку после введенного слова, попутно проверяя
            {

                if (text[check] + " " == user) //проверка слова на совпадение в тексте
                    check++;
                else
                {
                    cntErr++;                  //подсчет ошибок
                    labelCntError.Text = "Количество ошибок: " + cntErr;
                }
                textBoxTrainingField.Text = ""; //опустошение
                if (check == text.Count)
                {
                    sw.Stop();
                    MessageBox.Show("Текст из: " + title + "\nКоличество ошибок: " + cntErr +
                        "\nВремени затрачено: " + sw.Elapsed.Minutes + ":" + sw.Elapsed.Seconds + "\nСреднее кол-во символов в минуту: "
                        + labelText.Text.Length / ((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds) / 60)); //среднее количество символов в минуту
                    this.Close();
                }
                else labelCurrentWord.Text = "Текущее слово: " + text[check];


            }
        }

    }
}