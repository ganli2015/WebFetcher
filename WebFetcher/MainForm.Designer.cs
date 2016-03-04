namespace WebFetcher
{
    partial class MainForm
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
            this.button_fetch = new System.Windows.Forms.Button();
            this.listBox_Title = new System.Windows.Forms.ListBox();
            this.comboBox_WebSelect = new System.Windows.Forms.ComboBox();
            this.listBox_Content = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_fetch
            // 
            this.button_fetch.Location = new System.Drawing.Point(370, 355);
            this.button_fetch.Name = "button_fetch";
            this.button_fetch.Size = new System.Drawing.Size(75, 23);
            this.button_fetch.TabIndex = 0;
            this.button_fetch.Text = "获取";
            this.button_fetch.UseVisualStyleBackColor = true;
            this.button_fetch.Click += new System.EventHandler(this.button_fetch_Click);
            // 
            // listBox_Title
            // 
            this.listBox_Title.FormattingEnabled = true;
            this.listBox_Title.ItemHeight = 12;
            this.listBox_Title.Location = new System.Drawing.Point(13, 13);
            this.listBox_Title.Name = "listBox_Title";
            this.listBox_Title.Size = new System.Drawing.Size(335, 364);
            this.listBox_Title.TabIndex = 1;
            this.listBox_Title.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Title_MouseClick);
            this.listBox_Title.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MessageBox_MouseDoubleClick);
            // 
            // comboBox_WebSelect
            // 
            this.comboBox_WebSelect.FormattingEnabled = true;
            this.comboBox_WebSelect.Location = new System.Drawing.Point(354, 12);
            this.comboBox_WebSelect.Name = "comboBox_WebSelect";
            this.comboBox_WebSelect.Size = new System.Drawing.Size(99, 20);
            this.comboBox_WebSelect.TabIndex = 2;
            this.comboBox_WebSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_WebSelect_SelectedIndexChanged);
            // 
            // listBox_Content
            // 
            this.listBox_Content.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Content.FormattingEnabled = true;
            this.listBox_Content.ItemHeight = 19;
            this.listBox_Content.Location = new System.Drawing.Point(479, 13);
            this.listBox_Content.Name = "listBox_Content";
            this.listBox_Content.Size = new System.Drawing.Size(391, 365);
            this.listBox_Content.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 390);
            this.Controls.Add(this.listBox_Content);
            this.Controls.Add(this.comboBox_WebSelect);
            this.Controls.Add(this.listBox_Title);
            this.Controls.Add(this.button_fetch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "WebFetcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_fetch;
        private System.Windows.Forms.ListBox listBox_Title;
        private System.Windows.Forms.ComboBox comboBox_WebSelect;
        private System.Windows.Forms.ListBox listBox_Content;
    }
}







