using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTrainer
{
    public partial class FormSecondMode : Form
    {
        Button newbtn = new Button();
        int cntDown = 0; //количество нажатий
        int cntHit = 0;  //колво попаданий

        public FormSecondMode()
        {
            InitializeComponent();
        }

        Stopwatch sw = Stopwatch.StartNew(); //таймер

        void newButton(Button btn) //появление новых кнопок
        {
            Random r = new Random();
            int t = r.Next(0, this.Width - 100);
            int t2 = r.Next(0, this.Height - 300);
            //btn.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            btn.Location = new Point(t, t2);
            btn.Name = "newbtn";
            btn.Size = new Size(50, 50);
            btn.TabIndex = 3;
            btn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
            btn.UseVisualStyleBackColor = true;
            Controls.Add(newbtn);
        }

        Button[] keyboard = new Button[26];

        void inputButtonMas() //вводим визуальную клавиатуру
        {
            string[] keyboardButtons = {"Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A",
                "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            int left = 4;
            for (int i = 0; i < 26; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 10) left = 4;
                else if (i == 19) left = 4;
                if (i < 10) keyboard[i].Location = new Point(0, 550);
                else if (i < 19) keyboard[i].Location = new Point(0, 600); //сложные и не очень процессы ввода кнопок
                else if (i < 26) keyboard[i].Location = new Point(0, 650);
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                base.Controls.Add(keyboard[i]);
            }
        }

        void checkButtonMas(string btn) //выделение нужной кнопки
        {
            for (int i = 0; i < 26; i++)
            {
                if (btn == keyboard[i].Text)
                {
                    keyboard[i].BackColor = Color.Orange;
                }
                else keyboard[i].BackColor = Color.White;
            }
        }
        private void FormSecondMode_KeyDown(object sender, KeyEventArgs e)
        {
            //checkButtonMas(newbtn.Text);
            if (e.KeyCode.ToString() == newbtn.Text)
            {
                cntHit++;
                newButton(newbtn);
                checkButtonMas(newbtn.Text);
            }
            else newbtn.BackColor = Color.Red;

            if (cntDown == 0) //вывод первой кнопки и визуальной клавиатуры
            {
                labelText.Visible = false;
                newButton(newbtn);
                inputButtonMas();
                checkButtonMas(newbtn.Text);
            }
            cntDown++;
            if (sw.Elapsed.Minutes >= 1) //вывод результатов
            {
                sw.Stop();
                MessageBox.Show($"Время: {sw.Elapsed.Minutes} минута\nКоличество нажатий: {cntDown}\nИз них попаданий: {cntHit}");
                this.Close();
            }
        }

    }
}
