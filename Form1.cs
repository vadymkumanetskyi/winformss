namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        TextBox textBox1;
        Button button1;
        Label label1;

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(20, 20);
            Controls.Add(textBox1);

            button1 = new Button();
            button1.Text = "Перевірити";
            button1.Location = new System.Drawing.Point(150, 18);
            button1.Click += button1_Click;
            Controls.Add(button1);

            label1 = new Label();
            label1.Location = new System.Drawing.Point(20, 60);
            label1.AutoSize = true;
            Controls.Add(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int grade;

            if (int.TryParse(textBox1.Text, out grade))
            {
                if (grade >= 1 && grade <= 3)
                    label1.Text = "Початковий рівень";
                else if (grade >= 4 && grade <= 6)
                    label1.Text = "Середній рівень";
                else if (grade >= 7 && grade <= 9)
                    label1.Text = "Достатній рівень";
                else if (grade >= 10 && grade <= 12)
                    label1.Text = "Високий рівень";
                else
                    MessageBox.Show("Помилка! Оцінка має бути від 1 до 12.");
            }
            else
            {
                MessageBox.Show("Помилка! Введіть число.");
            }
        }
    }
}
