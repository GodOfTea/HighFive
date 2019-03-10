namespace SaveAndLoadForm
{
    partial class SavesForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.save_button = new System.Windows.Forms.Button();
            this.load_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(12, 12);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(140, 41);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // load_button
            // 
            this.load_button.Location = new System.Drawing.Point(12, 59);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(140, 41);
            this.load_button.TabIndex = 1;
            this.load_button.Text = "Load";
            this.load_button.UseVisualStyleBackColor = true;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // SavesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 115);
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.save_button);
            this.Name = "SavesForm";
            this.Text = "Saves";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button load_button;
    }
}

