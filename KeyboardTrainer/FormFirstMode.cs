using System.Diagnostics;

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
        string[] s;
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
            s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            inputButtonMas();
        }


        Button[] keyboard = new Button[46];
        void inputButtonMas() //вводим визуальную клавиатуру
        {
            string[] keyboardButtons = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0","-","й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з","ч","ъ", "ф",
                "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э", "shift", "я", "ч", "с", "м", "и", "т", "ь", "б", "ю", ".", "space" };
            int left = 3;
            for (int i = 0; i < 46; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 11) left = 3;
                if (i == 23) left = 3;
                if (i == 34) left = 3;
                if (i == 45) left = 8;
                if (i < 11) keyboard[i].Location = new Point(0, 300);
                else if (i < 23) keyboard[i].Location = new Point(0, 350); //сложные и не очень процессы ввода кнопок
                else if (i < 34) keyboard[i].Location = new Point(0, 400);
                else if (i < 45) keyboard[i].Location = new Point(0, 450);
                else
                {
                    keyboard[i].Location = new Point(0, 500);
                    keyboard[i].Text = keyboardButtons[i];
                    keyboard[i].Left = left * 45 + 15;
                    keyboard[i].Size = new Size(100, 40);                   //и это все чтобы удленить пробел
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
        //string[] s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            //string[] s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);//нагло взято с инета, в душе ни чаю что это, но оно работает
            //string text = labelText.Text;
            if (textBoxTrainingField.Text.Split().Length > 1) //опустошаем строку после введенного слова, попутно проверяя
            {
                if (s[check] + " " == textBoxTrainingField.Text) //проверка слова на совпадение в тексте
                    check++;
                else
                {
                    cntErr++;                  //подсчет ошибок
                    labelCntError.Text = "Количество ошибок: " + cntErr;
                }
                textBoxTrainingField.Text = "";
                if (check == s.Length)
                {
                    sw.Stop();
                    MessageBox.Show("Текст из: " + title + "\nКоличество ошибок: " + cntErr +
                        "\nВремени затрачено: " + sw.Elapsed + "\nСреднее кол-во символов в минуту: "
                        + labelText.Text.Length / ((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds) / 60)); //высшая математика, среднее количество символов в минуту
                    this.Close();
                }
                else labelCurrentWord.Text = "Текущее слово: " + s[check];
            }
        }

    }
}