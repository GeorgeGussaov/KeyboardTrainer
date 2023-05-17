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
            //Button[] keyboard = new Button[27];
            //int left = 0;
            //for (int i = 0; i < 27; i++)
            //{
            //    left++;
            //    keyboard[i] = new Button();
            //    if (i < 10) keyboard[i].Location = new Point(0, 280);
            //    else if (i == 10) left = 0;
            //    else if (i < 20) keyboard[i].Location = new Point(0, 330);
            //    else if (i == 20) left = 0;
            //    else if (i < 27) keyboard[i].Location = new Point(0, 380);
            //    keyboard[i].Left = left * 45 + 15;
            //    keyboard[i].Size = new Size(40, 40);
            //    base.Controls.Add(keyboard[i]);
            //}
        }

        Stopwatch sw = Stopwatch.StartNew(); //таймер

        void newButton(Button btn)
        {
            Random r = new Random();
            int t = r.Next(0, 450);
            int t2 = r.Next(0, 200);
            btn.Location = new Point(t, t2);
            btn.Name = "newbtn";
            btn.Size = new Size(50, 50);
            btn.TabIndex = 3;
            btn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
            btn.UseVisualStyleBackColor = true;
            Controls.Add(newbtn);
        }

        void inputButtonMas() //вводим визуальную клавиатуру
        {
            Button[] keyboard = new Button[26];
            string[] keyboardButtons = {"Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A",
                "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            int left = 0;
            for (int i = 0; i < 26; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 10) left = 0;
                if (i == 19) left = 0;
                if (i < 10) keyboard[i].Location = new Point(0, 280);
                else if (i < 19) keyboard[i].Location = new Point(0, 330);
                else if (i < 26) keyboard[i].Location = new Point(0, 380);
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                base.Controls.Add(keyboard[i]);
            }
        }
        private void FormSecondMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == newbtn.Text)
            {
                cntHit++;
                newButton(newbtn);
            }
            else newbtn.BackColor = Color.Red;
            if (cntDown == 0) //вывод первой кнопки и визуальной клавиатуры
            {
                labelText.Visible = false;
                newButton(newbtn);
                inputButtonMas();
            }
            cntDown++;
            if (sw.Elapsed.Minutes >= 1) //вывод результатов
            {
                sw.Stop();
                MessageBox.Show($"Время: {sw.Elapsed.Minutes}\nКоличество нажатий: {cntDown}\nИз них попаданий: {cntHit}");
            }
        }

    }
}
