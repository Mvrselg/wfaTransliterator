namespace wfaLab1Transliterator
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
            this.btnFStart = new System.Windows.Forms.Button();
            this.tbFSource = new System.Windows.Forms.TextBox();
            this.tbFMessage = new System.Windows.Forms.TextBox();
            this.lblFSource = new System.Windows.Forms.Label();
            this.lblFMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFStart
            // 
            this.btnFStart.Location = new System.Drawing.Point(197, 189);
            this.btnFStart.Name = "btnFStart";
            this.btnFStart.Size = new System.Drawing.Size(75, 23);
            this.btnFStart.TabIndex = 0;
            this.btnFStart.Text = "Пуск";
            this.btnFStart.UseVisualStyleBackColor = true;
            // 
            // tbFSource
            // 
            this.tbFSource.Location = new System.Drawing.Point(12, 23);
            this.tbFSource.Multiline = true;
            this.tbFSource.Name = "tbFSource";
            this.tbFSource.Size = new System.Drawing.Size(456, 146);
            this.tbFSource.TabIndex = 1;
            // 
            // tbFMessage
            // 
            this.tbFMessage.Location = new System.Drawing.Point(12, 230);
            this.tbFMessage.Name = "tbFMessage";
            this.tbFMessage.Size = new System.Drawing.Size(456, 20);
            this.tbFMessage.TabIndex = 2;
            // 
            // lblFSource
            // 
            this.lblFSource.AutoSize = true;
            this.lblFSource.Location = new System.Drawing.Point(20, 10);
            this.lblFSource.Name = "lblFSource";
            this.lblFSource.Size = new System.Drawing.Size(89, 13);
            this.lblFSource.TabIndex = 3;
            this.lblFSource.Text = "Исходный текст";
            // 
            // lblFMessage
            // 
            this.lblFMessage.AutoSize = true;
            this.lblFMessage.Location = new System.Drawing.Point(19, 217);
            this.lblFMessage.Name = "lblFMessage";
            this.lblFMessage.Size = new System.Drawing.Size(65, 13);
            this.lblFMessage.TabIndex = 4;
            this.lblFMessage.Text = "Сообщения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 262);
            this.Controls.Add(this.lblFMessage);
            this.Controls.Add(this.lblFSource);
            this.Controls.Add(this.tbFMessage);
            this.Controls.Add(this.tbFSource);
            this.Controls.Add(this.btnFStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFStart;
        private System.Windows.Forms.TextBox tbFSource;
        private System.Windows.Forms.TextBox tbFMessage;
        private System.Windows.Forms.Label lblFSource;
        private System.Windows.Forms.Label lblFMessage;
    }
}

