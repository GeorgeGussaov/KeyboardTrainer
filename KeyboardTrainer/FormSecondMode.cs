using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

         void newButton(Button btn)
         {
            Random r = new Random();
            int t = r.Next(0, 700);
            int t2 = r.Next(0, 350);
            btn.Location = new Point(t, t2);
            btn.Name = "newbtn";
            btn.Size = new Size(50, 50);
            btn.TabIndex = 3;
            btn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
            btn.UseVisualStyleBackColor = true;
            Controls.Add(newbtn);
         }

        private void FormSecondMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == newbtn.Text)
            {
                cntHit++;
                newButton(newbtn);
            }
            else newbtn.BackColor = Color.Red;
            if (cntDown == 0) //вывод первой кнопки
            {
                labelText.Visible = false;
                newButton(newbtn);
            }
            cntDown++;
            if (sw.Elapsed.Minutes >= 1) //вывод результатов
            {
                sw.Stop();
                MessageBox.Show($"Время: { sw.Elapsed.Minutes}\nКоличество нажатий: {cntDown}\nИз них попаданий: { cntHit}");
            }
        }
    }
}
