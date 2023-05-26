namespace OrderBook.UI
{
    partial class XTradesHistoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XTradesHistoryForm));
            tradeHistoryDataGrid = new DataGridView();
            titleLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)tradeHistoryDataGrid).BeginInit();
            SuspendLayout();
            // 
            // tradeHistoryDataGrid
            // 
            tradeHistoryDataGrid.AllowUserToAddRows = false;
            tradeHistoryDataGrid.AllowUserToDeleteRows = false;
            tradeHistoryDataGrid.AllowUserToResizeRows = false;
            tradeHistoryDataGrid.BackgroundColor = Color.FromArgb(10, 13, 19);
            tradeHistoryDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            tradeHistoryDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            tradeHistoryDataGrid.Location = new Point(26, 108);
            tradeHistoryDataGrid.Name = "tradeHistoryDataGrid";
            tradeHistoryDataGrid.ReadOnly = true;
            tradeHistoryDataGrid.RowHeadersWidth = 49;
            tradeHistoryDataGrid.RowTemplate.Height = 28;
            tradeHistoryDataGrid.Size = new Size(708, 403);
            tradeHistoryDataGrid.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Appearance.Font = new Font("Tahoma", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Appearance.ForeColor = Color.White;
            titleLabel.Appearance.Options.UseFont = true;
            titleLabel.Appearance.Options.UseForeColor = true;
            titleLabel.Location = new Point(26, 37);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(130, 23);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Trade History";
            // 
            // XTradesHistoryForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 538);
            Controls.Add(titleLabel);
            Controls.Add(tradeHistoryDataGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Image = (Image)resources.GetObject("XTradesHistoryForm.IconOptions.Image");
            MaximizeBox = false;
            Name = "XTradesHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trade History";
            Load += XTradesHistory_Load;
            ((System.ComponentModel.ISupportInitialize)tradeHistoryDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tradeHistoryDataGrid;
        private DevExpress.XtraEditors.LabelControl titleLabel;
    }
}