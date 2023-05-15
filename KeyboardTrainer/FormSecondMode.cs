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


        private void FormSecondMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == newbtn.Text)
            {
                cntHit++;
                Random r = new Random();
                int t = r.Next(0, 700);
                int t2 = r.Next(0, 350);
                newbtn.Location = new Point(t, t2);
                //newbtn.Name = "newbtn";
                newbtn.Size = new Size(50, 50);
                //newbtn.TabIndex = 3;
                newbtn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
                //newbtn.UseVisualStyleBackColor = true;
                Controls.Add(newbtn);
            }
            if (cntDown == 0) //вывод первой кнопки
            {
                labelText.Visible = false;
                Random r = new Random();
                int t = r.Next(0, 700);
                int t2 = r.Next(0, 350);
                newbtn.Location = new Point(t, t2);
                //newbtn.Name = "newbtn";
                newbtn.Size = new Size(50, 50);
                newbtn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
                Controls.Add(newbtn);
            }
            cntDown++;
            MessageBox.Show(sw.Elapsed.Minutes.ToString());
            if (sw.Elapsed.Minutes >= 1) //вывод результатов
            {
                sw.Stop();
                MessageBox.Show("Время: " + sw.Elapsed.Seconds + "\nКоличество нажатий: " + cntDown + "\nИз них попаданий: " + cntHit);
            }
        }
    }
}
