namespace OrderBook.UI
{
    partial class XEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XEntryForm));
            actionLabel = new DevExpress.XtraEditors.LabelControl();
            quantityLabel = new DevExpress.XtraEditors.LabelControl();
            priceLabel = new DevExpress.XtraEditors.LabelControl();
            cancelOrderBtn = new DevExpress.XtraEditors.SimpleButton();
            amendOrderBtn = new DevExpress.XtraEditors.SimpleButton();
            placeBtn = new DevExpress.XtraEditors.SimpleButton();
            quantityTextBox = new TextBox();
            priceTextBox = new TextBox();
            actionDropDown = new ComboBox();
            entryOrderLabel = new DevExpress.XtraEditors.LabelControl();
            tickerLabel = new DevExpress.XtraEditors.LabelControl();
            productTypeDropDown = new ComboBox();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            SuspendLayout();
            // 
            // actionLabel
            // 
            actionLabel.Appearance.ForeColor = Color.White;
            actionLabel.Appearance.Options.UseForeColor = true;
            actionLabel.Location = new Point(98, 89);
            actionLabel.Name = "actionLabel";
            actionLabel.Size = new Size(75, 16);
            actionLabel.TabIndex = 0;
            actionLabel.Text = "Product Type";
            // 
            // quantityLabel
            // 
            quantityLabel.Appearance.ForeColor = Color.White;
            quantityLabel.Appearance.Options.UseForeColor = true;
            quantityLabel.Location = new Point(117, 219);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(47, 16);
            quantityLabel.TabIndex = 1;
            quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            priceLabel.Appearance.ForeColor = Color.White;
            priceLabel.Appearance.Options.UseForeColor = true;
            priceLabel.Location = new Point(136, 178);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(28, 16);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Price";
            // 
            // cancelOrderBtn
            // 
            cancelOrderBtn.Appearance.BackColor = Color.FromArgb(242, 55, 57);
            cancelOrderBtn.Appearance.Options.UseBackColor = true;
            cancelOrderBtn.Location = new Point(348, 282);
            cancelOrderBtn.Name = "cancelOrderBtn";
            cancelOrderBtn.Size = new Size(108, 34);
            cancelOrderBtn.TabIndex = 6;
            cancelOrderBtn.Text = "Cancel Order";
            cancelOrderBtn.Click += cancelOrderBtn_Click;
            // 
            // amendOrderBtn
            // 
            amendOrderBtn.Appearance.BackColor = Color.FromArgb(242, 214, 55);
            amendOrderBtn.Appearance.Options.UseBackColor = true;
            amendOrderBtn.Location = new Point(215, 282);
            amendOrderBtn.Name = "amendOrderBtn";
            amendOrderBtn.Size = new Size(108, 34);
            amendOrderBtn.TabIndex = 5;
            amendOrderBtn.Text = "Amend Order";
            amendOrderBtn.Click += amendOrderBtn_Click;
            // 
            // placeBtn
            // 
            placeBtn.Appearance.BackColor = Color.FromArgb(54, 216, 59);
            placeBtn.Appearance.Options.UseBackColor = true;
            placeBtn.Location = new Point(76, 282);
            placeBtn.Name = "placeBtn";
            placeBtn.Size = new Size(108, 34);
            placeBtn.TabIndex = 4;
            placeBtn.Text = "Place Order";
            placeBtn.Click += placeOrderBtn_Click;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(208, 212);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(120, 23);
            quantityTextBox.TabIndex = 3;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(208, 171);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(120, 23);
            priceTextBox.TabIndex = 2;
            // 
            // actionDropDown
            // 
            actionDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            actionDropDown.FormattingEnabled = true;
            actionDropDown.Location = new Point(208, 129);
            actionDropDown.Name = "actionDropDown";
            actionDropDown.Size = new Size(120, 24);
            actionDropDown.TabIndex = 1;
            // 
            // entryOrderLabel
            // 
            entryOrderLabel.Appearance.Font = new Font("Tahoma", 11.2695656F, FontStyle.Regular, GraphicsUnit.Point);
            entryOrderLabel.Appearance.ForeColor = Color.White;
            entryOrderLabel.Appearance.Options.UseFont = true;
            entryOrderLabel.Appearance.Options.UseForeColor = true;
            entryOrderLabel.Location = new Point(154, 27);
            entryOrderLabel.Name = "entryOrderLabel";
            entryOrderLabel.Size = new Size(144, 22);
            entryOrderLabel.TabIndex = 9;
            entryOrderLabel.Text = "Entry an Order for";
            // 
            // tickerLabel
            // 
            tickerLabel.Appearance.Font = new Font("Tahoma", 11.2695656F, FontStyle.Bold, GraphicsUnit.Point);
            tickerLabel.Appearance.ForeColor = Color.Orange;
            tickerLabel.Appearance.Options.UseFont = true;
            tickerLabel.Appearance.Options.UseForeColor = true;
            tickerLabel.Location = new Point(304, 27);
            tickerLabel.Name = "tickerLabel";
            tickerLabel.Size = new Size(78, 22);
            tickerLabel.TabIndex = 10;
            tickerLabel.Text = "{Ticker}";
            // 
            // productTypeDropDown
            // 
            productTypeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            productTypeDropDown.FormattingEnabled = true;
            productTypeDropDown.Location = new Point(208, 86);
            productTypeDropDown.Name = "productTypeDropDown";
            productTypeDropDown.Size = new Size(120, 24);
            productTypeDropDown.TabIndex = 12;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Location = new Point(129, 132);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(35, 16);
            labelControl1.TabIndex = 11;
            labelControl1.Text = "Action";
            // 
            // XEntryForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 355);
            Controls.Add(productTypeDropDown);
            Controls.Add(labelControl1);
            Controls.Add(tickerLabel);
            Controls.Add(entryOrderLabel);
            Controls.Add(actionDropDown);
            Controls.Add(priceTextBox);
            Controls.Add(quantityTextBox);
            Controls.Add(placeBtn);
            Controls.Add(amendOrderBtn);
            Controls.Add(cancelOrderBtn);
            Controls.Add(priceLabel);
            Controls.Add(quantityLabel);
            Controls.Add(actionLabel);
            IconOptions.Image = (Image)resources.GetObject("XEntryForm.IconOptions.Image");
            Location = new Point(55, 100);
            MaximizeBox = false;
            Name = "XEntryForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Entry Order";
            Load += XEntryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl actionLabel;
        private DevExpress.XtraEditors.LabelControl quantityLabel;
        private DevExpress.XtraEditors.LabelControl priceLabel;
        private DevExpress.XtraEditors.SimpleButton cancelOrderBtn;
        private DevExpress.XtraEditors.SimpleButton amendOrderBtn;
        private DevExpress.XtraEditors.SimpleButton placeBtn;
        private TextBox quantityTextBox;
        private TextBox priceTextBox;
        private ComboBox actionDropDown;
        private DevExpress.XtraEditors.LabelControl entryOrderLabel;
        private DevExpress.XtraEditors.LabelControl tickerLabel;
        private ComboBox productTypeDropDown;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}