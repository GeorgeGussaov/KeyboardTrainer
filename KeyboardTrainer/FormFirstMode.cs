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
            sr.Close();
            labelCurrentWord.Text = "Current word: " + labelText.Text.Split()[0];


        }
        Stopwatch sw = Stopwatch.StartNew();

        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            string[] s = labelText.Text.Split(new string[] {" " ,"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);//����� ����� � �����, � ���� �� ��� ��� ���, �� ��� ��������
            //string text = labelText.Text;
            if (textBoxTrainingField.Text.Split().Length > 1) //���������� ������ ����� ���������� �����, ������� ��������
            {
                if (s[check] + " " == textBoxTrainingField.Text) //�������� ����� �� ���������� � ������
                    check++;
                else
                {
                    cntErr++;                  //������� ������
                    labelCntError.Text = "Count errors: " + cntErr;
                }
                textBoxTrainingField.Text = "";
                if (check == s.Length)
                {
                    sw.Stop();
                    MessageBox.Show("����� ��: " + title + "\n���������� ������: " + cntErr + 
                        "\n������� ���������: " + sw.Elapsed + "\n������� ���-�� �������� � ������: " 
                        + labelText.Text.Length/((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds)/60));
                    this.Close();
                }
                else labelCurrentWord.Text = "Current word: " + s[check];
            }
        }

    }
}