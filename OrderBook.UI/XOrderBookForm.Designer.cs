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
            refreshButton = new DevExpress.XtraEditors.SimpleButton();
            fromDatePicker = new DateTimePicker();
            toDatePicker = new DateTimePicker();
            fromLabel = new DevExpress.XtraEditors.LabelControl();
            toLabel = new DevExpress.XtraEditors.LabelControl();
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
            dataGridBids.AllowUserToAddRows = false;
            dataGridBids.AllowUserToDeleteRows = false;
            dataGridBids.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(95, 206, 72);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(127, 236, 104);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridBids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridBids.BackgroundColor = Color.FromArgb(10, 13, 19);
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
            dataGridBids.Location = new Point(656, 121);
            dataGridBids.Name = "dataGridBids";
            dataGridBids.ReadOnly = true;
            dataGridBids.RowHeadersWidth = 49;
            dataGridBids.RowTemplate.Height = 28;
            dataGridBids.Size = new Size(606, 452);
            dataGridBids.TabIndex = 0;
            // 
            // dataGridAsks
            // 
            dataGridAsks.AllowUserToAddRows = false;
            dataGridAsks.AllowUserToDeleteRows = false;
            dataGridAsks.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(218, 51, 51);
            dataGridAsks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridAsks.BackgroundColor = Color.FromArgb(10, 13, 19);
            dataGridAsks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(233, 54, 54);
            dataGridViewCellStyle5.Font = new Font("Tahoma", 8.139131F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(248, 87, 87);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridAsks.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridAsks.Location = new Point(29, 121);
            dataGridAsks.Name = "dataGridAsks";
            dataGridAsks.ReadOnly = true;
            dataGridAsks.RowHeadersWidth = 49;
            dataGridAsks.RowTemplate.Height = 28;
            dataGridAsks.Size = new Size(606, 452);
            dataGridAsks.TabIndex = 1;
            // 
            // asksLabel
            // 
            asksLabel.Appearance.ForeColor = Color.White;
            asksLabel.Appearance.Options.UseForeColor = true;
            asksLabel.Location = new Point(29, 99);
            asksLabel.Name = "asksLabel";
            asksLabel.Size = new Size(26, 16);
            asksLabel.TabIndex = 2;
            asksLabel.Text = "Asks";
            // 
            // bidsLabel
            // 
            bidsLabel.Appearance.ForeColor = Color.White;
            bidsLabel.Appearance.Options.UseForeColor = true;
            bidsLabel.Location = new Point(656, 99);
            bidsLabel.Name = "bidsLabel";
            bidsLabel.Size = new Size(23, 16);
            bidsLabel.TabIndex = 3;
            bidsLabel.Text = "Bids";
            // 
            // tickerDropDown
            // 
            tickerDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            tickerDropDown.FormattingEnabled = true;
            tickerDropDown.Location = new Point(49, 42);
            tickerDropDown.Name = "tickerDropDown";
            tickerDropDown.Size = new Size(145, 24);
            tickerDropDown.TabIndex = 5;
            tickerDropDown.SelectedIndexChanged += tickerDropDown_SelectedIndexChanged;
            // 
            // tickerLabel
            // 
            tickerLabel.Appearance.ForeColor = Color.White;
            tickerLabel.Appearance.Options.UseForeColor = true;
            tickerLabel.Location = new Point(49, 20);
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
            entryOrderbtn.Location = new Point(214, 32);
            entryOrderbtn.Name = "entryOrderbtn";
            entryOrderbtn.Size = new Size(108, 34);
            entryOrderbtn.TabIndex = 7;
            entryOrderbtn.Text = "Entry Order";
            entryOrderbtn.Click += entryOrderbtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(58, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(682, 100);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 15);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // refreshButton
            // 
            refreshButton.Appearance.BackColor = Color.FromArgb(33, 43, 65);
            refreshButton.Appearance.Options.UseBackColor = true;
            refreshButton.AppearanceHovered.BackColor = Color.FromArgb(45, 58, 88);
            refreshButton.AppearanceHovered.Options.UseBackColor = true;
            refreshButton.Location = new Point(328, 32);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(108, 34);
            refreshButton.TabIndex = 10;
            refreshButton.Text = "Refresh";
            refreshButton.Click += refreshButton_Click;
            // 
            // fromDatePicker
            // 
            fromDatePicker.CalendarForeColor = SystemColors.ActiveCaptionText;
            fromDatePicker.Format = DateTimePickerFormat.Short;
            fromDatePicker.Location = new Point(957, 62);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(94, 23);
            fromDatePicker.TabIndex = 11;
            fromDatePicker.Value = new DateTime(2017, 1, 31, 0, 0, 0, 0);
            fromDatePicker.ValueChanged += datePicker_ValueChanged;
            // 
            // toDatePicker
            // 
            toDatePicker.CalendarForeColor = SystemColors.ActiveCaptionText;
            toDatePicker.Format = DateTimePickerFormat.Short;
            toDatePicker.Location = new Point(1082, 62);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(94, 23);
            toDatePicker.TabIndex = 12;
            toDatePicker.Value = new DateTime(2024, 12, 25, 0, 0, 0, 0);
            toDatePicker.ValueChanged += datePicker_ValueChanged;
            // 
            // fromLabel
            // 
            fromLabel.Appearance.ForeColor = Color.White;
            fromLabel.Appearance.Options.UseForeColor = true;
            fromLabel.Location = new Point(957, 37);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(30, 16);
            fromLabel.TabIndex = 13;
            fromLabel.Text = "From";
            // 
            // toLabel
            // 
            toLabel.Appearance.ForeColor = Color.White;
            toLabel.Appearance.Options.UseForeColor = true;
            toLabel.Location = new Point(1082, 37);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(15, 16);
            toLabel.TabIndex = 14;
            toLabel.Text = "To";
            // 
            // XOrderBookForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 609);
            Controls.Add(toLabel);
            Controls.Add(fromLabel);
            Controls.Add(toDatePicker);
            Controls.Add(fromDatePicker);
            Controls.Add(refreshButton);
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
            Location = new Point(600, 150);
            MaximizeBox = false;
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
        private DevExpress.XtraEditors.SimpleButton refreshButton;
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
        private DevExpress.XtraEditors.LabelControl fromLabel;
        private DevExpress.XtraEditors.LabelControl toLabel;
    }
}