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
    /// <summary>
    /// 載入子表單，判斷是否已修改
    /// 非同步載入子表單，避免表單過大，載入時顯示動畫
    /// </summary>
    public partial class Form4 : Form
    {
        private frmChild frm;

        public Form4()
        {
            InitializeComponent();
        }

        private void ChildForm_ProgressReported(object sender, int progress)
        {
            // 更新進度條
            progressBar1.Value = progress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 確認只有一個 frmChild 的實例
            if (frm == null || frm.IsDisposed)
            {
                frm = new frmChild();
            }

            frm.ProgressReported += ChildForm_ProgressReported;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            //panel1.Controls.Clear();
            ClearPanelControls();
            panel1.Controls.Add(frm);

            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            ClearPanelControls();
        }

        private void ClearPanelControls()
        {
            if (panel1.Controls.Contains(frm) && frm.IsModify)
            {
                MessageBox.Show("Child Form has been modified.");
                return;
            }

            panel1.Controls.Clear();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // 顯示讀取動畫
            ShowLoadingAnimation();

            // 使用背景工作執行讀取過程
            await Task.Run(() =>
            {
                //// 模擬長時間讀取
                //Thread.Sleep(1000);

                //// 創建子表單並顯示
                //frmChild frm = new frmChild();
                //frm.ShowDialog();

                var frmLoaded = LoadForm<frmChild>(ref frm);

                // 在主執行緒上進行 UI 相關的操作
                panel1.Invoke((Action)(() =>
                {
                    // 在這裡進行 UI 相關的修改
                    // 例如更新控制項的內容、設置控制項的屬性等
                    panel1.Controls.Add(frmLoaded);
                    frmLoaded.Show();
                }));
            });

            // 隱藏讀取動畫
            HideLoadingAnimation();
        }

        private void ShowLoadingAnimation()
        {
            // 設定讀取動畫的可見性為 true，這裡假設讀取動畫是名為 loadingAnimation 的 PictureBox 控制項
            pictureBox1.Visible = true;
        }

        private void HideLoadingAnimation()
        {
            // 設定讀取動畫的可見性為 false，隱藏讀取動畫
            pictureBox1.Visible = false;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // 顯示讀取動畫
            ShowLoadingAnimation();

            // 使用背景工作執行讀取過程
            await Task.Run(() =>
            {
                var frmLoaded = LoadForm(ref frm);
                frmLoaded.ProgressChanged += ChildForm_ProgressChanged;
                // 在主執行緒上進行 UI 相關的操作
                panel1.Invoke(() =>
                {
                    // 在這裡進行 UI 相關的修改
                    // 例如更新控制項的內容、設置控制項的屬性等
                    panel1.Controls.Add(frmLoaded);
                    frmLoaded.Show();
                });
            });

            // 隱藏讀取動畫
            HideLoadingAnimation();
        }

        private void ChildForm_ProgressChanged(object sender, int progress)
        {
            // 在 UI 執行緒上更新進度條的值
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int>(UpdateProgressBarValue), progress);
            }
            else
            {
                UpdateProgressBarValue(progress);
            }
        }

        private void UpdateProgressBarValue(int value)
        {
            progressBar1.Value = value;
        }

        // 載入表單，包含判斷是否已存在
        public T LoadForm<T>(ref T frm) where T : Form, new()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new T();
            }

            frm.TopLevel = false;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            return frm;
        }

    }
}
