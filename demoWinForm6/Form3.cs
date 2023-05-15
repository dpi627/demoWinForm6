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
    /// <summary>
    /// 實現 DataGridView Row 拖曳
    /// </summary>
    public partial class Form3 : Form
    {
        private int dragIndex;
        private DataGridViewRow dragRow;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("AAA");
            dataGridView1.Rows.Add("BBB");
            dataGridView1.Rows.Add("CCC");

            // 假設你的 DataGridView 控制項名為 dataGridView1
            dataGridView1.AllowDrop = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DragDrop += DataGridView1_DragDrop;
            dataGridView1.DragEnter += DataGridView1_DragEnter;
            dataGridView1.MouseDown += DataGridView1_MouseDown;
            dataGridView1.MouseMove += DataGridView1_MouseMove;
        }

        private void DataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (dragIndex >= 0)
            {
                dragRow = dataGridView1.Rows[dragIndex];
                dataGridView1.DoDragDrop(dragRow, DragDropEffects.Move);
            }
        }

        private void DataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            int targetIndex = dataGridView1.HitTest(dataGridView1.PointToClient(new System.Drawing.Point(e.X, e.Y)).X, dataGridView1.PointToClient(new System.Drawing.Point(e.X, e.Y)).Y).RowIndex;
            if (targetIndex >= 0)
            {
                //DataGridViewRow targetRow = dataGridView1.Rows[targetIndex];
                dataGridView1.Rows.RemoveAt(dragIndex);
                dataGridView1.Rows.Insert(targetIndex, dragRow);
            }
        }

        private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragRow != null)
                    dataGridView1.DoDragDrop(dragRow, DragDropEffects.Move);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                Debug.WriteLine($"{row.Index} {row.Cells["FileName"].Value.ToString()}");
            }
        }
    }
}
