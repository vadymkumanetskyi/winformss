
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Button button1;
        Label label1;
        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }
        private void CreateControls()
        {
            button1 = new Button();
            button1.Text = "Показати дату і час";
            button1.Location = new System.Drawing.Point(20, 20);
            button1.Click += button1_Click;
            Controls.Add(button1);

            label1 = new Label();
            label1.Location = new System.Drawing.Point(20, 60);
            label1.AutoSize = true;
            Controls.Add(label1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }
}
