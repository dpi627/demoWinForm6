namespace demoWinForm6
{
    partial class frmChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            btnReportProgress = new Button();
            btnStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(368, 205);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Child";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnReportProgress
            // 
            btnReportProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReportProgress.Location = new Point(632, 415);
            btnReportProgress.Name = "btnReportProgress";
            btnReportProgress.Size = new Size(75, 23);
            btnReportProgress.TabIndex = 2;
            btnReportProgress.Text = "report";
            btnReportProgress.UseVisualStyleBackColor = true;
            btnReportProgress.Click += btnReportProgress_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.Location = new Point(521, 415);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(105, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "reportAsync";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // frmChild
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(btnReportProgress);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "frmChild";
            Text = "frmChild";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button btnReportProgress;
        private Button btnStart;
    }
}