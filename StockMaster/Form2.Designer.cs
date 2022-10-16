
namespace StockMaster
{
    partial class Form2
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
            this.domainUpDown_PriceMode = new System.Windows.Forms.DomainUpDown();
            this.radioButton_Lines = new System.Windows.Forms.RadioButton();
            this.radioButton_Bars = new System.Windows.Forms.RadioButton();
            this.radioButton_Candles = new System.Windows.Forms.RadioButton();
            this.pictureBox_Period = new System.Windows.Forms.PictureBox();
            this.pictureBox_DateTime = new System.Windows.Forms.PictureBox();
            this.pictureBox_VolumeScale = new System.Windows.Forms.PictureBox();
            this.pictureBox_Volume = new System.Windows.Forms.PictureBox();
            this.pictureBox_PriceScale = new System.Windows.Forms.PictureBox();
            this.pictureBox_WorkTable = new System.Windows.Forms.PictureBox();
            this.listBox_IndicatorsList = new System.Windows.Forms.ListBox();
            this.groupBox_Chart = new System.Windows.Forms.GroupBox();
            this.groupBox_Indicators = new System.Windows.Forms.GroupBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.checkBox_AllIndicators = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VolumeScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PriceScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WorkTable)).BeginInit();
            this.groupBox_Chart.SuspendLayout();
            this.groupBox_Indicators.SuspendLayout();
            this.SuspendLayout();
            // 
            // domainUpDown_PriceMode
            // 
            this.domainUpDown_PriceMode.Items.Add("Цена открытия");
            this.domainUpDown_PriceMode.Items.Add("Цена закрытия");
            this.domainUpDown_PriceMode.Items.Add("Максимальная цена");
            this.domainUpDown_PriceMode.Items.Add("Минимальная цена");
            this.domainUpDown_PriceMode.Items.Add("Среднее(Макс, Мин)");
            this.domainUpDown_PriceMode.Location = new System.Drawing.Point(189, 19);
            this.domainUpDown_PriceMode.Name = "domainUpDown_PriceMode";
            this.domainUpDown_PriceMode.Size = new System.Drawing.Size(120, 20);
            this.domainUpDown_PriceMode.TabIndex = 21;
            this.domainUpDown_PriceMode.Text = "(выбор цены)";
            this.domainUpDown_PriceMode.SelectedItemChanged += new System.EventHandler(this.domainUpDown_PriceMode_SelectedItemChanged);
            // 
            // radioButton_Lines
            // 
            this.radioButton_Lines.AutoSize = true;
            this.radioButton_Lines.Location = new System.Drawing.Point(126, 19);
            this.radioButton_Lines.Name = "radioButton_Lines";
            this.radioButton_Lines.Size = new System.Drawing.Size(57, 17);
            this.radioButton_Lines.TabIndex = 20;
            this.radioButton_Lines.TabStop = true;
            this.radioButton_Lines.Text = "Линия";
            this.radioButton_Lines.UseVisualStyleBackColor = true;
            this.radioButton_Lines.CheckedChanged += new System.EventHandler(this.radioButton_Lines_CheckedChanged);
            // 
            // radioButton_Bars
            // 
            this.radioButton_Bars.AutoSize = true;
            this.radioButton_Bars.Location = new System.Drawing.Point(68, 19);
            this.radioButton_Bars.Name = "radioButton_Bars";
            this.radioButton_Bars.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Bars.TabIndex = 19;
            this.radioButton_Bars.TabStop = true;
            this.radioButton_Bars.Text = "Бары";
            this.radioButton_Bars.UseVisualStyleBackColor = true;
            this.radioButton_Bars.CheckedChanged += new System.EventHandler(this.radioButton_Bars_CheckedChanged);
            // 
            // radioButton_Candles
            // 
            this.radioButton_Candles.AutoSize = true;
            this.radioButton_Candles.Location = new System.Drawing.Point(7, 19);
            this.radioButton_Candles.Name = "radioButton_Candles";
            this.radioButton_Candles.Size = new System.Drawing.Size(55, 17);
            this.radioButton_Candles.TabIndex = 18;
            this.radioButton_Candles.TabStop = true;
            this.radioButton_Candles.Text = "Свечи";
            this.radioButton_Candles.UseVisualStyleBackColor = true;
            this.radioButton_Candles.CheckedChanged += new System.EventHandler(this.radioButton_Candles_CheckedChanged);
            // 
            // pictureBox_Period
            // 
            this.pictureBox_Period.BackColor = System.Drawing.Color.White;
            this.pictureBox_Period.Location = new System.Drawing.Point(713, 514);
            this.pictureBox_Period.Name = "pictureBox_Period";
            this.pictureBox_Period.Size = new System.Drawing.Size(90, 27);
            this.pictureBox_Period.TabIndex = 17;
            this.pictureBox_Period.TabStop = false;
            this.pictureBox_Period.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Period_Paint);
            // 
            // pictureBox_DateTime
            // 
            this.pictureBox_DateTime.BackColor = System.Drawing.Color.White;
            this.pictureBox_DateTime.Location = new System.Drawing.Point(12, 514);
            this.pictureBox_DateTime.Name = "pictureBox_DateTime";
            this.pictureBox_DateTime.Size = new System.Drawing.Size(700, 27);
            this.pictureBox_DateTime.TabIndex = 16;
            this.pictureBox_DateTime.TabStop = false;
            this.pictureBox_DateTime.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_DateTime_Paint);
            // 
            // pictureBox_VolumeScale
            // 
            this.pictureBox_VolumeScale.BackColor = System.Drawing.Color.White;
            this.pictureBox_VolumeScale.Location = new System.Drawing.Point(713, 413);
            this.pictureBox_VolumeScale.Name = "pictureBox_VolumeScale";
            this.pictureBox_VolumeScale.Size = new System.Drawing.Size(90, 100);
            this.pictureBox_VolumeScale.TabIndex = 15;
            this.pictureBox_VolumeScale.TabStop = false;
            this.pictureBox_VolumeScale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_VolumeScale_Paint);
            // 
            // pictureBox_Volume
            // 
            this.pictureBox_Volume.BackColor = System.Drawing.Color.White;
            this.pictureBox_Volume.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_Volume.Location = new System.Drawing.Point(12, 413);
            this.pictureBox_Volume.Name = "pictureBox_Volume";
            this.pictureBox_Volume.Size = new System.Drawing.Size(700, 100);
            this.pictureBox_Volume.TabIndex = 14;
            this.pictureBox_Volume.TabStop = false;
            this.pictureBox_Volume.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Volume_Paint);
            this.pictureBox_Volume.MouseLeave += new System.EventHandler(this.pictureBox_Volume_MouseLeave);
            this.pictureBox_Volume.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Volume_MouseMove);
            // 
            // pictureBox_PriceScale
            // 
            this.pictureBox_PriceScale.BackColor = System.Drawing.Color.White;
            this.pictureBox_PriceScale.Location = new System.Drawing.Point(713, 12);
            this.pictureBox_PriceScale.Name = "pictureBox_PriceScale";
            this.pictureBox_PriceScale.Size = new System.Drawing.Size(90, 400);
            this.pictureBox_PriceScale.TabIndex = 13;
            this.pictureBox_PriceScale.TabStop = false;
            this.pictureBox_PriceScale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_PriceScale_Paint);
            // 
            // pictureBox_WorkTable
            // 
            this.pictureBox_WorkTable.BackColor = System.Drawing.Color.White;
            this.pictureBox_WorkTable.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_WorkTable.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_WorkTable.Name = "pictureBox_WorkTable";
            this.pictureBox_WorkTable.Size = new System.Drawing.Size(700, 400);
            this.pictureBox_WorkTable.TabIndex = 12;
            this.pictureBox_WorkTable.TabStop = false;
            this.pictureBox_WorkTable.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_WorkTable_Paint);
            this.pictureBox_WorkTable.MouseLeave += new System.EventHandler(this.pictureBox_WorkTable_MouseLeave);
            this.pictureBox_WorkTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_WorkTable_MouseMove);
            // 
            // listBox_IndicatorsList
            // 
            this.listBox_IndicatorsList.FormattingEnabled = true;
            this.listBox_IndicatorsList.Location = new System.Drawing.Point(7, 75);
            this.listBox_IndicatorsList.Name = "listBox_IndicatorsList";
            this.listBox_IndicatorsList.Size = new System.Drawing.Size(302, 394);
            this.listBox_IndicatorsList.TabIndex = 22;
            this.listBox_IndicatorsList.SelectedIndexChanged += new System.EventHandler(this.listBox_IndicatorsList_SelectedIndexChanged);
            // 
            // groupBox_Chart
            // 
            this.groupBox_Chart.Controls.Add(this.radioButton_Lines);
            this.groupBox_Chart.Controls.Add(this.radioButton_Candles);
            this.groupBox_Chart.Controls.Add(this.domainUpDown_PriceMode);
            this.groupBox_Chart.Controls.Add(this.radioButton_Bars);
            this.groupBox_Chart.Location = new System.Drawing.Point(809, 12);
            this.groupBox_Chart.Name = "groupBox_Chart";
            this.groupBox_Chart.Size = new System.Drawing.Size(317, 47);
            this.groupBox_Chart.TabIndex = 23;
            this.groupBox_Chart.TabStop = false;
            this.groupBox_Chart.Text = "График";
            // 
            // groupBox_Indicators
            // 
            this.groupBox_Indicators.Controls.Add(this.checkBox_AllIndicators);
            this.groupBox_Indicators.Controls.Add(this.button_Delete);
            this.groupBox_Indicators.Controls.Add(this.button_Edit);
            this.groupBox_Indicators.Controls.Add(this.button_Add);
            this.groupBox_Indicators.Controls.Add(this.listBox_IndicatorsList);
            this.groupBox_Indicators.Location = new System.Drawing.Point(809, 65);
            this.groupBox_Indicators.Name = "groupBox_Indicators";
            this.groupBox_Indicators.Size = new System.Drawing.Size(317, 478);
            this.groupBox_Indicators.TabIndex = 24;
            this.groupBox_Indicators.TabStop = false;
            this.groupBox_Indicators.Text = "Индикаторы";
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(234, 20);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 25;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(126, 20);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 24;
            this.button_Edit.Text = "Изменить";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(7, 20);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 23;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // checkBox_AllIndicators
            // 
            this.checkBox_AllIndicators.AutoSize = true;
            this.checkBox_AllIndicators.Location = new System.Drawing.Point(7, 52);
            this.checkBox_AllIndicators.Name = "checkBox_AllIndicators";
            this.checkBox_AllIndicators.Size = new System.Drawing.Size(165, 17);
            this.checkBox_AllIndicators.TabIndex = 26;
            this.checkBox_AllIndicators.Text = "Отобрзить все индикаторы";
            this.checkBox_AllIndicators.UseVisualStyleBackColor = true;
            this.checkBox_AllIndicators.CheckedChanged += new System.EventHandler(this.checkBox_AllIndicators_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 555);
            this.Controls.Add(this.groupBox_Indicators);
            this.Controls.Add(this.groupBox_Chart);
            this.Controls.Add(this.pictureBox_Period);
            this.Controls.Add(this.pictureBox_DateTime);
            this.Controls.Add(this.pictureBox_VolumeScale);
            this.Controls.Add(this.pictureBox_Volume);
            this.Controls.Add(this.pictureBox_PriceScale);
            this.Controls.Add(this.pictureBox_WorkTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "StockMaster";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VolumeScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PriceScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WorkTable)).EndInit();
            this.groupBox_Chart.ResumeLayout(false);
            this.groupBox_Chart.PerformLayout();
            this.groupBox_Indicators.ResumeLayout(false);
            this.groupBox_Indicators.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DomainUpDown domainUpDown_PriceMode;
        private System.Windows.Forms.RadioButton radioButton_Lines;
        private System.Windows.Forms.RadioButton radioButton_Bars;
        private System.Windows.Forms.RadioButton radioButton_Candles;
        private System.Windows.Forms.PictureBox pictureBox_Period;
        private System.Windows.Forms.PictureBox pictureBox_DateTime;
        private System.Windows.Forms.PictureBox pictureBox_VolumeScale;
        private System.Windows.Forms.PictureBox pictureBox_Volume;
        private System.Windows.Forms.PictureBox pictureBox_PriceScale;
        private System.Windows.Forms.PictureBox pictureBox_WorkTable;
        private System.Windows.Forms.GroupBox groupBox_Chart;
        private System.Windows.Forms.GroupBox groupBox_Indicators;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        public System.Windows.Forms.ListBox listBox_IndicatorsList;
        private System.Windows.Forms.CheckBox checkBox_AllIndicators;
    }
}