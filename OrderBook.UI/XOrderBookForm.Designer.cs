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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XOrderBookForm));
            orderBookBindingSource = new BindingSource(components);
            dataGridBids = new DataGridView();
            dataGridAsks = new DataGridView();
            asksLabel = new DevExpress.XtraEditors.LabelControl();
            bidsLabel = new DevExpress.XtraEditors.LabelControl();
            tickerDropDown = new ComboBox();
            tickerLabel = new DevExpress.XtraEditors.LabelControl();
            entryOrderbtn = new DevExpress.XtraEditors.SimpleButton();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAsks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // orderBookBindingSource
            // 
            orderBookBindingSource.DataSource = typeof(ViewModels.MainViewModel);
            // 
            // dataGridBids
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(95, 206, 72);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(127, 236, 104);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridBids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridBids.BackgroundColor = Color.FromArgb(10, 13, 19);
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(95, 197, 73);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(102, 181, 85);
            dataGridViewCellStyle7.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridBids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(103, 227, 77);
            dataGridViewCellStyle8.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(127, 236, 104);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridBids.DefaultCellStyle = dataGridViewCellStyle8;
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
            dataGridViewCellStyle9.BackColor = Color.FromArgb(218, 51, 51);
            dataGridAsks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridAsks.BackgroundColor = Color.FromArgb(10, 13, 19);
            dataGridAsks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(233, 54, 54);
            dataGridViewCellStyle10.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(248, 87, 87);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dataGridAsks.DefaultCellStyle = dataGridViewCellStyle10;
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
            asksLabel.Appearance.ForeColor = Color.White;
            asksLabel.Appearance.Options.UseForeColor = true;
            asksLabel.Location = new Point(26, 87);
            asksLabel.Name = "asksLabel";
            asksLabel.Size = new Size(26, 16);
            asksLabel.TabIndex = 2;
            asksLabel.Text = "Asks";
            // 
            // bidsLabel
            // 
            bidsLabel.Appearance.ForeColor = Color.White;
            bidsLabel.Appearance.Options.UseForeColor = true;
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
            tickerLabel.Appearance.ForeColor = Color.White;
            tickerLabel.Appearance.Options.UseForeColor = true;
            tickerLabel.Location = new Point(26, 12);
            tickerLabel.Name = "tickerLabel";
            tickerLabel.Size = new Size(35, 16);
            tickerLabel.TabIndex = 6;
            tickerLabel.Text = "Ticker";
            // 
            // entryOrderbtn
            // 
            entryOrderbtn.Appearance.BackColor = Color.FromArgb(33, 43, 65);
            entryOrderbtn.Appearance.Options.UseBackColor = true;
            entryOrderbtn.AppearanceHovered.BackColor = Color.FromArgb(45, 58, 88);
            entryOrderbtn.AppearanceHovered.Options.UseBackColor = true;
            entryOrderbtn.Location = new Point(206, 28);
            entryOrderbtn.Name = "entryOrderbtn";
            entryOrderbtn.Size = new Size(108, 34);
            entryOrderbtn.TabIndex = 7;
            entryOrderbtn.Text = "Entry Order";
            entryOrderbtn.Click += entryOrderbtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(55, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(580, 88);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 15);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // XOrderBookForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 585);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(entryOrderbtn);
            Controls.Add(tickerLabel);
            Controls.Add(tickerDropDown);
            Controls.Add(bidsLabel);
            Controls.Add(asksLabel);
            Controls.Add(dataGridAsks);
            Controls.Add(dataGridBids);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Image = (Image)resources.GetObject("XOrderBookForm.IconOptions.Image");
            Location = new Point(700, 150);
            Name = "XOrderBookForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Order Book";
            Load += XOrderBookForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBids).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAsks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}