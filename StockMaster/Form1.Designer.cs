
namespace StockMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.openFileDialog_FindData = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel_FinamLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox_Path
            // 
            this.textBox_Path.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Path.Location = new System.Drawing.Point(12, 399);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.ReadOnly = true;
            this.textBox_Path.Size = new System.Drawing.Size(442, 20);
            this.textBox_Path.TabIndex = 0;
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(380, 425);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(75, 23);
            this.button_Browse.TabIndex = 1;
            this.button_Browse.Text = "Обзор";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добро пожаловать в программу StockMaster!\r\n\r\nДанное приложение было разработано д" +
    "ля технического \r\nанализа и построения графиков акций.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(191, 458);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(93, 23);
            this.button_Next.TabIndex = 3;
            this.button_Next.Text = "Продолжить";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Нажмите кнопку \"Обзор\" чтобы загрузить с компьютера файл для анализа.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Требования к загружаемому файлу:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(428, 193);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Найти и скачать необходимый файл с Интернета можно по";
            // 
            // linkLabel_FinamLink
            // 
            this.linkLabel_FinamLink.AutoSize = true;
            this.linkLabel_FinamLink.Location = new System.Drawing.Point(318, 129);
            this.linkLabel_FinamLink.Name = "linkLabel_FinamLink";
            this.linkLabel_FinamLink.Size = new System.Drawing.Size(45, 13);
            this.linkLabel_FinamLink.TabIndex = 8;
            this.linkLabel_FinamLink.TabStop = true;
            this.linkLabel_FinamLink.Text = "ссылке";
            this.linkLabel_FinamLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_FinamLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 493);
            this.Controls.Add(this.linkLabel_FinamLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.textBox_Path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "StockMaster - Загрузка данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog_FindData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel_FinamLink;
    }
}

