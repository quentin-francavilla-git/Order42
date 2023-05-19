namespace OrderBook.UI
{
    partial class XOrderBookForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            orderBookBindingSource = new BindingSource(components);
            dataGridBids = new DataGridView();
            dataGridAsks = new DataGridView();
            asksLabel = new DevExpress.XtraEditors.LabelControl();
            bidsLabel = new DevExpress.XtraEditors.LabelControl();
            tickerDropDown = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAsks).BeginInit();
            SuspendLayout();
            // 
            // orderBookBindingSource
            // 
            orderBookBindingSource.DataSource = typeof(ViewModels.MainViewModel);
            // 
            // dataGridBids
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(102, 181, 85);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridBids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(26, 26, 24);
            dataGridViewCellStyle2.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 205, 51);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 46, 46);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(70, 205, 51);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridBids.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridBids.Location = new Point(457, 80);
            dataGridBids.Name = "dataGridBids";
            dataGridBids.RowHeadersWidth = 49;
            dataGridBids.RowTemplate.Height = 28;
            dataGridBids.Size = new Size(407, 252);
            dataGridBids.TabIndex = 0;
            // 
            // dataGridAsks
            // 
            dataGridAsks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAsks.Location = new Point(26, 80);
            dataGridAsks.Name = "dataGridAsks";
            dataGridAsks.RowHeadersWidth = 49;
            dataGridAsks.RowTemplate.Height = 28;
            dataGridAsks.Size = new Size(381, 252);
            dataGridAsks.TabIndex = 1;
            // 
            // asksLabel
            // 
            asksLabel.Location = new Point(26, 58);
            asksLabel.Name = "asksLabel";
            asksLabel.Size = new Size(26, 16);
            asksLabel.TabIndex = 2;
            asksLabel.Text = "Asks";
            // 
            // bidsLabel
            // 
            bidsLabel.Location = new Point(457, 58);
            bidsLabel.Name = "bidsLabel";
            bidsLabel.Size = new Size(23, 16);
            bidsLabel.TabIndex = 3;
            bidsLabel.Text = "Bids";
            // 
            // tickerDropDown
            // 
            tickerDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            tickerDropDown.FormattingEnabled = true;
            tickerDropDown.Location = new Point(355, 12);
            tickerDropDown.Name = "tickerDropDown";
            tickerDropDown.Size = new Size(145, 24);
            tickerDropDown.TabIndex = 5;
            tickerDropDown.SelectedIndexChanged += tickerDropDown_SelectedIndexChanged;
            // 
            // XOrderBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 359);
            Controls.Add(tickerDropDown);
            Controls.Add(bidsLabel);
            Controls.Add(asksLabel);
            Controls.Add(dataGridAsks);
            Controls.Add(dataGridBids);
            Name = "XOrderBookForm";
            Text = "XOrderBookForm";
            Load += XOrderBookForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBids).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAsks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource orderBookBindingSource;
        private DataGridView dataGridBids;
        private DataGridView dataGridAsks;
        private DevExpress.XtraEditors.LabelControl asksLabel;
        private DevExpress.XtraEditors.LabelControl bidsLabel;
        private ComboBox tickerDropDown;
    }
}