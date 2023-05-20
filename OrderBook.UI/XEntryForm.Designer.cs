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
            amendBtn = new DevExpress.XtraEditors.SimpleButton();
            placeBtn = new DevExpress.XtraEditors.SimpleButton();
            quantityTextBox = new TextBox();
            priceTextBox = new TextBox();
            actionDropDown = new ComboBox();
            tickerLabel = new DevExpress.XtraEditors.LabelControl();
            tickerDropDown = new ComboBox();
            SuspendLayout();
            // 
            // actionLabel
            // 
            actionLabel.Location = new Point(154, 74);
            actionLabel.Name = "actionLabel";
            actionLabel.Size = new Size(35, 16);
            actionLabel.TabIndex = 0;
            actionLabel.Text = "Action";
            // 
            // quantityLabel
            // 
            quantityLabel.Location = new Point(142, 119);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(47, 16);
            quantityLabel.TabIndex = 1;
            quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            priceLabel.Location = new Point(161, 159);
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
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel Order";
            // 
            // amendBtn
            // 
            amendBtn.Location = new Point(245, 236);
            amendBtn.Name = "amendBtn";
            amendBtn.Size = new Size(108, 34);
            amendBtn.TabIndex = 4;
            amendBtn.Text = "Amend Order";
            // 
            // placeBtn
            // 
            placeBtn.Location = new Point(72, 236);
            placeBtn.Name = "placeBtn";
            placeBtn.Size = new Size(108, 34);
            placeBtn.TabIndex = 5;
            placeBtn.Text = "Place Order";
            placeBtn.Click += placeBtn_Click;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(233, 112);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(120, 23);
            quantityTextBox.TabIndex = 6;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(233, 152);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(120, 23);
            priceTextBox.TabIndex = 7;
            // 
            // actionDropDown
            // 
            actionDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            actionDropDown.FormattingEnabled = true;
            actionDropDown.Location = new Point(233, 71);
            actionDropDown.Name = "actionDropDown";
            actionDropDown.Size = new Size(120, 24);
            actionDropDown.TabIndex = 8;
            // 
            // tickerLabel
            // 
            tickerLabel.Location = new Point(154, 30);
            tickerLabel.Name = "tickerLabel";
            tickerLabel.Size = new Size(35, 16);
            tickerLabel.TabIndex = 9;
            tickerLabel.Text = "Ticker";
            // 
            // tickerDropDown
            // 
            tickerDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            tickerDropDown.FormattingEnabled = true;
            tickerDropDown.Location = new Point(233, 27);
            tickerDropDown.Name = "tickerDropDown";
            tickerDropDown.Size = new Size(120, 24);
            tickerDropDown.TabIndex = 10;
            // 
            // XEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 370);
            Controls.Add(tickerDropDown);
            Controls.Add(tickerLabel);
            Controls.Add(actionDropDown);
            Controls.Add(priceTextBox);
            Controls.Add(quantityTextBox);
            Controls.Add(placeBtn);
            Controls.Add(amendBtn);
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
        private DevExpress.XtraEditors.SimpleButton amendBtn;
        private DevExpress.XtraEditors.SimpleButton placeBtn;
        private TextBox quantityTextBox;
        private TextBox priceTextBox;
        private ComboBox actionDropDown;
        private DevExpress.XtraEditors.LabelControl tickerLabel;
        private ComboBox tickerDropDown;
    }
}