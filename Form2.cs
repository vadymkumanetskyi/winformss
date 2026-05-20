namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        TextBox textBox1, textBox2;
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

            textBox2 = new TextBox();
            textBox2.Location = new System.Drawing.Point(120, 20);
            Controls.Add(textBox2);

            button1 = new Button();
            button1.Text = "Помножити";
            button1.Location = new System.Drawing.Point(220, 18);
            button1.Click += button1_Click;
            Controls.Add(button1);

            label1 = new Label();
            label1.Location = new System.Drawing.Point(20, 60);
            label1.AutoSize = true;
            Controls.Add(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b;

            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b))
            {
                label1.Text = "Результат: " + (a * b).ToString();
            }
            else
            {
                MessageBox.Show("Помилка! Введіть правильні числа.");
            }
        }
    }
}
