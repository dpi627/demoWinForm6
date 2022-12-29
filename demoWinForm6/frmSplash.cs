using CircularProgressBar_NET5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demoWinForm6
{
    public partial class frmSplash : Form
    {
        Random r = new ();
        bool _IsCount = false;

        public frmSplash(bool isCount)
        {
            InitializeComponent();

            _IsCount = isCount;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            Width = BackgroundImage.Width;
            Height = BackgroundImage.Height;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Step = 1;
            circularProgressBar1.StartAngle = 270;
            circularProgressBar1.ForeColor = Color.FromArgb(210, 255, 255, 255);
            circularProgressBar1.ProgressColor = Color.FromArgb(210, 214, 118, 25);
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            if (_IsCount)
                timer1_Tick(sender, e);
            else
                LostFocus += CloseSpalsh;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            circularProgressBar1.Increment(r.Next(5, 7));
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == circularProgressBar1.Maximum)
            {
                timer1.Enabled = false;
                circularProgressBar1.Value = 100;
                Thread.Sleep(2000);
                Close();
            }
        }

        private void CloseSpalsh(object sender, EventArgs e) => Close();
        
    }
}
