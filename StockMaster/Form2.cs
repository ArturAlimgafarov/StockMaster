using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StockMaster
{
    public partial class Form2 : Form
    {
        List<StockData> stockData;
        List<StockData> visibleData;
        int cursorX;
        int cursorY;
        bool cursorOnTable;

        const int topLevel = 20;
        const int bottomLevel = 20;
        const int indent = 1;

        float linesStepPrice = 10;
        float topStepPrice = 10;
        float linesStepVolume = 10;
        int linesStepTime = 20;

        int leftIndex;
        int rightIndex;
        int selectedIndex;

        string period;

        const string priceModeDefault = "Цена закрытия";

        public Form2(string dataFilePath)
        {
            InitializeComponent();

            pictureBox_WorkTable.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_Volume.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_PriceScale.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_VolumeScale.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_DateTime.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_Period.BackColor = Color.FromArgb(20, 25, 30);

            ParseStockData(dataFilePath);

            int count = 40;
            visibleData = stockData.Skip<StockData>(stockData.Count - count).ToList<StockData>();

            leftIndex = stockData.Count - count;
            rightIndex = stockData.Count - 1;

            pictureBox_WorkTable.MouseWheel += MouseWheelEvent;
            pictureBox_Volume.MouseWheel += MouseWheelEvent;

            radioButton_Candles.Checked = true;

            domainUpDown_PriceMode.Text = priceModeDefault;
            domainUpDown_PriceMode.Enabled = false;
        }

        private void ParseStockData(string filepath)
        {
            stockData = new List<StockData>();
            StreamReader reader = new StreamReader(filepath);
            string line = reader.ReadLine(); // first line: <TICKER>,<PER>,<DATE>,<TIME>,<OPEN>,<HIGH>,<LOW>,<CLOSE>,<VOL>

            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                    break;

                string[] data = line.Split(',');

                period = data[1];

                string date = data[2];
                string time = data[3];
                double open = double.Parse(data[4].Replace('.', ','));
                double high = double.Parse(data[5].Replace('.', ','));
                double low = double.Parse(data[6].Replace('.', ','));
                double close = double.Parse(data[7].Replace('.', ','));
                int volume = int.Parse(data[8]);

                stockData.Add(new StockData(date, time, open, close, high, low, volume));
            }

            //close the file
            reader.Close();
        }

        private void pictureBox_WorkTable_Paint(object sender, PaintEventArgs e)
        {
            // draw cursor dotted lines
            Pen dotlinePen = new Pen(Color.Gray);
            int lineLength = 4;
            int boxWidth = pictureBox_WorkTable.Width;
            int boxHeight = pictureBox_WorkTable.Height;

            // horizontal
            float y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(dotlinePen, cursorX, y, cursorX, y + lineLength);
                y += 2 * lineLength;
            }

            // vertical
            float x = 0;
            if (cursorOnTable)
            {
                while (x <= boxWidth)
                {
                    e.Graphics.DrawLine(dotlinePen, x, cursorY, x + lineLength, cursorY);
                    x += 2 * lineLength;
                }
            }
            ////


            // draw division
            Pen divPen = new Pen(Color.FromArgb(25, 94, 102, 115));
            y = topStepPrice;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(divPen, 0, y, boxWidth, y);
                y += linesStepPrice;
            }

            int stockWidth = boxWidth / visibleData.Count - 1;
            x = stockWidth / 2;
            for (int i = 0; i < visibleData.Count; i += linesStepTime, x += (stockWidth + 1) * linesStepTime)
            {
                e.Graphics.DrawLine(divPen, x, 0, x, pictureBox_WorkTable.Height);
            }
            ////


            // draw chart
            if (radioButton_Lines.Checked)
            {
                // draw chart lines
                if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                {
                    string date = stockData[selectedIndex].Date.Insert(4, "/").Insert(7, "/");
                    string time = stockData[selectedIndex].Time.Substring(0, 4).Insert(2, ":");

                    string priceMode = domainUpDown_PriceMode.Text;
                    double currentPrice = GetStockValue(priceMode, stockData[selectedIndex]);
                    double previousPrice = selectedIndex == 0 ?
                        0 : GetStockValue(priceMode, stockData[selectedIndex - 1]);

                    double diff = currentPrice - previousPrice;
                    string sign = diff > 0 ? "+" : "-";

                    string diffStr = sign + Math.Round(Math.Abs(diff), 3).ToString();
                    string ratioStr = sign + Math.Round(Math.Abs(100 - 100 * previousPrice / currentPrice), 3).ToString();
                    string priceStr = currentPrice.ToString();

                    string row = date + " " + time + "    " + "ЦЕНА: " + priceStr + "   " +
                        diffStr + "  (" + ratioStr + "%)";
                    e.Graphics.DrawString(row, new Font("Arial", 8), new SolidBrush(Color.White), 5, 5);
                }
                ////
            }
            else
            {
                // draw chart title for candles & bars
                if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                {
                    string date = stockData[selectedIndex].Date.Insert(4, "/").Insert(7, "/");
                    string time = stockData[selectedIndex].Time.Substring(0, 4).Insert(2, ":");
                    string open = stockData[selectedIndex].Open.ToString();
                    string higH = stockData[selectedIndex].High.ToString();
                    string low = stockData[selectedIndex].Low.ToString();
                    string close = stockData[selectedIndex].Close.ToString();

                    string row = date + " " + time + "    " + "ОТКРЫТИЕ: " + open + " МАКСИМУМ: " + higH + " МИНИМУМ: " +
                        low + " ЗАКРЫТИЕ: " + close + " ОБЪЕМ: " + stockData[selectedIndex].Volume.ToString();
                    e.Graphics.DrawString(row, new Font("Arial", 8), new SolidBrush(Color.White), 5, 5);
                }
                ////
            }

            if (radioButton_Candles.Checked)
                DrawCandleChart(e);
            else if (radioButton_Bars.Checked)
                DrawBarChart(e);
            else
                DrawBrokenLineChart(e);
            ////


            // draw indicators
            DrawIndicatorsFromList(e);
            ////
        }

        private void DrawIndicatorsFromList(PaintEventArgs e)
        {
            if (checkBox_AllIndicators.Checked)
            {
                for (int i = 0; i < listBox_IndicatorsList.Items.Count; i++)
                {
                    var item = listBox_IndicatorsList.Items[i];
                    bool selected = i == listBox_IndicatorsList.SelectedIndex;

                    string[] indicatorStr = item.ToString().Split('(');
                    string indicatorName = indicatorStr[0];
                    string[] parameters = indicatorStr[1].Split(',');

                    switch (indicatorName)
                    {
                        case "SMA ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2].Split(')')[0]);

                                DrawSMA(e, N, lineColor, thickness, selected);

                                break;
                            }

                        case "EMA ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2].Split(')')[0]);

                                DrawEMA(e, N, lineColor, thickness, selected);

                                break;
                            }

                        case "Bollinger Bands ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[2].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[3]);
                                int sd = int.Parse(parameters[1]);
                                bool signals = parameters[4] == " True)";

                                DrawBollingerBands(e, N, sd, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "RSI ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawRSI(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Money Flow Index ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawMFI(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Williams %R ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawWilliamsR(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Momentum ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2]);
                                bool signals = parameters[3] == " True)";

                                DrawMomentum(e, N, lineColor, thickness, signals, selected);

                                break;
                            }
                    }
                }
            }
            else
            {
                int index = listBox_IndicatorsList.SelectedIndex;
                if (index >= 0)
                {
                    var item = listBox_IndicatorsList.Items[index];
                    bool selected = true;

                    string[] indicatorStr = item.ToString().Split('(');
                    string indicatorName = indicatorStr[0];
                    string[] parameters = indicatorStr[1].Split(',');

                    switch (indicatorName)
                    {
                        case "SMA ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2].Split(')')[0]);

                                DrawSMA(e, N, lineColor, thickness, selected);

                                break;
                            }

                        case "EMA ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2].Split(')')[0]);

                                DrawEMA(e, N, lineColor, thickness, selected);

                                break;
                            }

                        case "Bollinger Bands ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[2].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[3]);
                                int sd = int.Parse(parameters[1]);
                                bool signals = parameters[4] == " True)";

                                DrawBollingerBands(e, N, sd, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "RSI ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawRSI(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Money Flow Index ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawMFI(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Williams %R ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[3].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[4]);
                                bool signals = parameters[5] == " True)";
                                int highLevel = int.Parse(parameters[1].Split('%')[0]);
                                int lowLevel = int.Parse(parameters[2].Split('%')[0]);

                                DrawWilliamsR(e, N, highLevel, lowLevel, lineColor, thickness, signals, selected);

                                break;
                            }

                        case "Momentum ":
                            {
                                int N = int.Parse(parameters[0]);
                                string colorName = parameters[1].Replace(" ", "");
                                Color lineColor = GetColorByName(colorName);
                                int thickness = int.Parse(parameters[2]);
                                bool signals = parameters[3] == " True)";

                                DrawMomentum(e, N, lineColor, thickness, signals, selected);

                                break;
                            }
                    }
                }

            }
        }

        private void pictureBox_WorkTable_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // dragging chart
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (Math.Abs(cursorX - e.X) > 5)
                {
                    if (e.X > cursorX)
                    {
                        if (leftIndex > 0)
                        {
                            leftIndex--;
                            rightIndex--;

                            visibleData.Insert(0, stockData[leftIndex]);
                            visibleData.RemoveAt(visibleData.Count - 1);
                        }
                    }
                    else
                    {
                        if (rightIndex < stockData.Count - 1)
                        {
                            leftIndex++;
                            rightIndex++;

                            visibleData.Add(stockData[rightIndex]);
                            visibleData.RemoveAt(0);
                        }
                    }
                }
            }
            ////


            // stock highlight
            visibleData.ForEach(sd => sd.CurrentColor = sd.InitColor);

            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            int index = e.X / (stockWidth + indent);
            selectedIndex = index + leftIndex;

            if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                stockData[selectedIndex].CurrentColor = stockData[selectedIndex].SelectedColor;
            ////


            cursorX = index * (stockWidth + indent) + stockWidth / 2;
            cursorY = e.Y;
            cursorOnTable = true;

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void pictureBox_WorkTable_MouseLeave(object sender, EventArgs e)
        {
            cursorX = -10;
            cursorY = -10;

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void pictureBox_Volume_Paint(object sender, PaintEventArgs e)
        {
            // draw cursor dotted lines
            Pen dotlinepen = new Pen(Color.Gray);
            int lineLength = 4;
            int boxWidth = pictureBox_Volume.Width;
            int boxHeight = pictureBox_Volume.Height;

            // horizontal
            float y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(dotlinepen, cursorX, y, cursorX, y + lineLength);
                y += 2 * lineLength;
            }

            // vertical
            float x = 0;
            if (!cursorOnTable)
            {
                while (x <= boxWidth)
                {
                    e.Graphics.DrawLine(dotlinepen, x, cursorY, x + lineLength, cursorY);
                    x += 2 * lineLength;
                }
            }
            ////


            // draw division
            Pen divPen = new Pen(Color.FromArgb(25, 94, 102, 115));
            y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(divPen, 0, y, boxWidth, y);
                y += linesStepVolume;
            }

            int stockWidth = boxWidth / visibleData.Count - 1;
            x = stockWidth / 2;
            for (int i = 0; i < visibleData.Count; i += linesStepTime, x += (stockWidth + 1) * linesStepTime)
                e.Graphics.DrawLine(divPen, x, 0, x, boxHeight);
            ////


            // draw volumes
            x = 0;
            int volumeMaxHeight = 50;
            int maxVolume = visibleData.Max(sd => sd.Volume);
            float k = (float)volumeMaxHeight / maxVolume;

            foreach (var sd in visibleData)
            {
                float volumeHeight = k * sd.Volume;

                e.Graphics.FillRectangle(new SolidBrush(sd.CurrentColor),
                    x,
                    boxHeight - volumeHeight,
                    stockWidth,
                    volumeHeight);
                x += stockWidth + indent;
            }
            ////
        }

        private void pictureBox_Volume_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // stock highlight
            visibleData.ForEach(sd => sd.CurrentColor = sd.InitColor);

            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            int index = e.X / (stockWidth + indent);
            selectedIndex = index + leftIndex;

            if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                stockData[selectedIndex].CurrentColor = stockData[selectedIndex].SelectedColor;
            ////

            cursorX = index * (stockWidth + indent) + stockWidth / 2;
            cursorY = e.Y;
            cursorOnTable = false;

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_VolumeScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void pictureBox_Volume_MouseLeave(object sender, EventArgs e)
        {
            cursorX = -10;
            cursorY = -10;

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_VolumeScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void pictureBox_PriceScale_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            int boxWidth = pictureBox_PriceScale.Width;
            int boxHeight = pictureBox_PriceScale.Height;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);

            double diff = maxPrice - minPrice;
            int degree = (int)Math.Log10(diff);
            int tens = (int)Math.Pow(10, degree);
            tens /= diff < 10 * tens / 2 ? 2 : 1;
            int topDiv = (int)Math.Ceiling(maxPrice / tens) * tens;
            float rate = (float)((boxHeight - topLevel - bottomLevel) / diff);

            float step = rate * tens;
            linesStepPrice = step;
            float y = (float)(boxHeight - bottomLevel - (topDiv - minPrice) * rate);
            topStepPrice = y;
            float markValue = topDiv;

            Color markColor = Color.FromArgb(94, 102, 115);
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(new Pen(markColor), 0, y, 5, y);
                e.Graphics.DrawString(markValue.ToString(), new Font("Arial", 8), new SolidBrush(markColor), 7, y - 6);
                markValue -= tens;
                y += step;
            }
            ////


            // draw cursor mark
            if (cursorOnTable)
            {
                int windowHeight = boxHeight - topLevel - bottomLevel;
                float invRate = (float)((maxPrice - minPrice) / windowHeight);
                double cursorMarkValue = Math.Round(invRate * (boxHeight - bottomLevel - cursorY), 3) + minPrice;

                Color textBackColor = Color.FromArgb(43, 49, 57);
                Color textColor = Color.White;

                // draw text background
                e.Graphics.FillRectangle(new SolidBrush(textBackColor), 0, cursorY - 8, boxWidth, 16);

                // draw text
                e.Graphics.DrawString(cursorMarkValue.ToString(), new Font("Arial", 8),
                    new SolidBrush(textColor), 12, cursorY - 8);
            }
            ////
        }

        private void pictureBox_VolumeScale_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            const int marksCount = 4;
            int boxWidth = pictureBox_VolumeScale.Width;
            int boxHeight = pictureBox_VolumeScale.Height;
            float step = boxHeight / marksCount;
            float y = step;
            linesStepVolume = step;
            Color markColor = Color.FromArgb(94, 102, 115);
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(new Pen(markColor), 0, y, 5, y);
                y += step;
            }
            ////


            // draw cursor mark
            if (!cursorOnTable)
            {
                int maxVolume = stockData.Max(sd => sd.Volume);
                int volumeMaxHeight = 50;
                float invRate = (float)(maxVolume / volumeMaxHeight);
                double cursorMarkValue = Math.Round(invRate * (boxHeight - cursorY), 3);

                Color textBackColor = Color.FromArgb(43, 49, 57);
                Color textColor = Color.White;

                // draw text background
                e.Graphics.FillRectangle(new SolidBrush(textBackColor), 0, cursorY - 8,
                    boxWidth, 16);

                // draw text
                e.Graphics.DrawString(cursorMarkValue.ToString(), new Font("Arial", 8),
                    new SolidBrush(textColor), 12, cursorY - 8);
            }
            ////
        }

        private void MouseWheelEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta < 0 && pictureBox_WorkTable.Width / visibleData.Count - 1 > 1)
            {
                if (stockData.Count >= visibleData.Count)
                {
                    if (leftIndex > 0)
                    {
                        leftIndex--;
                        visibleData.Insert(0, stockData[leftIndex]);
                    }

                    if (rightIndex < stockData.Count - 1 && rightIndex > 0)
                    {
                        rightIndex++;
                        visibleData.Add(stockData[rightIndex]);
                    }
                }
            }
            else
            {
                if (leftIndex < stockData.Count - 1 && rightIndex - leftIndex >= 20)
                {
                    leftIndex++;
                    if (visibleData.Count > 20)
                        visibleData.RemoveAt(0);
                }
            }

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void pictureBox_DateTime_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            int marksCount = 10;
            int step = visibleData.Count / marksCount;
            int stockWidth = pictureBox_DateTime.Width / visibleData.Count - 1;
            linesStepTime = step;

            int x = stockWidth / 2;
            Color markColor = Color.FromArgb(94, 102, 115);
            for (int i = 0; i < visibleData.Count; i += step, x += (stockWidth + indent) * step)
            {
                // draw mark
                e.Graphics.DrawLine(new Pen(markColor), x, 0, x, 5);

                string label;
                if (period == "M" || period == "W" || period == "D")
                {
                    label = visibleData[i].Date.Substring(4, 4).Insert(2, "/");
                }
                else
                {
                    label = visibleData[i].Time.Substring(0, 4).Insert(2, ":");
                }

                // draw text
                e.Graphics.DrawString(label, new Font("Arial", 7), new SolidBrush(markColor), x - 10, 5);
            }
            ////
        }

        private void pictureBox_Period_Paint(object sender, PaintEventArgs e)
        {
            string choose;
            switch (period)
            {
                case "1":
                    {
                        choose = "1 минута";
                        break;
                    }
                case "5":
                    {
                        choose = "5 минут";
                        break;
                    }
                case "10":
                    {
                        choose = "10 минут";
                        break;
                    }
                case "15":
                    {
                        choose = "15 минут";
                        break;
                    }
                case "30":
                    {
                        choose = "30 минут";
                        break;
                    }
                case "60":
                    {
                        choose = "1 час";
                        break;
                    }
                case "D":
                    {
                        choose = "1 день";
                        break;
                    }
                case "W":
                    {
                        choose = "1 неделя";
                        break;
                    }
                case "M":
                    {
                        choose = "1 месяц";
                        break;
                    }
                default:
                    {
                        choose = "None";
                        break;
                    }
            }

            Color textColor = Color.FromArgb(94, 102, 115);
            e.Graphics.DrawString(choose, new Font("Arial", 10), new SolidBrush(textColor), 5, 5);
        }

        private void DrawCandleChart(PaintEventArgs e)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            int x = 0;
            foreach (var stock in visibleData)
            {
                float bodyLength = (float)(k * Math.Abs(stock.Open - stock.Close));
                float upperShadowLength = (float)(k * Math.Abs(stock.High - Math.Max(stock.Open, stock.Close)));
                float lowerShadowLength = (float)(k * Math.Abs(stock.Low - Math.Min(stock.Open, stock.Close)));

                float top = (float)(k * (Math.Max(stock.Open, stock.Close) - minPrice));
                float high = (float)(k * (stock.High - minPrice));
                float bottom = (float)(k * (Math.Min(stock.Open, stock.Close) - minPrice));

                // draw upper shadow
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high + upperShadowLength);

                // draw lower shadow
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - bottom,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - bottom + lowerShadowLength);

                // draw candle body
                e.Graphics.FillRectangle(new SolidBrush(stock.CurrentColor),
                    x,
                    boxHeight - bottomLevel - top,
                    stockWidth,
                    bodyLength);

                x += stockWidth + indent;
            }
        }

        private void DrawBarChart(PaintEventArgs e)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            int x = 0;
            foreach (var stock in visibleData)
            {
                float trunkLength = (float)(k * (stock.High - stock.Low));

                float open = (float)(k * (stock.Open - minPrice));
                float high = (float)(k * (stock.High - minPrice));
                float close = (float)(k * (stock.Close - minPrice));

                // draw trunk
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high + trunkLength);

                // draw open level
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x,
                    boxHeight - bottomLevel - open,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - open);

                // draw close level
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - close,
                    x + stockWidth,
                    boxHeight - bottomLevel - close);

                x += stockWidth + indent;
            }
        }

        private void DrawBrokenLineChart(PaintEventArgs e)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            string priceMode = domainUpDown_PriceMode.Text;
            Color lineColor = Color.Blue;
            int x = 0;
            for (int i = 0; i < visibleData.Count - 1; i++)
            {
                double value1 = GetStockValue(priceMode, visibleData[i]);
                double value2 = GetStockValue(priceMode, visibleData[i + 1]);

                float point1 = (float)(k * (value1 - minPrice));
                float point2 = (float)(k * (value2 - minPrice));

                e.Graphics.DrawLine(new Pen(lineColor, 2),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }
        }

        private void DrawBollingerBands(PaintEventArgs e, int N, int SD, Color lineColor, int thickness, bool signals, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            string priceMode = domainUpDown_PriceMode.Text;
            int x = 0;
            for (int i = 0; i < visibleData.Count - 1; i++)
            {
                double value1 = 0;
                double value2 = 0;
                for (int j = leftIndex - N + i; j <= leftIndex + i - 1; j++)
                {
                    value1 += stockData[j].Close;
                    value2 += stockData[j + 1].Close;
                }
                value1 /= N;
                value2 /= N;

                double val1 = 0;
                double val2 = 0;
                for (int j = leftIndex - N + i; j <= leftIndex + i - 1; j++)
                {
                    val1 += Math.Pow(stockData[j].Close - value1, 2);
                    val2 += Math.Pow(stockData[j + 1].Close - value2, 2);
                }
                val1 = Math.Sqrt(val1 / N);
                val2 = Math.Sqrt(val2 / N);

                double up1 = value1 + SD * val1;
                double up2 = value2 + SD * val2;

                double low1 = value1 - SD * val1;
                double low2 = value2 - SD * val2;

                float point1 = (float)(k * (value1 - minPrice));
                float point2 = (float)(k * (value2 - minPrice));

                float pointU1 = (float)(k * (up1 - minPrice));
                float pointU2 = (float)(k * (up2 - minPrice));

                float pointL1 = (float)(k * (low1 - minPrice));
                float pointL2 = (float)(k * (low2 - minPrice));

                if (signals)
                {
                    int arrowIndent = 10;
                    // 'SELL' signal
                    if (visibleData[i].Close > up1)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - k * (visibleData[i].Close - minPrice) - arrowIndent),
                            false,
                            selected);
                    }

                    // 'BUY' signal
                    if (visibleData[i].Close < low1)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - k * (visibleData[i].Close - minPrice) + arrowIndent),
                            true,
                            selected);
                    }
                }

                // draw high SMA
                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - pointU1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - pointU2);

                // draw low SMA
                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - pointL1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - pointL2);

                x += stockWidth + indent;
            }
        }

        private void DrawSMA(PaintEventArgs e, int N, Color lineColor, int thickness, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            string priceMode = domainUpDown_PriceMode.Text;
            int x = 0;
            for (int i = 0; i < visibleData.Count - 1; i++)
            {
                double value1 = 0;
                double value2 = 0;
                for (int j = leftIndex - N + i; j <= leftIndex + i - 1; j++)
                {
                    value1 += stockData[j].Close;
                    value2 += stockData[j + 1].Close;
                }
                value1 /= N;
                value2 /= N;

                float point1 = (float)(k * (value1 - minPrice));
                float point2 = (float)(k * (value2 - minPrice));

                // draw SMA
                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }
        }

        private void DrawEMA(PaintEventArgs e, int N, Color lineColor, int thickness, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            int x = 0;

            double value1 = 0;
            for (int j = leftIndex - N; j < leftIndex; j++)
            {
                value1 += stockData[j].Close;
            }

            value1 /= N;

            double alpha = 2.0 / (N + 1);
            for (int i = leftIndex; i < rightIndex; i++)
            {
                double value2 = stockData[i].Close * alpha + value1 * (1 - alpha);

                float point1 = (float)(k * (value1 - minPrice));
                float point2 = (float)(k * (value2 - minPrice));

                value1 = value2;

                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }
        }

        private void DrawRSI(PaintEventArgs e, int N, double HighLevel, double LowLevel, Color lineColor, int thickness, bool signals, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            int x = 0;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                double valueU1 = 0;
                double valueD1 = 0;
                double valueU2 = 0;
                double valueD2 = 0;
                for (int j = i - N + 1; j <= i; j++)
                {
                    if (stockData[j].Close > stockData[j].Open)
                        valueU1 += stockData[j].High - stockData[j].Low;
                    else
                        valueD1 += stockData[j].High - stockData[j].Low; ;

                    if (stockData[j + 1].Close > stockData[j + 1].Open)
                        valueU2 += stockData[j + 1].High - stockData[j + 1].Low;
                    else
                        valueD2 += stockData[j + 1].High - stockData[j + 1].Low;
                }

                double value1 = (valueD1 == 0) ? 100 : 100 - (100.0 / (1 + valueU1 / valueD1));
                double value2 = (valueD2 == 0) ? 100 : 100 - (100.0 / (1 + valueU2 / valueD2));

                float point1 = (float)(windowHeight * value1 / 100);
                float point2 = (float)(windowHeight * value2 / 100);

                if (signals)
                {
                    int arrowIndent = 10;
                    // 'SELL' signal
                    if (value1 > HighLevel)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - point1 - arrowIndent),
                            false,
                            selected);
                    }

                    // 'BUY' signal
                    if (value1 < LowLevel)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - point1 + arrowIndent),
                            true,
                            selected);
                    }
                }

                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }

            Color lvlColor = Color.White;
            int textIndent = 3;

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                    0, boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100),
                    pictureBox_WorkTable.Width,
                    boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100));
            e.Graphics.DrawString(HighLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100) + textIndent);

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                0, boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100),
                pictureBox_WorkTable.Width,
                boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100));
            e.Graphics.DrawString(LowLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100) + textIndent);
        }

        private void DrawWilliamsR(PaintEventArgs e, int N, int HighLevel, int LowLevel, Color lineColor, int thickness, bool signals, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            int x = 0;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                double high1 = stockData.GetRange(i - N + 1, N).Max(sd => sd.High);
                double low1 = stockData.GetRange(i - N + 1, N).Min(sd => sd.Low);

                double high2 = stockData.GetRange(i - N + 2, N).Max(sd => sd.High);
                double low2 = stockData.GetRange(i - N + 2, N).Min(sd => sd.Low);

                double value1 = ((high1 - stockData[i].Close) / (high1 - low1)) * (-100);
                double value2 = ((high2 - stockData[i + 1].Close) / (high2 - low2)) * (-100);

                float point1 = (float)(windowHeight * (100 + value1) / 100);
                float point2 = (float)(windowHeight * (100 + value2) / 100);

                if (signals)
                {
                    int arrowIndent = 10;
                    // 'BUY' signal
                    if (value1 > HighLevel)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - point1 - arrowIndent),
                            false,
                            selected);
                    }

                    // 'SELL' signal
                    if (value1 < LowLevel)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - point1 + arrowIndent),
                            true,
                            selected);
                    }
                }

                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }

            Color lvlColor = Color.White;
            int textIndent = 3;

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                    0, boxHeight - bottomLevel - (float)((100 + HighLevel) * windowHeight / 100),
                    pictureBox_WorkTable.Width,
                    boxHeight - bottomLevel - (float)((100 + HighLevel) * windowHeight / 100));
            e.Graphics.DrawString(HighLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)((100 + HighLevel) * windowHeight / 100) + textIndent);

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                0, boxHeight - bottomLevel - (float)((100 + LowLevel) * windowHeight / 100),
                pictureBox_WorkTable.Width,
                boxHeight - bottomLevel - (float)((100 + LowLevel) * windowHeight / 100));
            e.Graphics.DrawString(LowLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)((100 + LowLevel) * windowHeight / 100) + textIndent);
        }

        private void DrawMomentum(PaintEventArgs e, int N, Color lineColor, int thickness, bool signals, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            int x = 0;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                double value1 = stockData[i].Close - stockData[i - N].Close;
                double value2 = stockData[i + 1].Close - stockData[i + 1 - N].Close;

                if (signals)
                {
                    int arrowIndent = 10;
                    // 'BUY' signal
                    if (value1 < 0 && value2 > 0)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - windowHeight / 2 + arrowIndent),
                            true,
                            selected);
                    }

                    // 'SELL' signal
                    if (value1 > 0 && value2 < 0)
                    {
                        DrawSignal(e, x + stockWidth / 2,
                            (int)(boxHeight - bottomLevel - windowHeight / 2 - arrowIndent),
                            false,
                            selected);
                    }
                }

                float point1 = (float)(k * value1);
                float point2 = (float)(k * value2);

                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - windowHeight / 2 - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - windowHeight / 2 - point2);

                x += stockWidth + indent;
            }

            e.Graphics.DrawLine(new Pen(Color.White),
                    0, boxHeight - bottomLevel - windowHeight / 2,
                    pictureBox_WorkTable.Width,
                    boxHeight - bottomLevel - windowHeight / 2);
        }

        private void DrawMFI(PaintEventArgs e, int N, int HighLevel, int LowLevel, Color lineColor, int thickness, bool signals, bool selected)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            thickness = selected ? thickness + 1 : thickness;

            int x = 0;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                double PMF1 = 0;
                double NMF1 = 0;
                for (int j = i - N + 1; j <= i; j++)
                {
                    double tpPred = (stockData[j - 1].High + stockData[j - 1].Low + stockData[j - 1].Close) / 3;
                    double tpCurr = (stockData[j].High + stockData[j].Low + stockData[j].Close) / 3;
                    double MF = tpCurr * stockData[j].Volume;

                    if (tpCurr > tpPred)
                        PMF1 += MF;
                    else
                        NMF1 += MF;
                }

                double PMF2 = 0;
                double NMF2 = 0;
                for (int j = (i + 1) - N + 1; j <= i + 1; j++)
                {
                    double tpPred = (stockData[j - 1].High + stockData[j - 1].Low + stockData[j - 1].Close) / 3;
                    double tpCurr = (stockData[j].High + stockData[j].Low + stockData[j].Close) / 3;
                    double MF = tpCurr * stockData[j].Volume;

                    if (tpCurr > tpPred)
                        PMF2 += MF;
                    else
                        NMF2 += MF;
                }

                double MR1 = PMF1 / NMF1;
                double MR2 = PMF2 / NMF2;

                double value1 = 100 - (100 / (1 + MR1));
                double value2 = 100 - (100 / (1 + MR2));

                float point1 = (float)(windowHeight * value1 / 100);
                float point2 = (float)(windowHeight * value2 / 100);

                int arrowIndent = 10;
                // 'BUY' signal
                if (value1 < LowLevel)
                {
                    DrawSignal(e, x + stockWidth / 2,
                        (int)(boxHeight - bottomLevel - point1 + arrowIndent),
                        true,
                        selected);
                }

                // 'SELL' signal
                if (value1 > HighLevel)
                {
                    DrawSignal(e, x + stockWidth / 2,
                        (int)(boxHeight - bottomLevel - point1 - arrowIndent),
                        false,
                        selected);
                }

                e.Graphics.DrawLine(new Pen(lineColor, thickness),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - point1,
                    x + stockWidth + indent + stockWidth / 2,
                    boxHeight - bottomLevel - point2);

                x += stockWidth + indent;
            }

            Color lvlColor = Color.White;
            int textIndent = 3;

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                    0, boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100),
                    pictureBox_WorkTable.Width,
                    boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100));
            e.Graphics.DrawString(HighLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)(HighLevel * windowHeight / 100) + textIndent);

            // draw high level
            e.Graphics.DrawLine(new Pen(lvlColor),
                0, boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100),
                pictureBox_WorkTable.Width,
                boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100));
            e.Graphics.DrawString(LowLevel.ToString() + "%",
                new Font("Arial", 8),
                new SolidBrush(lvlColor),
                textIndent, boxHeight - bottomLevel - (float)(LowLevel * windowHeight / 100) + textIndent);
        }

        private double GetStockValue(string priceMode, StockData stock)
        {
            switch (priceMode)
            {
                case "Цена открытия":
                    {
                        return stock.Open;
                        break;
                    }
                case "Среднее(Макс, Мин)":
                    {
                        return (stock.High + stock.Low) / 2.0;
                        break;
                    }
                case "Максимальная цена":
                    {
                        return stock.High;
                        break;
                    }
                case "Минимальная цена":
                    {
                        return stock.Low;
                        break;
                    }
                default:
                    {
                        return stock.Close;
                        break;
                    }
            }
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

        private void domainUpDown_PriceMode_SelectedItemChanged(object sender, EventArgs e)
        {
            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void radioButton_Candles_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void radioButton_Bars_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void radioButton_Lines_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDown_PriceMode.Enabled = radioButton_Lines.Checked;

            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_PriceScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(this, true);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (listBox_IndicatorsList.Items.Count > 0)
            {
                Form3 form = new Form3(this, false);
                form.Owner = this;
                form.ShowDialog();
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            listBox_IndicatorsList.Items.Remove(listBox_IndicatorsList.SelectedItem);

            RefreshPictureBoxes();
        }

        public void RefreshPictureBoxes()
        {
            pictureBox_WorkTable.Refresh();
            pictureBox_Volume.Refresh();
            pictureBox_VolumeScale.Refresh();
            pictureBox_DateTime.Refresh();
        }

        private void listBox_IndicatorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPictureBoxes();
        }

        private void DrawSignal(PaintEventArgs e, int x, int y, bool isBuy, bool selected)
        {
            int length = 15;

            int sign = isBuy ? 1 : -1;

            int a = selected ? 255 : 100;

            Color color = isBuy ? Color.FromArgb(a, 0, 255, 0) : Color.FromArgb(a, 255, 0, 0);

            e.Graphics.DrawLine(new Pen(color), x, y, x, y + length * sign);
            e.Graphics.DrawLine(new Pen(color), x, y, x - (length / 3) * sign, y + (length / 3) * sign);
            e.Graphics.DrawLine(new Pen(color), x, y, x + (length / 3) * sign, y + (length / 3) * sign);
        }

        private void checkBox_AllIndicators_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPictureBoxes();
        }
    }
}
