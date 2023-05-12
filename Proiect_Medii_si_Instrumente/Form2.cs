using System.Media;
using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label3.Hide();
            label4.Hide();
            LoadingMusic();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width >= 300 && panel2.Width <= 600)
            {
                label2.Hide();
                label3.Show();
            }
            if (panel2.Width >= 601 && panel2.Width <= 900)
            {
                label3.Hide();
                label4.Show();
            }
            if (panel2.Width == panel2.MaximumSize.Width)
            {
                timer1.Stop();
                Form3 finalForm = new Form3();
                this.Hide();
                finalForm.Show();
            }
        }

        private void LoadingMusic()
        {
            SoundPlayer loading = new SoundPlayer(@"C:\VS Projects\Proiect_Medii_si_Instrumente\loadingmusic.wav");
            loading.Play();
        }
    }
}
