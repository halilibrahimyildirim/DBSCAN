using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIL3003_Odev_2
{
    class FileOperations
    {
        public static (Review[],string[]) ReadCsv()
        {
            string filePath = "";
            string fileName = "tourism.csv";
            string checkName = "";
            bool exit = false;
            do//Dosya seçim işlemi
            {
                try
                {
                    OpenFileDialog file = new OpenFileDialog();
                    file.Title = "Data Dosyasını seçiniz";
                    var res = file.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        filePath = file.FileName;
                        checkName = file.SafeFileName;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        exit = true;
                        break;
                    }
                    if (checkName != fileName)
                        throw new FileNameException("Dosyanın adını değiştirdiyseniz bu hata ile karşılaşıyor olabilirsiniz");
                    else
                        break;
                }
                catch (FileNameException error)
                {
                    MessageBox.Show(error.Message, "Doğru dosyayı seçiniz");
                }
            } while (true);
            if (exit)//Openfiledialogda çıkış yapılmak istenirse
                Application.Exit();
            StreamReader fileReader = new StreamReader(File.OpenRead(filePath));
            string[] attr = fileReader.ReadLine().Split(',');//ilk satır özellik isimleri
            Review[] reviews = new Review[249];
            int i = 0;
            string[] temp;
            while (!fileReader.EndOfStream)//dosya sonuna kadar okuma
            {
                temp = fileReader.ReadLine().Split(',');
                reviews[i].data = new int[6];
                for (int j = 0; j < 6; j++)
                    reviews[i].data[j] = Int32.Parse(temp[j]);
                reviews[i].clusterNo = -1;
                reviews[i].pointCount = 0;
                reviews[i].reviewNo = i + 1;
                i++;
            }
            return (reviews,attr);//gözlemler ve özellik isimleri döndürülür
        }
        public static int WriteResults(Review[] reviews, int[] clusters)
        {
            FolderBrowserDialog results = new FolderBrowserDialog();
            string resultFilePath = "";
            resultFilePath = results.SelectedPath;
            FileStream fs = new FileStream(resultFilePath + "Results.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string clusterNo;
            Array.Sort(reviews, (review1, review2) => review1.reviewNo.CompareTo(review2.reviewNo));//gözlem numarasına göre sıralanır
            for (int i = 0; i < reviews.Length; i++)
            {
                clusterNo = (reviews[i].clusterNo != -1) ? "Küme " + reviews[i].clusterNo.ToString() : "?";//sapan değer ise ? değilse küme numarasını yazdırma
                sw.WriteLine("Kayıt " + reviews[i].reviewNo + ":    " + clusterNo);
            }
            int outlierCount = 0;
            for(int i=1;i<reviews.Length+1 && clusters[i]!=0;i++)
            {
                sw.WriteLine("Küme " + i + ":    " + clusters[i] + " Kayıt");//Hangi kümede kaç kayıt olduğunu yazdırma
                outlierCount += clusters[i];
            }
            outlierCount = reviews.Length - outlierCount;
            if (outlierCount > 0)//outlier varsa
                sw.WriteLine("Sapan değer:    " + outlierCount+" Kayıt");
            sw.Flush();
            sw.Close();
            MessageBox.Show("Dosyaya yazıldı");
            return (outlierCount > 0) ? 1 : 0;//Outlier olup olmadığı döndürülür
        }
    }
}
