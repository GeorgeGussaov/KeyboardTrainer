using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTrainer
{
    public partial class FormModeSelection : Form
    {
        public FormModeSelection()
        {
            InitializeComponent();
        }

        private void buttonFirstMode_Click(object sender, EventArgs e)
        {
            FormFirstMode first = new FormFirstMode();
            this.Hide();
            first.ShowDialog();
            this.Show();
        }

        private void buttonSecondMode_Click(object sender, EventArgs e)
        {
            FormSecondMode second = new FormSecondMode();
            this.Hide();
            second.ShowDialog();
            this.Show();
        }
    }
}
