using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIL3003_Odev_2
{
    class DBScan
    {
        private static double EucDistance(int[] point1, int[] point2)
        {
            double ans = 0;
            for (int i = 0; i < point1.Length; i++)
                ans += Math.Pow((point1[i] - point2[i]), 2);
            return Math.Sqrt(ans);
        }
        public static (int[],int) Start(Review[] reviews, string[] attr, float epsilon, int minNumofPoints)
        {
            int[] origin = new int[attr.Length];//Orjin
            int dataLength = reviews.Length;
            //Noktalar orjine göre öklid uzaklarıyla sıralanır
            Array.Sort(reviews, (review1, review2) => EucDistance(review1.data, origin).CompareTo(EucDistance(review2.data, origin)));
            int clusterNo = 1,j, tempNo;
            int[] clusters = new int[dataLength+1];
            for (int i = 0; i < dataLength; i++)
            {
                //i. datadan itibaren sonraki noktalar öklid uzaklığını sağladığı sürece gezilir
                for (j = i + 1; j < dataLength && EucDistance(reviews[i].data, reviews[j].data) <= epsilon; j++) ;
                if(j-i+reviews[i].pointCount >=minNumofPoints)//noktalar sayılır ve küme oluşturma koşulu kontrol edilir
                {
                    if (reviews[i].clusterNo != -1)//i. nokta zaten bir kümeye atanmış ise yeni gelen noktalar da o kümeye atanır
                        tempNo = reviews[i].clusterNo;
                    else//i. nokta hiç bir kümeye atanmamış ise sayılan tüm noktalara yeni bir küme numarası verilir
                    {
                        tempNo = clusterNo;
                        clusterNo++;
                    }
                    reviews[i].pointCount = j - i;//i. noktanın alanında kalan toplam nokta sayısı
                    reviews[i].clusterNo = tempNo;
                    for (int k=i+1;k<j;k++)
                    {
                        reviews[k].clusterNo = tempNo;
                        reviews[k].pointCount = Math.Max(k - i,reviews[k].pointCount);//k. noktanın alanında kendinden küçük indisle kalan toplam nokta sayısı
                    }
                }
                if(reviews[i].clusterNo!=-1)//i. nokta outlier değilse ait olduğu kümenin eleman sayısı 1 artar
                    clusters[reviews[i].clusterNo]++;
            }
            return (clusters,clusterNo);
        }
    }
}
