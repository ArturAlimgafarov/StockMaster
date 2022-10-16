
namespace StockMaster
{
    partial class Form3
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
            this.domainUpDown_IndicatorName = new System.Windows.Forms.DomainUpDown();
            this.numericUpDown_N = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label_SD = new System.Windows.Forms.Label();
            this.numericUpDown_SD = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_HighLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_LowLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_InvLowLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_InvHighLevel = new System.Windows.Forms.NumericUpDown();
            this.label_HighLevel = new System.Windows.Forms.Label();
            this.label_LowLevel = new System.Windows.Forms.Label();
            this.numericUpDown_Thickness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.domainUpDown_LineColor = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Color = new System.Windows.Forms.Button();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.checkBox_ShowSignals = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_N)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HighLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LowLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InvLowLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InvHighLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Thickness)).BeginInit();
            this.SuspendLayout();
            // 
            // domainUpDown_IndicatorName
            // 
            this.domainUpDown_IndicatorName.BackColor = System.Drawing.Color.White;
            this.domainUpDown_IndicatorName.Items.Add("Сглаженная скользящая средняя (SMA)");
            this.domainUpDown_IndicatorName.Items.Add("Экспоненциальная скользящая средняя (EMA)");
            this.domainUpDown_IndicatorName.Items.Add("Полосы Боллинджера (Bollinger Bands)");
            this.domainUpDown_IndicatorName.Items.Add("Индекс относительной силы (RSI)");
            this.domainUpDown_IndicatorName.Items.Add("Индекс денежных потоков (Money Flow Index)");
            this.domainUpDown_IndicatorName.Items.Add("Процентный диапазон Уильямса (Williams %R)");
            this.domainUpDown_IndicatorName.Items.Add("Осциллятор \"Момент\" (Momentum)");
            this.domainUpDown_IndicatorName.Location = new System.Drawing.Point(12, 12);
            this.domainUpDown_IndicatorName.Name = "domainUpDown_IndicatorName";
            this.domainUpDown_IndicatorName.ReadOnly = true;
            this.domainUpDown_IndicatorName.Size = new System.Drawing.Size(301, 20);
            this.domainUpDown_IndicatorName.TabIndex = 0;
            this.domainUpDown_IndicatorName.Text = "Сглаженная скользящая средняя (SMA)";
            this.domainUpDown_IndicatorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown_IndicatorName.SelectedItemChanged += new System.EventHandler(this.domainUpDown_IndicatorName_SelectedItemChanged);
            // 
            // numericUpDown_N
            // 
            this.numericUpDown_N.BackColor = System.Drawing.Color.White;
            this.numericUpDown_N.Location = new System.Drawing.Point(12, 63);
            this.numericUpDown_N.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_N.Name = "numericUpDown_N";
            this.numericUpDown_N.ReadOnly = true;
            this.numericUpDown_N.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_N.TabIndex = 2;
            this.numericUpDown_N.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_N.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Период расчёта";
            // 
            // label_SD
            // 
            this.label_SD.AutoSize = true;
            this.label_SD.Location = new System.Drawing.Point(180, 47);
            this.label_SD.Name = "label_SD";
            this.label_SD.Size = new System.Drawing.Size(136, 13);
            this.label_SD.TabIndex = 4;
            this.label_SD.Text = "Число станд. отклонений";
            this.label_SD.Visible = false;
            // 
            // numericUpDown_SD
            // 
            this.numericUpDown_SD.BackColor = System.Drawing.Color.White;
            this.numericUpDown_SD.Location = new System.Drawing.Point(183, 63);
            this.numericUpDown_SD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_SD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_SD.Name = "numericUpDown_SD";
            this.numericUpDown_SD.ReadOnly = true;
            this.numericUpDown_SD.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_SD.TabIndex = 5;
            this.numericUpDown_SD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_SD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_SD.Visible = false;
            // 
            // numericUpDown_HighLevel
            // 
            this.numericUpDown_HighLevel.BackColor = System.Drawing.Color.White;
            this.numericUpDown_HighLevel.Location = new System.Drawing.Point(12, 169);
            this.numericUpDown_HighLevel.Name = "numericUpDown_HighLevel";
            this.numericUpDown_HighLevel.ReadOnly = true;
            this.numericUpDown_HighLevel.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_HighLevel.TabIndex = 6;
            this.numericUpDown_HighLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_HighLevel.Visible = false;
            // 
            // numericUpDown_LowLevel
            // 
            this.numericUpDown_LowLevel.BackColor = System.Drawing.Color.White;
            this.numericUpDown_LowLevel.Location = new System.Drawing.Point(183, 169);
            this.numericUpDown_LowLevel.Name = "numericUpDown_LowLevel";
            this.numericUpDown_LowLevel.ReadOnly = true;
            this.numericUpDown_LowLevel.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_LowLevel.TabIndex = 7;
            this.numericUpDown_LowLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_LowLevel.Visible = false;
            // 
            // numericUpDown_InvLowLevel
            // 
            this.numericUpDown_InvLowLevel.BackColor = System.Drawing.Color.White;
            this.numericUpDown_InvLowLevel.Location = new System.Drawing.Point(183, 169);
            this.numericUpDown_InvLowLevel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvLowLevel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvLowLevel.Name = "numericUpDown_InvLowLevel";
            this.numericUpDown_InvLowLevel.ReadOnly = true;
            this.numericUpDown_InvLowLevel.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_InvLowLevel.TabIndex = 9;
            this.numericUpDown_InvLowLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_InvLowLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvLowLevel.Visible = false;
            // 
            // numericUpDown_InvHighLevel
            // 
            this.numericUpDown_InvHighLevel.BackColor = System.Drawing.Color.White;
            this.numericUpDown_InvHighLevel.Location = new System.Drawing.Point(12, 169);
            this.numericUpDown_InvHighLevel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvHighLevel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvHighLevel.Name = "numericUpDown_InvHighLevel";
            this.numericUpDown_InvHighLevel.ReadOnly = true;
            this.numericUpDown_InvHighLevel.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_InvHighLevel.TabIndex = 8;
            this.numericUpDown_InvHighLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_InvHighLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_InvHighLevel.Visible = false;
            // 
            // label_HighLevel
            // 
            this.label_HighLevel.AutoSize = true;
            this.label_HighLevel.Location = new System.Drawing.Point(12, 153);
            this.label_HighLevel.Name = "label_HighLevel";
            this.label_HighLevel.Size = new System.Drawing.Size(110, 13);
            this.label_HighLevel.TabIndex = 10;
            this.label_HighLevel.Text = "Верхний уровень (%)";
            this.label_HighLevel.Visible = false;
            // 
            // label_LowLevel
            // 
            this.label_LowLevel.AutoSize = true;
            this.label_LowLevel.Location = new System.Drawing.Point(180, 153);
            this.label_LowLevel.Name = "label_LowLevel";
            this.label_LowLevel.Size = new System.Drawing.Size(108, 13);
            this.label_LowLevel.TabIndex = 11;
            this.label_LowLevel.Text = "Нижний уровень (%)";
            this.label_LowLevel.Visible = false;
            // 
            // numericUpDown_Thickness
            // 
            this.numericUpDown_Thickness.BackColor = System.Drawing.Color.White;
            this.numericUpDown_Thickness.Location = new System.Drawing.Point(183, 115);
            this.numericUpDown_Thickness.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_Thickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Thickness.Name = "numericUpDown_Thickness";
            this.numericUpDown_Thickness.ReadOnly = true;
            this.numericUpDown_Thickness.Size = new System.Drawing.Size(130, 20);
            this.numericUpDown_Thickness.TabIndex = 12;
            this.numericUpDown_Thickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Thickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Толщина линии";
            // 
            // domainUpDown_LineColor
            // 
            this.domainUpDown_LineColor.BackColor = System.Drawing.Color.White;
            this.domainUpDown_LineColor.Items.Add("белый");
            this.domainUpDown_LineColor.Items.Add("жёлтый");
            this.domainUpDown_LineColor.Items.Add("оранжевый");
            this.domainUpDown_LineColor.Items.Add("зелёный");
            this.domainUpDown_LineColor.Items.Add("красный");
            this.domainUpDown_LineColor.Items.Add("синий");
            this.domainUpDown_LineColor.Items.Add("фиолетовый");
            this.domainUpDown_LineColor.Items.Add("голубой");
            this.domainUpDown_LineColor.Location = new System.Drawing.Point(12, 115);
            this.domainUpDown_LineColor.Name = "domainUpDown_LineColor";
            this.domainUpDown_LineColor.ReadOnly = true;
            this.domainUpDown_LineColor.Size = new System.Drawing.Size(130, 20);
            this.domainUpDown_LineColor.TabIndex = 14;
            this.domainUpDown_LineColor.Text = "жёлтый";
            this.domainUpDown_LineColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown_LineColor.SelectedItemChanged += new System.EventHandler(this.domainUpDown_LineColor_SelectedItemChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Цвет линии";
            // 
            // button_Color
            // 
            this.button_Color.BackColor = System.Drawing.Color.Yellow;
            this.button_Color.Enabled = false;
            this.button_Color.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Color.Location = new System.Drawing.Point(93, 102);
            this.button_Color.Name = "button_Color";
            this.button_Color.Size = new System.Drawing.Size(49, 10);
            this.button_Color.TabIndex = 16;
            this.button_Color.Text = "button1";
            this.button_Color.UseVisualStyleBackColor = false;
            // 
            // textBox_Info
            // 
            this.textBox_Info.BackColor = System.Drawing.Color.White;
            this.textBox_Info.Location = new System.Drawing.Point(12, 246);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ReadOnly = true;
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(301, 163);
            this.textBox_Info.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Информация";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(157, 415);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 19;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Visible = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(238, 415);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 20;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(157, 415);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 21;
            this.button_Apply.Text = "Применить";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Visible = false;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // checkBox_ShowSignals
            // 
            this.checkBox_ShowSignals.AutoSize = true;
            this.checkBox_ShowSignals.Checked = true;
            this.checkBox_ShowSignals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ShowSignals.Location = new System.Drawing.Point(12, 205);
            this.checkBox_ShowSignals.Name = "checkBox_ShowSignals";
            this.checkBox_ShowSignals.Size = new System.Drawing.Size(134, 17);
            this.checkBox_ShowSignals.TabIndex = 22;
            this.checkBox_ShowSignals.Text = "Отображать сигналы";
            this.checkBox_ShowSignals.UseVisualStyleBackColor = true;
            this.checkBox_ShowSignals.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 444);
            this.Controls.Add(this.checkBox_ShowSignals);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.button_Color);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.domainUpDown_LineColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_Thickness);
            this.Controls.Add(this.label_LowLevel);
            this.Controls.Add(this.label_HighLevel);
            this.Controls.Add(this.numericUpDown_InvLowLevel);
            this.Controls.Add(this.numericUpDown_InvHighLevel);
            this.Controls.Add(this.numericUpDown_LowLevel);
            this.Controls.Add(this.numericUpDown_HighLevel);
            this.Controls.Add(this.numericUpDown_SD);
            this.Controls.Add(this.label_SD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_N);
            this.Controls.Add(this.domainUpDown_IndicatorName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.Text = "Добавление индикатора";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_N)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HighLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LowLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InvLowLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InvHighLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Thickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown domainUpDown_IndicatorName;
        private System.Windows.Forms.NumericUpDown numericUpDown_N;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_SD;
        private System.Windows.Forms.NumericUpDown numericUpDown_SD;
        private System.Windows.Forms.NumericUpDown numericUpDown_HighLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown_LowLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown_InvLowLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown_InvHighLevel;
        private System.Windows.Forms.Label label_HighLevel;
        private System.Windows.Forms.Label label_LowLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown_Thickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DomainUpDown domainUpDown_LineColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Color;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.CheckBox checkBox_ShowSignals;
    }
}