namespace nsLexMainForm
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
            this.lblFMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.but_search = new System.Windows.Forms.Button();
            this.but_delete = new System.Windows.Forms.Button();
            this.SyntTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnFStart
            // 
            this.btnFStart.Location = new System.Drawing.Point(12, 131);
            this.btnFStart.Name = "btnFStart";
            this.btnFStart.Size = new System.Drawing.Size(456, 37);
            this.btnFStart.TabIndex = 0;
            this.btnFStart.Text = "Проверить";
            this.btnFStart.UseVisualStyleBackColor = true;
            this.btnFStart.Click += new System.EventHandler(this.btnFStart_Click);
            // 
            // tbFSource
            // 
            this.tbFSource.AcceptsReturn = true;
            this.tbFSource.AcceptsTab = true;
            this.tbFSource.Location = new System.Drawing.Point(12, 23);
            this.tbFSource.Multiline = true;
            this.tbFSource.Name = "tbFSource";
            this.tbFSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFSource.Size = new System.Drawing.Size(456, 102);
            this.tbFSource.TabIndex = 1;
            this.tbFSource.TextChanged += new System.EventHandler(this.tbfSource_TextChanged);
            // 
            // tbFMessage
            // 
            this.tbFMessage.Location = new System.Drawing.Point(12, 187);
            this.tbFMessage.Name = "tbFMessage";
            this.tbFMessage.Size = new System.Drawing.Size(456, 20);
            this.tbFMessage.TabIndex = 2;
            // 
            // lblFMessage
            // 
            this.lblFMessage.AutoSize = true;
            this.lblFMessage.Location = new System.Drawing.Point(12, 171);
            this.lblFMessage.Name = "lblFMessage";
            this.lblFMessage.Size = new System.Drawing.Size(59, 13);
            this.lblFMessage.TabIndex = 4;
            this.lblFMessage.Text = "Результат";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Первое слово";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Третье слово";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 273);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(146, 95);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(164, 272);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(132, 95);
            this.listBox2.TabIndex = 7;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(302, 272);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(132, 95);
            this.listBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Второе слово";
            // 
            // but_search
            // 
            this.but_search.Location = new System.Drawing.Point(187, 213);
            this.but_search.Name = "but_search";
            this.but_search.Size = new System.Drawing.Size(85, 35);
            this.but_search.TabIndex = 8;
            this.but_search.Text = "Найти";
            this.but_search.UseVisualStyleBackColor = true;
            this.but_search.Click += new System.EventHandler(this.but_search_Click);
            // 
            // but_delete
            // 
            this.but_delete.Location = new System.Drawing.Point(330, 213);
            this.but_delete.Name = "but_delete";
            this.but_delete.Size = new System.Drawing.Size(82, 35);
            this.but_delete.TabIndex = 9;
            this.but_delete.Text = "Удалить";
            this.but_delete.UseVisualStyleBackColor = true;
            this.but_delete.Click += new System.EventHandler(this.but_delete_Click);
            // 
            // SyntTree
            // 
            this.SyntTree.Location = new System.Drawing.Point(604, 23);
            this.SyntTree.Name = "SyntTree";
            this.SyntTree.Size = new System.Drawing.Size(308, 254);
            this.SyntTree.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 381);
            this.Controls.Add(this.SyntTree);
            this.Controls.Add(this.but_delete);
            this.Controls.Add(this.but_search);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFMessage);
            this.Controls.Add(this.tbFMessage);
            this.Controls.Add(this.tbFSource);
            this.Controls.Add(this.btnFStart);
            this.Name = "Form1";
            this.Text = "Отладка транслитератора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFStart;
        private System.Windows.Forms.TextBox tbFSource;
        private System.Windows.Forms.TextBox tbFMessage;
        private System.Windows.Forms.Label lblFMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_search;
        private System.Windows.Forms.Button but_delete;
        private System.Windows.Forms.TreeView SyntTree;
    }
}

