namespace Game
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.playground = new System.Windows.Forms.PictureBox();
            this.cube = new System.Windows.Forms.PictureBox();
            this.score_lable = new System.Windows.Forms.Label();
            this.points_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cube)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.player.Location = new System.Drawing.Point(277, 471);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(300, 50);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // playground
            // 
            this.playground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playground.BackColor = System.Drawing.Color.Black;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(784, 562);
            this.playground.TabIndex = 1;
            this.playground.TabStop = false;
            // 
            // cube
            // 
            this.cube.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cube.Location = new System.Drawing.Point(325, 170);
            this.cube.Name = "cube";
            this.cube.Size = new System.Drawing.Size(50, 50);
            this.cube.TabIndex = 2;
            this.cube.TabStop = false;
            this.cube.Visible = false;
            // 
            // score_lable
            // 
            this.score_lable.AutoSize = true;
            this.score_lable.BackColor = System.Drawing.Color.Black;
            this.score_lable.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_lable.ForeColor = System.Drawing.Color.White;
            this.score_lable.Location = new System.Drawing.Point(12, 9);
            this.score_lable.Name = "score_lable";
            this.score_lable.Size = new System.Drawing.Size(116, 42);
            this.score_lable.TabIndex = 3;
            this.score_lable.Text = "Score:";
            // 
            // points_label
            // 
            this.points_label.AutoSize = true;
            this.points_label.BackColor = System.Drawing.Color.Black;
            this.points_label.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.points_label.ForeColor = System.Drawing.Color.White;
            this.points_label.Location = new System.Drawing.Point(134, 9);
            this.points_label.Name = "points_label";
            this.points_label.Size = new System.Drawing.Size(37, 42);
            this.points_label.TabIndex = 4;
            this.points_label.Text = "0";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.cube);
            this.Controls.Add(this.points_label);
            this.Controls.Add(this.score_lable);
            this.Controls.Add(this.player);
            this.Controls.Add(this.playground);
            this.Name = "mainForm";
            this.Text = "High Five";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cube)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox playground;
        private System.Windows.Forms.PictureBox cube;
        private System.Windows.Forms.Label score_lable;
        private System.Windows.Forms.Label points_label;
    }
}

