using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form5 : Form
    {
        public Form5(string link)
        {
            InitializeComponent();
            string html = "<html><head>";
            html += "<meta content= 'IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src='https://www.youtube.com/embed/{0}' width='800' height='450' frameborder='0' allowfullscreen></iframe>";
            html += "</head></html>";
            this.webVideo.DocumentText = string.Format(html, link.Split('=')[1]);
        }
    }
}
