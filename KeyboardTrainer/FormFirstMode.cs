using System.Diagnostics;

namespace KeyboardTrainer
{
    //1 - �������� ����
    //2 - ��������� ����
    //3 - ������������ �������
    //4 - ������� 2
    //5 - ������: ����������� �����������
    //6 - ����� � �������
    //7 - ������: ������
    //8 - ������������
    //9 - ������� ���
    //10 - �� ��� ������
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
            string[] ans = { "�������� ����", "��������� ����", "������������ �������", "������� 2: ������ �������", "������: ����������� �����������",
                "����� � �������", "������: ������", "������������", "������� ���", "�� ��� ������"};
            StreamReader sr = new StreamReader(text[ind]);
            title = ans[ind];
            labelText.Text = sr.ReadToEnd();
            sr.Close();                     //���� ��� ���� ������
            labelCurrentWord.Text = "������� �����: " + labelText.Text.Split()[0];
            s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            inputButtonMas();
        }


        Button[] keyboard = new Button[46];
        void inputButtonMas() //������ ���������� ����������
        {
            string[] keyboardButtons = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0","-","�", "�", "�", "�", "�", "�", "�", "�", "�", "�","�","�", "�",
                "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "shift", "�", "�", "�", "�", "�", "�", "�", "�", "�", ".", "space" };
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
                else if (i < 23) keyboard[i].Location = new Point(0, 350); //������� � �� ����� �������� ����� ������
                else if (i < 34) keyboard[i].Location = new Point(0, 400);
                else if (i < 45) keyboard[i].Location = new Point(0, 450);
                else
                {
                    keyboard[i].Location = new Point(0, 500);
                    keyboard[i].Text = keyboardButtons[i];
                    keyboard[i].Left = left * 45 + 15;
                    keyboard[i].Size = new Size(100, 40);                   //� ��� ��� ����� �������� ������
                    base.Controls.Add(keyboard[i]);
                    break;
                }
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                base.Controls.Add(keyboard[i]);
            }
        }


        Stopwatch sw = Stopwatch.StartNew(); //������
        //string[] s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            //string[] s = labelText.Text.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);//����� ����� � �����, � ���� �� ��� ��� ���, �� ��� ��������
            //string text = labelText.Text;
            if (textBoxTrainingField.Text.Split().Length > 1) //���������� ������ ����� ���������� �����, ������� ��������
            {
                if (s[check] + " " == textBoxTrainingField.Text) //�������� ����� �� ���������� � ������
                    check++;
                else
                {
                    cntErr++;                  //������� ������
                    labelCntError.Text = "���������� ������: " + cntErr;
                }
                textBoxTrainingField.Text = "";
                if (check == s.Length)
                {
                    sw.Stop();
                    MessageBox.Show("����� ��: " + title + "\n���������� ������: " + cntErr +
                        "\n������� ���������: " + sw.Elapsed + "\n������� ���-�� �������� � ������: "
                        + labelText.Text.Length / ((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds) / 60)); //������ ����������, ������� ���������� �������� � ������
                    this.Close();
                }
                else labelCurrentWord.Text = "������� �����: " + s[check];
            }
        }

    }
}