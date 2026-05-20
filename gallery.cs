using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gallery
{
    public partial class Form1 : Form
    {
        private List<string> memePaths = new List<string>();
        // ²íäåêñ ïîòî÷íîãî ìåìó
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            LoadMemes();
            UpdateDisplay();
        }

        private void LoadMemes()
        {
            string folderPath = Path.Combine(Application.StartupPath, "memes");

            if (Directory.Exists(folderPath))
            {
                memePaths.AddRange(Directory.GetFiles(folderPath, "*.jpg"));
                memePaths.AddRange(Directory.GetFiles(folderPath, "*.png"));
                memePaths.AddRange(Directory.GetFiles(folderPath, "*.jpeg"));
            }

            
            if (memePaths.Count == 0)
            {
                MessageBox.Show("Äîäàé ìåìè ó ïàïêó 'memes'!");
            }
        }

        private void UpdateDisplay()
        {
            if (memePaths.Count > 0)
            {
                pictureBox1.Image = Image.FromFile(memePaths[currentIndex]);

                
                this.Text = $"Ìåì {currentIndex + 1} ³ç {memePaths.Count}";
            }
        }

        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            if (memePaths.Count == 0) return;

            // Çìåíøóºìî ³íäåêñ, ÿêùî íà ïî÷àòêó — éäåìî â ê³íåöü
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = memePaths.Count - 1;
            }
            UpdateDisplay();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (memePaths.Count == 0) return;

            // Çá³ëüøóºìî ³íäåêñ, ÿêùî ä³éøëè äî ê³íöÿ — ïåðåõîäèìî íà ïî÷àòîê
            currentIndex++;
            if (currentIndex >= memePaths.Count)
            {
                currentIndex = 0;
            }
            UpdateDisplay();
        }
    }
}
