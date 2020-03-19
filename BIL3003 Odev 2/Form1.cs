using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BIL3003_Odev_2
{
    struct Review
    {
        public int[] data;
        public int clusterNo;
        public int pointCount;
        public int reviewNo;
    }
    public partial class Form1 : Form
    {
        Review[] reviews;
        string[] attr;
        int clusterCount;
        int outlier;
        Review[] tempReviews;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (reviews, attr) = FileOperations.ReadCsv();//Dosya okundu
        }

        private void start_Click(object sender, EventArgs e)
        {
            int minNumofPoints = 0;
            tempReviews = (Review[])reviews.Clone();
            float epsilonVal = 0;
            bool isValid = true;
            dataChart.Series.Clear();
            try//Minimum nokta sayısı ile epsilon alınır
            {
                if (Int32.TryParse(minNumPoint.Text, out int val))
                {
                    if (val > 0 && val < reviews.Length + 1)
                    {
                        minNumofPoints = val;
                    }
                    else if (val > reviews.Length)
                    {
                        minNumofPoints = 249;
                        MessageBox.Show("Minimum nokta sayısını toplam veri adedinden fazla girdiniz.\nİşlemler esnasında toplam veri adedi kullanılacaktır.", "Yüksek minimum nokta sayısı");
                    }
                    else
                        throw new NotIntException("Minimum nokta sayısı pozitif tam sayı olmalıdır");
                }
                else
                    throw new NotIntException("Girilen değer tam sayı değildir");
                if (float.TryParse(epsilon.Text, out float eps))
                {
                    if (eps >= 0)
                        epsilonVal = eps;
                    else
                        MessageBox.Show("Negatif epsilon değeri girdiniz.\nİşlemler esnasında epsilon 0 alınacaktır.", "Negatif epsilon");
                }
                else
                    throw new InvalidNumberException("Geçerli bir epsilon değeri giriniz");

            }
            catch (NotIntException error)
            {
                isValid = false;
                MessageBox.Show(error.Message, "Minimum nokta sayısını hatalı girdiniz");
            }
            catch (InvalidNumberException error)
            {
                isValid = false;
                MessageBox.Show(error.Message, "Epsilon değerini hatalı girdiniz");
            }
            if (isValid)//Minimum nokta sayısı ile epsilon doğru girildiyse
            {
                int[] clusters;
                (clusters, clusterCount) = DBScan.Start(tempReviews, attr, epsilonVal, minNumofPoints);//DBScan çalışır,kaç küme olduğunu ve her kümenin eleman sayısını döner
                outlier = FileOperations.WriteResults(tempReviews, clusters);//Sonuçlar yazdırılır ve fonksiyon outlier olup olmadığını döner
                chartButton.Visible = true;
                xAxisCombo.Visible = true;
                xAxisLabel.Visible = true;
                yAxisCombo.Visible = true;
                yAxisLabel.Visible = true;
                xAxisCombo.Items.Clear();
                yAxisCombo.Items.Clear();
                for (int i = 0; i < attr.Length; i++)//Comboboxlar doldurulur
                {
                    xAxisCombo.Items.Add(attr[i]);
                    yAxisCombo.Items.Add(attr[i]);
                }
            }
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            dataChart.Series.Clear();
            if (xAxisCombo.SelectedIndex == -1 || yAxisCombo.SelectedIndex == -1)//X ve Y eksenleri için özellik seçilip seçilmedi kontrolü
            {
                MessageBox.Show("2 Eksen için de özellik seçmelisiniz");
            }
            else
            {
                for (int i = 1; i < clusterCount; i++)//Tüm kümeler için seri oluşturulur
                {
                    dataChart.Series.Add("Küme" + i).ChartType = SeriesChartType.Point;
                }
                if (outlier == 1)//Sapan değer varsa onun için de seri oluşturulur
                {
                    dataChart.Series.Add("Sapan Değer").ChartType = SeriesChartType.Point;
                }
                string tempNo;
                for (int i = 0; i < reviews.Length; i++)
                {
                    //Noktalar grafiğe yerleştirilir
                    tempNo = (tempReviews[i].clusterNo == -1) ? "Sapan Değer" : "Küme" + tempReviews[i].clusterNo;
                    dataChart.Series[tempNo].Points.AddXY(tempReviews[i].data[xAxisCombo.SelectedIndex], tempReviews[i].data[yAxisCombo.SelectedIndex]);
                }
                dataChart.Visible = true;
            }
        }

        private void dataChart_MouseClick(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            int selectedX = xAxisCombo.SelectedIndex, selectedY = yAxisCombo.SelectedIndex;
            HitTestResult res = dataChart.HitTest(pos.X, pos.Y);
            if (res.ChartArea == null || selectedX==-1 || selectedY==-1)//chart dışında bir yere tıklanmasını ve boş x,y eksenleri için çalışmayı önler
                return;
            //tıklanılan noktanın x ve y değeri yuvarlanır
            int x1 = (int)Math.Floor(res.ChartArea.AxisX.PixelPositionToValue(pos.X)), x2 = (int)Math.Ceiling(res.ChartArea.AxisX.PixelPositionToValue(pos.X));
            int y1 = (int)Math.Floor(res.ChartArea.AxisY.PixelPositionToValue(pos.Y)), y2 = (int)Math.Ceiling(res.ChartArea.AxisY.PixelPositionToValue(pos.Y));
            string clickedPoints = "";
            string clusterNo;
            foreach (Review iter in tempReviews)//Tıklanılan noktanın gözlemler içinde aranması
            {
                if((iter.data[selectedX]==x1 || iter.data[selectedX] == x2)&&(iter.data[selectedY]==y1 || iter.data[selectedY]==y2))
                {
                    clusterNo = (iter.clusterNo == -1) ? "Sapan Değer" : "Küme " + iter.clusterNo;
                    clickedPoints += ("Kayıt "+iter.reviewNo.ToString() + ":    " + clusterNo + "\n");
                }
            }
            if(clickedPoints!="")//Tıklanılan yerde nokta yok ise
                MessageBox.Show(clickedPoints);
        }
    }
}
