using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form1 : Form
    {
        bool sidebarExpand = true;
        bool sidebar2Expand = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, System.EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                    sidebarTimer2.Start();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                    if (sidebar2Expand)
                    {
                        sidebarTimer2.Start();

                    }
                }
            }
        }

        private void amcontButton_Click(object sender, System.EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void inapoiButton_Click(object sender, System.EventArgs e)
        {
            sidebarTimer2.Start();
        }

        private void sidebarTimer2_Tick(object sender, System.EventArgs e)
        {
            if (sidebar2Expand)
            {
                sidebarLeft.Width -= 10;
                if (sidebarLeft.Width == sidebarLeft.MinimumSize.Width)
                {
                    sidebar2Expand = false;
                    sidebarTimer2.Stop();
                    sidebarTimer.Start();
                }
            }
            else
            {
                sidebarLeft.Width += 10;
                if (sidebarLeft.Width == sidebarLeft.MaximumSize.Width)
                {
                    sidebar2Expand = true;
                    sidebarTimer2.Stop();
                }
            }
        }
    }
}
