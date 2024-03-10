namespace zadacha_12_ShamilovaHayala
{
    partial class Form1
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
            this.StartOverButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartOverButton
            // 
            this.StartOverButton.BackColor = System.Drawing.Color.PowderBlue;
            this.StartOverButton.FlatAppearance.BorderSize = 0;
            this.StartOverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartOverButton.Font = new System.Drawing.Font("MV Boli", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartOverButton.Location = new System.Drawing.Point(614, 297);
            this.StartOverButton.Name = "StartOverButton";
            this.StartOverButton.Size = new System.Drawing.Size(168, 46);
            this.StartOverButton.TabIndex = 3;
            this.StartOverButton.Text = "Начать сначала";
            this.StartOverButton.UseVisualStyleBackColor = false;
            this.StartOverButton.Click += new System.EventHandler(this.StartOverButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.BackColor = System.Drawing.Color.PowderBlue;
            this.CheckButton.FlatAppearance.BorderSize = 0;
            this.CheckButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckButton.Font = new System.Drawing.Font("MV Boli", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckButton.Location = new System.Drawing.Point(614, 227);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(4);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(168, 46);
            this.CheckButton.TabIndex = 2;
            this.CheckButton.Text = "Проверить";
            this.CheckButton.UseVisualStyleBackColor = false;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 554);
            this.Controls.Add(this.StartOverButton);
            this.Controls.Add(this.CheckButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение судоку";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartOverButton;
        private System.Windows.Forms.Button CheckButton;
    }
}

