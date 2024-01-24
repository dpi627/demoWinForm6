using LoadingIndicator.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demoWinForm6
{
    public partial class FormLoading : Form
    {
        private LongOperation _longOperation;
        private FormLoadingText _load;

        public FormLoading()
        {
            InitializeComponent();
            _longOperation = new LongOperation(this);
            _load = new FormLoadingText();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _load.Show();
            await doSomething();
            _load.Close();

        }

        private async Task doSomething()
        {
            await Task.Run(() =>
            {
                // 在這裡執行您的任務
                for (int i = 0; i <= 100; i++)
                {
                    // 更新進度條
                    this.Invoke(new Action(() =>
                    {
                        if (!toolStripProgressBar1.IsDisposed)
                            toolStripProgressBar1.Value = i;
                    }));
                    Task.Delay(100).Wait();  // 假設的任務延遲
                }
            });

            if (!this.IsDisposed)
            {
                MessageBox.Show("任務完成！");
                button1.Enabled = true;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                await doSomething();
            }
        }
    }
}
