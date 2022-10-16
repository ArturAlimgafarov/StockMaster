using System;
using System.Drawing;
using System.Windows.Forms;

namespace StockMaster
{
    public partial class Form3 : Form
    {
        Form2 parentForm;

        public Form3(Form2 form, bool addMode)
        {
            InitializeComponent();

            parentForm = form;

            if (addMode)
            {
                button_Add.Visible = true;
                this.Text = "Добавление индикатора";
            }
            else
            {
                button_Apply.Visible = true;
                this.Text = "Изменение индикатора";

                string[] indicatorStr = parentForm.listBox_IndicatorsList.SelectedItem.ToString().Split('(');
                string indicatorName = indicatorStr[0];
                string[] parameters = indicatorStr[1].Split(',');

                switch(indicatorName)
                {
                    case "SMA ":
                        {
                            domainUpDown_IndicatorName.Text = "Сглаженная скользящая средняя (SMA)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[1].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[2].Split(')')[0]);
                            label_SD.Visible = false;
                            numericUpDown_SD.Visible = false;
                            checkBox_ShowSignals.Visible = false;
                            label_HighLevel.Visible = false;
                            label_LowLevel.Visible = false;
                            numericUpDown_HighLevel.Visible = false;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Visible = false;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }

                    case "EMA ":
                        {
                            domainUpDown_IndicatorName.Text = "Экспоненциальная скользящая средняя (EMA)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[1].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[2].Split(')')[0]);
                            label_SD.Visible = false;
                            numericUpDown_SD.Visible = false;
                            checkBox_ShowSignals.Visible = false;
                            label_HighLevel.Visible = false;
                            label_LowLevel.Visible = false;
                            numericUpDown_HighLevel.Visible = false;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Visible = false;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }

                    case "Bollinger Bands ":
                        {
                            domainUpDown_IndicatorName.Text = "Полосы Боллинджера (Bollinger Bands)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[2].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[3]);
                            numericUpDown_SD.Visible = true;
                            label_SD.Visible = true;
                            numericUpDown_SD.Value = int.Parse(parameters[1]);
                            checkBox_ShowSignals.Checked = (parameters[4] == " True)") ? true : false;
                            checkBox_ShowSignals.Visible = true;
                            label_HighLevel.Visible = false;
                            label_LowLevel.Visible = false;
                            numericUpDown_HighLevel.Visible = false;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Visible = false;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }

                    case "RSI ":
                        {
                            domainUpDown_IndicatorName.Text = "Индекс относительной силы (RSI)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[3].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[4]);
                            label_SD.Visible = false;
                            numericUpDown_SD.Visible = false;
                            checkBox_ShowSignals.Checked = (parameters[5] == " True)") ? true : false;
                            checkBox_ShowSignals.Visible = true;
                            label_HighLevel.Visible = true;
                            label_LowLevel.Visible = true;
                            numericUpDown_HighLevel.Value = int.Parse(parameters[1].Split('%')[0]);
                            numericUpDown_HighLevel.Visible = true;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Value = int.Parse(parameters[2].Split('%')[0]);
                            numericUpDown_LowLevel.Visible = true;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }

                    case "Money Flow Index ":
                        {
                            domainUpDown_IndicatorName.Text = "Индекс денежных потоков (Money Flow Index)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[3].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[4]);
                            label_SD.Visible = false;
                            checkBox_ShowSignals.Checked = (parameters[5] == " True)") ? true : false;
                            checkBox_ShowSignals.Visible = true;
                            numericUpDown_SD.Visible = false;
                            label_HighLevel.Visible = true;
                            label_LowLevel.Visible = true;
                            numericUpDown_HighLevel.Value = int.Parse(parameters[1].Split('%')[0]);
                            numericUpDown_HighLevel.Visible = true;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Value = int.Parse(parameters[2].Split('%')[0]);
                            numericUpDown_LowLevel.Visible = true;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }

                    case "Williams %R ":
                        {
                            domainUpDown_IndicatorName.Text = "Процентный диапазон Уильямса (Williams %R)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[3].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[4]);
                            label_SD.Visible = false;
                            checkBox_ShowSignals.Checked = (parameters[5] == " True)") ? true : false;
                            checkBox_ShowSignals.Visible = true;
                            numericUpDown_SD.Visible = false;
                            label_HighLevel.Visible = true;
                            label_LowLevel.Visible = true;
                            numericUpDown_HighLevel.Visible = false;
                            numericUpDown_InvHighLevel.Value = int.Parse(parameters[1].Split('%')[0]);
                            numericUpDown_InvHighLevel.Visible = true;
                            numericUpDown_LowLevel.Visible = false;
                            numericUpDown_InvLowLevel.Value = int.Parse(parameters[2].Split('%')[0]);
                            numericUpDown_InvLowLevel.Visible = true;
                            break;
                        }

                    case "Momentum ":
                        {
                            domainUpDown_IndicatorName.Text = "Осциллятор \"Момент\" (Momentum)";
                            numericUpDown_N.Value = int.Parse(parameters[0]);
                            string colorName = parameters[1].Replace(" ", "");
                            domainUpDown_LineColor.Text = colorName;
                            button_Color.BackColor = GetColorByName(colorName);
                            numericUpDown_Thickness.Value = int.Parse(parameters[2]);
                            label_SD.Visible = false;
                            checkBox_ShowSignals.Checked = (parameters[3] == " True)") ? true : false;
                            checkBox_ShowSignals.Visible = true;
                            numericUpDown_SD.Visible = false;
                            label_HighLevel.Visible = false;
                            label_LowLevel.Visible = false;
                            numericUpDown_HighLevel.Visible = false;
                            numericUpDown_InvHighLevel.Visible = false;
                            numericUpDown_LowLevel.Visible = false;
                            numericUpDown_InvLowLevel.Visible = false;
                            break;
                        }
                }
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void domainUpDown_IndicatorName_SelectedItemChanged(object sender, EventArgs e)
        {
            string indicatorName = domainUpDown_IndicatorName.Text;

            switch(indicatorName)
            {
                case "Сглаженная скользящая средняя (SMA)":
                    {
                        numericUpDown_N.Value = 7;
                        label_SD.Visible = false;
                        numericUpDown_SD.Visible = false;
                        checkBox_ShowSignals.Visible = false;
                        label_HighLevel.Visible = false;
                        label_LowLevel.Visible = false;
                        numericUpDown_HighLevel.Visible = false;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Visible = false;
                        numericUpDown_InvLowLevel.Visible = false;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "";
                        ////

                        break;
                    }

                case "Экспоненциальная скользящая средняя (EMA)":
                    {
                        numericUpDown_N.Value = 14;
                        label_SD.Visible = false;
                        numericUpDown_SD.Visible = false;
                        checkBox_ShowSignals.Visible = false;
                        label_HighLevel.Visible = false;
                        label_LowLevel.Visible = false;
                        numericUpDown_HighLevel.Visible = false;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Visible = false;
                        numericUpDown_InvLowLevel.Visible = false;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "";
                        ////

                        break;
                    }

                case "Полосы Боллинджера (Bollinger Bands)":
                    {
                        numericUpDown_N.Value = 20;
                        numericUpDown_SD.Visible = true;
                        label_SD.Visible = true;
                        numericUpDown_SD.Value = 2;
                        checkBox_ShowSignals.Checked = true;
                        checkBox_ShowSignals.Visible = true;
                        label_HighLevel.Visible = false;
                        label_LowLevel.Visible = false;
                        numericUpDown_HighLevel.Visible = false;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Visible = false;
                        numericUpDown_InvLowLevel.Visible = false;

                        // rewrite info
                        textBox_Info.Text = "Полосы Боллинджера (англ. Bollinger bands) — инструмент технического анализа " +
                            "финансовых рынков, отражающий текущие отклонения цены акции, товара или валюты. Индикатор " +
                            "помогает оценить, как расположены цены относительно нормального торгового диапазона. " +
                            "Полосы Боллинджера создают рамку, в пределах которой цены считаются нормальным, и " +
                            "строятся в виде верхней и нижней границы вокруг скользящей средней, но ширина полосы " +
                            "не статична, а пропорциональна среднеквадратическому отклонению от скользящей средней за " +
                            "анализируемый период времени.\r\n\r\n" +
                            "Торговым сигналом считается, когда цена выходит из торгового коридора — либо поднимаясь " +
                            "выше верхней линии, либо пробивая нижнюю линию. Если график цены колеблется между " +
                            "линиями — индикатор не даёт торговых сигналов.";
                        ////

                        break;
                    }

                case "Индекс относительной силы (RSI)":
                    {
                        numericUpDown_N.Value = 14;
                        label_SD.Visible = false;
                        numericUpDown_SD.Visible = false;
                        checkBox_ShowSignals.Checked = true;
                        checkBox_ShowSignals.Visible = true;
                        label_HighLevel.Visible = true;
                        label_LowLevel.Visible = true;
                        numericUpDown_HighLevel.Value = 70;
                        numericUpDown_HighLevel.Visible = true;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Value = 30;
                        numericUpDown_LowLevel.Visible = true;
                        numericUpDown_InvLowLevel.Visible = false;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "Индекс относительной силы (RSI от англ. relative strength index) — " +
                            "индикатор технического анализа, определяющий силу тренда и вероятность его смены. \r\n\r\n" +
                            "Сигналы:\r\n" +
                            " - перекупленность/перепроданность — когда значение индикатора RSI ближе к отметке " +
                            "«100 %» или «0 %», соответственно;" +
                            " - расхождение — когда график индикатора образует экстремумы в направлении, обратном " +
                            "направлении движения цены;\r\n" +
                            " - фигуры технического анализа применимы к графику индикатора RSI и помогают прогнозировать " +
                            "окончание тренда;\r\n"+
                            " - тренд на индикаторе обычно совпадает с трендом на ценовом графике вплоть до любого из " +
                            "вышеперечисленных событий.\r\n"+
                            "Схождение и расхождение графиков цены и индикатора — один из методов определения окончания " +
                            "тенденции. Обычно цена после таких сигналов идёт в направлении RSI.";
                        ////

                        break;
                    }

                case "Индекс денежных потоков (Money Flow Index)":
                    {
                        numericUpDown_N.Value = 14;
                        label_SD.Visible = false;
                        checkBox_ShowSignals.Checked = true;
                        checkBox_ShowSignals.Visible = true;
                        numericUpDown_SD.Visible = false;
                        label_HighLevel.Visible = true;
                        label_LowLevel.Visible = true;
                        numericUpDown_HighLevel.Value = 80;
                        numericUpDown_HighLevel.Visible = true;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Value = 20;
                        numericUpDown_LowLevel.Visible = true;
                        numericUpDown_InvLowLevel.Visible = false;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "Индекс денежных потоков (MFI — от англ. money flow index) — " +
                            "технический индикатор, призванный показать интенсивность, с которой деньги " +
                            "вкладываются в ценную бумагу и выводятся из неё, анализируя объёмы торгов и " +
                            "соотношения типичных цен периодов.\r\n\r\n" +
                            "Индекс денежного потока является осциллятором на отрезке [0;100]. " +
                            "Нижние его значения указывают на перепроданность рынка, верхние — на перекупленность. " +
                            "Все торговые стратегии, применимые к осцилляторам, могут быть использованы и в " +
                            "отношении ИДП. Например:\r\n" +
                            " - купить, когда ИДП опускается ниже 20;\r\n" +
                            " - продать, когда ИДП превышает 80.";
                        ////

                        break;
                    }

                case "Процентный диапазон Уильямса (Williams %R)":
                    {
                        numericUpDown_N.Value = 14;
                        label_SD.Visible = false;
                        checkBox_ShowSignals.Checked = true;
                        checkBox_ShowSignals.Visible = true;
                        numericUpDown_SD.Visible = false;
                        label_HighLevel.Visible = true;
                        label_LowLevel.Visible = true;
                        numericUpDown_HighLevel.Visible = false;
                        numericUpDown_InvHighLevel.Value = -20;
                        numericUpDown_InvHighLevel.Visible = true;
                        numericUpDown_LowLevel.Visible = false;
                        numericUpDown_InvLowLevel.Value = -80;
                        numericUpDown_InvLowLevel.Visible = true;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "Williams %R (от англ. Larry Williams' percent range) — технический индикатор, " +
                            "определяющий состояние перекупленности/перепроданности по положению текущей цены закрытия " +
                            "в диапазоне между минимумом и максимумом цен за предыдущие периоды.\r\n\r\n" +
                            "%R является осциллятором, принимающим значения в пределах [-100;0], причём значение, " +
                            "расположенное ближе к нижней границе указывает на перепроданность, а ближе к верхней " +
                            "на перекупленность. Все торговые стратегии, применимые к другим осцилляторам теоретически " +
                            "подходят и к процентному диапазону Вильямса. Например:\r\n" +
                            " - открыть длинную позицию, если % R опускается ниже −80;\r\n" +
                            " - закрыть длинную позицию, если % R поднимется выше −20.";
                        ////

                        break;
                    }

                case "Осциллятор \"Момент\" (Momentum)":
                    {
                        numericUpDown_N.Value = 7;
                        label_SD.Visible = false;
                        checkBox_ShowSignals.Checked = true;
                        checkBox_ShowSignals.Visible = true;
                        numericUpDown_SD.Visible = false;
                        label_HighLevel.Visible = false;
                        label_LowLevel.Visible = false;
                        numericUpDown_HighLevel.Visible = false;
                        numericUpDown_InvHighLevel.Visible = false;
                        numericUpDown_LowLevel.Visible = false;
                        numericUpDown_InvLowLevel.Visible = false;
                        numericUpDown_Thickness.Value = 1;

                        // rewrite info
                        textBox_Info.Text = "Моментум (англ. Momentum) — один из самых простых технических индикаторов, " +
                            "рассчитываемый как отношение или разница между текущей ценой и ценой N периодов назад.\r\n\r\n";
                        ////

                        break;
                    }
            }
        }

        private void domainUpDown_LineColor_SelectedItemChanged(object sender, EventArgs e)
        {
            string colorName = domainUpDown_LineColor.Text;

            button_Color.BackColor = GetColorByName(colorName);
        }

        private Color GetColorByName(string colorName)
        {
            switch (colorName)
            {
                case "белый":
                    {
                        return Color.White;
                        break;
                    }

                case "жёлтый":
                    {
                        return Color.Yellow;
                        break;
                    }

                case "оранжевый":
                    {
                        return Color.Orange;
                        break;
                    }

                case "зелёный":
                    {
                        return Color.Lime;
                        break;
                    }

                case "красный":
                    {
                        return Color.Red;
                        break;
                    }

                case "синий":
                    {
                        return Color.Blue;
                        break;
                    }

                case "фиолетовый":
                    {
                        return Color.Violet;
                        break;
                    }

                case "голубой":
                    {
                        return Color.Cyan;
                        break;
                    }

                default:
                    {
                        return Color.Black;
                        break;
                    }
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string item = "";

            string indicatorName = domainUpDown_IndicatorName.Text;

            switch (indicatorName)
            {
                case "Сглаженная скользящая средняя (SMA)":
                    {
                        item = $"SMA ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value})";
                        break;
                    }

                case "Экспоненциальная скользящая средняя (EMA)":
                    {
                        item = $"EMA ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value})";
                        break;
                    }

                case "Полосы Боллинджера (Bollinger Bands)":
                    {
                        item = $"Bollinger Bands ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_SD.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Индекс относительной силы (RSI)":
                    {
                        item = $"RSI ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_HighLevel.Value}%, " +
                            $"{numericUpDown_LowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Индекс денежных потоков (Money Flow Index)":
                    {
                        item = $"Money Flow Index ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_HighLevel.Value}%, " +
                            $"{numericUpDown_LowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Процентный диапазон Уильямса (Williams %R)":
                    {
                        item = $"Williams %R ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_InvHighLevel.Value}%, " +
                            $"{numericUpDown_InvLowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Осциллятор \"Момент\" (Momentum)":
                    {
                        item = $"Momentum ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }
            }

            parentForm.listBox_IndicatorsList.Items.Add(item);
            parentForm.RefreshPictureBoxes();
            this.Close();
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            string item = "";

            string indicatorName = domainUpDown_IndicatorName.Text;

            switch (indicatorName)
            {
                case "Сглаженная скользящая средняя (SMA)":
                    {
                        item = $"SMA ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value})";
                        break;
                    }

                case "Экспоненциальная скользящая средняя (EMA)":
                    {
                        item = $"EMA ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value})";
                        break;
                    }

                case "Полосы Боллинджера (Bollinger Bands)":
                    {
                        item = $"Bollinger Bands ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_SD.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Индекс относительной силы (RSI)":
                    {
                        item = $"RSI ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_HighLevel.Value}%, " +
                            $"{numericUpDown_LowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Индекс денежных потоков (Money Flow Index)":
                    {
                        item = $"Money Flow Index ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_HighLevel.Value}%, " +
                            $"{numericUpDown_LowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Процентный диапазон Уильямса (Williams %R)":
                    {
                        item = $"Williams %R ({numericUpDown_N.Value}, " +
                            $"{numericUpDown_InvHighLevel.Value}%, " +
                            $"{numericUpDown_InvLowLevel.Value}%, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }

                case "Осциллятор \"Момент\" (Momentum)":
                    {
                        item = $"Momentum ({numericUpDown_N.Value}, " +
                            $"{domainUpDown_LineColor.Text}, " +
                            $"{numericUpDown_Thickness.Value}, " +
                            $"{checkBox_ShowSignals.Checked})";
                        break;
                    }
            }

            parentForm.listBox_IndicatorsList.Items[parentForm.listBox_IndicatorsList.SelectedIndex] = item;
            parentForm.RefreshPictureBoxes();
            this.Close();
        }
    }
}
