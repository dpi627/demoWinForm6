using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoWinForm6
{
    public partial class frmChild : Form
    {
        public event EventHandler<int> ProgressReported;
        // 非同步
        public event EventHandler<int> ProgressChanged;

        public bool IsModify { get; set; } = false;

        public frmChild()
        {
            InitializeComponent();

            Thread.Sleep(1500);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsModify = !IsModify;
            MessageBox.Show(IsModify.ToString());
        }

        // 同步回報
        private void btnReportProgress_Click(object sender, EventArgs e)
        {
            // 模擬報告進度
            int progress = 0; // 假設進度為 50

            while (progress < 100)
            {
                var r = new Random().Next(10);
                Thread.Sleep(r * 100);
                progress += new Random().Next(r);

                if (progress >= 100) { progress = 100; }

                OnProgressReported(progress);
            }
        }

        protected virtual void OnProgressReported(int progress)
        {
            ProgressReported?.Invoke(this, progress);
        }

        // 非同步回報
        private void btnStart_Click(object sender, EventArgs e)
        {
            // 模擬長時間工作
            Task.Run(async () =>
            {
                // 模擬報告進度
                int progress = 0;
                ProgressChanged?.Invoke(this, progress);
                while (progress < 100)
                {
                    // 等待一段時間模擬長時間工作
                    await Task.Delay(new Random().Next(2) * 1000);
                    progress += new Random().Next(20);

                    if (progress >= 100) { progress = 100; }
                    // 觸發進度變化事件，傳遞當前進度值
                    ProgressChanged?.Invoke(this, progress);
                }
            });
        }
    }
}
