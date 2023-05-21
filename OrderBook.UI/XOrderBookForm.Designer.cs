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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            orderBookBindingSource = new BindingSource(components);
            dataGridBids = new DataGridView();
            dataGridAsks = new DataGridView();
            asksLabel = new DevExpress.XtraEditors.LabelControl();
            bidsLabel = new DevExpress.XtraEditors.LabelControl();
            tickerDropDown = new ComboBox();
            tickerLabel = new DevExpress.XtraEditors.LabelControl();
            entryOrderbtn = new DevExpress.XtraEditors.SimpleButton();
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(95, 206, 72);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(127, 236, 104);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridBids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(95, 197, 73);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(102, 181, 85);
            dataGridViewCellStyle2.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridBids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(103, 227, 77);
            dataGridViewCellStyle3.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(127, 236, 104);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridBids.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridBids.Location = new Point(554, 109);
            dataGridBids.Name = "dataGridBids";
            dataGridBids.ReadOnly = true;
            dataGridBids.RowHeadersWidth = 49;
            dataGridBids.RowTemplate.Height = 28;
            dataGridBids.Size = new Size(468, 452);
            dataGridBids.TabIndex = 0;
            // 
            // dataGridAsks
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(218, 51, 51);
            dataGridAsks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridAsks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(233, 54, 54);
            dataGridViewCellStyle5.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(248, 87, 87);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridAsks.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridAsks.Location = new Point(26, 109);
            dataGridAsks.Name = "dataGridAsks";
            dataGridAsks.ReadOnly = true;
            dataGridAsks.RowHeadersWidth = 49;
            dataGridAsks.RowTemplate.Height = 28;
            dataGridAsks.Size = new Size(468, 452);
            dataGridAsks.TabIndex = 1;
            // 
            // asksLabel
            // 
            asksLabel.Location = new Point(26, 87);
            asksLabel.Name = "asksLabel";
            asksLabel.Size = new Size(26, 16);
            asksLabel.TabIndex = 2;
            asksLabel.Text = "Asks";
            // 
            // bidsLabel
            // 
            bidsLabel.Location = new Point(554, 87);
            bidsLabel.Name = "bidsLabel";
            bidsLabel.Size = new Size(23, 16);
            bidsLabel.TabIndex = 3;
            bidsLabel.Text = "Bids";
            // 
            // tickerDropDown
            // 
            tickerDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            tickerDropDown.FormattingEnabled = true;
            tickerDropDown.Location = new Point(26, 34);
            tickerDropDown.Name = "tickerDropDown";
            tickerDropDown.Size = new Size(145, 24);
            tickerDropDown.TabIndex = 5;
            tickerDropDown.SelectedIndexChanged += tickerDropDown_SelectedIndexChanged;
            // 
            // tickerLabel
            // 
            tickerLabel.Location = new Point(26, 12);
            tickerLabel.Name = "tickerLabel";
            tickerLabel.Size = new Size(35, 16);
            tickerLabel.TabIndex = 6;
            tickerLabel.Text = "Ticker";
            // 
            // entryOrderbtn
            // 
            entryOrderbtn.Location = new Point(206, 28);
            entryOrderbtn.Name = "entryOrderbtn";
            entryOrderbtn.Size = new Size(108, 34);
            entryOrderbtn.TabIndex = 7;
            entryOrderbtn.Text = "Entry Order";
            entryOrderbtn.Click += entryOrderbtn_Click;
            // 
            // XOrderBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 585);
            Controls.Add(entryOrderbtn);
            Controls.Add(tickerLabel);
            Controls.Add(tickerDropDown);
            Controls.Add(bidsLabel);
            Controls.Add(asksLabel);
            Controls.Add(dataGridAsks);
            Controls.Add(dataGridBids);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "XOrderBookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Book";
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
        private DevExpress.XtraEditors.LabelControl tickerLabel;
        private DevExpress.XtraEditors.SimpleButton entryOrderbtn;
    }
}