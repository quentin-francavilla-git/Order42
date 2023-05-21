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
            actionLabel = new DevExpress.XtraEditors.LabelControl();
            quantityLabel = new DevExpress.XtraEditors.LabelControl();
            priceLabel = new DevExpress.XtraEditors.LabelControl();
            cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            amendOrderBtn = new DevExpress.XtraEditors.SimpleButton();
            placeBtn = new DevExpress.XtraEditors.SimpleButton();
            quantityTextBox = new TextBox();
            priceTextBox = new TextBox();
            actionDropDown = new ComboBox();
            entryOrderLabel = new DevExpress.XtraEditors.LabelControl();
            tickerLabel = new DevExpress.XtraEditors.LabelControl();
            SuspendLayout();
            // 
            // actionLabel
            // 
            actionLabel.Location = new Point(154, 87);
            actionLabel.Name = "actionLabel";
            actionLabel.Size = new Size(35, 16);
            actionLabel.TabIndex = 0;
            actionLabel.Text = "Action";
            // 
            // quantityLabel
            // 
            quantityLabel.Location = new Point(142, 173);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(47, 16);
            quantityLabel.TabIndex = 1;
            quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            priceLabel.Location = new Point(161, 132);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(28, 16);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Price";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(420, 236);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(108, 34);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel Order";
            // 
            // amendOrderBtn
            // 
            amendOrderBtn.Location = new Point(245, 236);
            amendOrderBtn.Name = "amendOrderBtn";
            amendOrderBtn.Size = new Size(108, 34);
            amendOrderBtn.TabIndex = 5;
            amendOrderBtn.Text = "Amend Order";
            amendOrderBtn.Click += amendOrderBtn_Click;
            // 
            // placeBtn
            // 
            placeBtn.Location = new Point(72, 236);
            placeBtn.Name = "placeBtn";
            placeBtn.Size = new Size(108, 34);
            placeBtn.TabIndex = 4;
            placeBtn.Text = "Place Order";
            placeBtn.Click += placeOrderBtn_Click;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(233, 166);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(120, 23);
            quantityTextBox.TabIndex = 3;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(233, 125);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(120, 23);
            priceTextBox.TabIndex = 2;
            // 
            // actionDropDown
            // 
            actionDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            actionDropDown.FormattingEnabled = true;
            actionDropDown.Location = new Point(233, 84);
            actionDropDown.Name = "actionDropDown";
            actionDropDown.Size = new Size(120, 24);
            actionDropDown.TabIndex = 1;
            // 
            // entryOrderLabel
            // 
            entryOrderLabel.Appearance.Font = new Font("Tahoma", 11.2695656F, FontStyle.Regular, GraphicsUnit.Point);
            entryOrderLabel.Appearance.Options.UseFont = true;
            entryOrderLabel.Location = new Point(161, 12);
            entryOrderLabel.Name = "entryOrderLabel";
            entryOrderLabel.Size = new Size(144, 22);
            entryOrderLabel.TabIndex = 9;
            entryOrderLabel.Text = "Entry an Order for";
            // 
            // tickerLabel
            // 
            tickerLabel.Appearance.Font = new Font("Tahoma", 11.2695656F, FontStyle.Bold, GraphicsUnit.Point);
            tickerLabel.Appearance.Options.UseFont = true;
            tickerLabel.Location = new Point(311, 12);
            tickerLabel.Name = "tickerLabel";
            tickerLabel.Size = new Size(78, 22);
            tickerLabel.TabIndex = 10;
            tickerLabel.Text = "{Ticker}";
            // 
            // XEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 370);
            Controls.Add(tickerLabel);
            Controls.Add(entryOrderLabel);
            Controls.Add(actionDropDown);
            Controls.Add(priceTextBox);
            Controls.Add(quantityTextBox);
            Controls.Add(placeBtn);
            Controls.Add(amendOrderBtn);
            Controls.Add(cancelBtn);
            Controls.Add(priceLabel);
            Controls.Add(quantityLabel);
            Controls.Add(actionLabel);
            Name = "XEntryForm";
            Text = "Entry Order";
            Load += XEntryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl actionLabel;
        private DevExpress.XtraEditors.LabelControl quantityLabel;
        private DevExpress.XtraEditors.LabelControl priceLabel;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton amendOrderBtn;
        private DevExpress.XtraEditors.SimpleButton placeBtn;
        private TextBox quantityTextBox;
        private TextBox priceTextBox;
        private ComboBox actionDropDown;
        private DevExpress.XtraEditors.LabelControl entryOrderLabel;
        private DevExpress.XtraEditors.LabelControl tickerLabel;
    }
}