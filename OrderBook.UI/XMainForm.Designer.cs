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
            openTradeFormBtn = new DevExpress.XtraEditors.SimpleButton();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnOpenOrderBookForm
            // 
            btnOpenOrderBookForm.Appearance.BackColor = Color.FromArgb(33, 43, 65);
            btnOpenOrderBookForm.Appearance.Options.UseBackColor = true;
            btnOpenOrderBookForm.AppearanceHovered.BackColor = Color.FromArgb(45, 58, 88);
            btnOpenOrderBookForm.AppearanceHovered.Options.UseBackColor = true;
            btnOpenOrderBookForm.Location = new Point(76, 123);
            btnOpenOrderBookForm.Name = "btnOpenOrderBookForm";
            btnOpenOrderBookForm.Size = new Size(189, 34);
            btnOpenOrderBookForm.TabIndex = 0;
            btnOpenOrderBookForm.Text = "Order Book";
            btnOpenOrderBookForm.Click += btnOpenOrderBookForm_Click;
            // 
            // openTradeFormBtn
            // 
            openTradeFormBtn.Appearance.BackColor = Color.FromArgb(33, 43, 65);
            openTradeFormBtn.Appearance.Options.UseBackColor = true;
            openTradeFormBtn.AppearanceHovered.BackColor = Color.FromArgb(45, 58, 88);
            openTradeFormBtn.AppearanceHovered.Options.UseBackColor = true;
            openTradeFormBtn.Location = new Point(76, 176);
            openTradeFormBtn.Name = "openTradeFormBtn";
            openTradeFormBtn.Size = new Size(189, 34);
            openTradeFormBtn.TabIndex = 3;
            openTradeFormBtn.Text = "Trade History";
            openTradeFormBtn.Click += openTradeFormBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(112, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(120, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(234, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // XMainForm
            // 
            Appearance.BackColor = Color.FromArgb(18, 23, 35);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 264);
            Controls.Add(pictureBox2);
            Controls.Add(openTradeFormBtn);
            Controls.Add(btnOpenOrderBookForm);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Image = (Image)resources.GetObject("XMainForm.IconOptions.Image");
            Location = new Point(250, 510);
            MaximizeBox = false;
            Name = "XMainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Order42 Client";
            Load += XMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOpenOrderBookForm;
        private BindingSource orderBookBindingSource;
        private DevExpress.XtraEditors.SimpleButton openTradeFormBtn;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}