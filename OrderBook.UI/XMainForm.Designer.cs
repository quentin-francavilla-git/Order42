namespace OrderBook.UI
{
    partial class XMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMainForm));
            btnOpenOrderBookForm = new DevExpress.XtraEditors.SimpleButton();
            orderBookBindingSource = new BindingSource(components);
            labelTitle = new DevExpress.XtraEditors.LabelControl();
            pictureBox1 = new PictureBox();
            openTradeFormBtn = new DevExpress.XtraEditors.SimpleButton();
            separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            refreshAPI = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).BeginInit();
            SuspendLayout();
            // 
            // btnOpenOrderBookForm
            // 
            btnOpenOrderBookForm.Location = new Point(76, 103);
            btnOpenOrderBookForm.Name = "btnOpenOrderBookForm";
            btnOpenOrderBookForm.Size = new Size(189, 34);
            btnOpenOrderBookForm.TabIndex = 0;
            btnOpenOrderBookForm.Text = "Order Book";
            btnOpenOrderBookForm.Click += btnOpenOrderBookForm_Click;
            // 
            // labelTitle
            // 
            labelTitle.Appearance.Font = new Font("Tahoma", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Appearance.ForeColor = Color.White;
            labelTitle.Appearance.Options.UseFont = true;
            labelTitle.Appearance.Options.UseForeColor = true;
            labelTitle.Location = new Point(111, 26);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(142, 23);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Order Manager";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // openTradeFormBtn
            // 
            openTradeFormBtn.Location = new Point(76, 156);
            openTradeFormBtn.Name = "openTradeFormBtn";
            openTradeFormBtn.Size = new Size(189, 34);
            openTradeFormBtn.TabIndex = 3;
            openTradeFormBtn.Text = "Trade History";
            // 
            // separatorControl1
            // 
            separatorControl1.Location = new Point(28, 62);
            separatorControl1.Name = "separatorControl1";
            separatorControl1.Size = new Size(277, 28);
            separatorControl1.TabIndex = 4;
            // 
            // refreshAPI
            // 
            refreshAPI.Location = new Point(125, 209);
            refreshAPI.Name = "refreshAPI";
            refreshAPI.Size = new Size(82, 34);
            refreshAPI.TabIndex = 5;
            refreshAPI.Text = "Reconnect";
            refreshAPI.Click += refreshAPI_Click;
            // 
            // XMainForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 264);
            Controls.Add(refreshAPI);
            Controls.Add(openTradeFormBtn);
            Controls.Add(pictureBox1);
            Controls.Add(labelTitle);
            Controls.Add(btnOpenOrderBookForm);
            Controls.Add(separatorControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Image = (Image)resources.GetObject("XMainForm.IconOptions.Image");
            Name = "XMainForm";
            Text = "Order Manager";
            Load += XMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOpenOrderBookForm;
        private BindingSource orderBookBindingSource;
        private DevExpress.XtraEditors.LabelControl labelTitle;
        private PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton openTradeFormBtn;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SimpleButton refreshAPI;
    }
}