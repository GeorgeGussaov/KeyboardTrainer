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
            sr.Close();
            labelCurrentWord.Text = "Current word: " + labelText.Text.Split()[0];


        }
        Stopwatch sw = Stopwatch.StartNew();

        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            string[] s = labelText.Text.Split(new string[] {" " ,"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);//нагло взято с инета, в душе ни чаю что это, но оно работает
            //string text = labelText.Text;
            if (textBoxTrainingField.Text.Split().Length > 1) //опустошаем строку после введенного слова, попутно проверяя
            {
                if (s[check] + " " == textBoxTrainingField.Text) //проверка слова на совпадение в тексте
                    check++;
                else
                {
                    cntErr++;                  //подсчет ошибок
                    labelCntError.Text = "Count errors: " + cntErr;
                }
                textBoxTrainingField.Text = "";
                if (check == s.Length)
                {
                    sw.Stop();
                    MessageBox.Show("Текст из: " + title + "\nКоличество ошибок: " + cntErr + 
                        "\nВремени затрачено: " + sw.Elapsed + "\nСреднее кол-во символов в минуту: " 
                        + labelText.Text.Length/((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds)/60));
                    this.Close();
                }
                else labelCurrentWord.Text = "Current word: " + s[check];
            }
        }

    }
}