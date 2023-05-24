namespace OrderBook.UI
{
    partial class XTradesHistory
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
            dataGridView1 = new DataGridView();
            titleLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(10, 13, 19);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 49;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new Size(736, 418);
            dataGridView1.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Appearance.Font = new Font("Tahoma", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Appearance.ForeColor = Color.White;
            titleLabel.Appearance.Options.UseFont = true;
            titleLabel.Appearance.Options.UseForeColor = true;
            titleLabel.Location = new Point(48, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(70, 23);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "History";
            // 
            // XTradesHistory
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 538);
            Controls.Add(titleLabel);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "XTradesHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trades History";
            Load += XTradesHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DevExpress.XtraEditors.LabelControl titleLabel;
    }
}