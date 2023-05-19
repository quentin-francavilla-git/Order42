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
            btnOpenOrderBookForm = new DevExpress.XtraEditors.SimpleButton();
            orderBookBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnOpenOrderBookForm
            // 
            btnOpenOrderBookForm.Location = new Point(92, 95);
            btnOpenOrderBookForm.Name = "btnOpenOrderBookForm";
            btnOpenOrderBookForm.Size = new Size(189, 34);
            btnOpenOrderBookForm.TabIndex = 0;
            btnOpenOrderBookForm.Text = "Open new order book";
            btnOpenOrderBookForm.Click += btnOpenOrderBookForm_Click;
            // 
            // XMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 303);
            Controls.Add(btnOpenOrderBookForm);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "XMainForm";
            Text = "XMainForm";
            Load += XMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderBookBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOpenOrderBookForm;
        private BindingSource orderBookBindingSource;
    }
}