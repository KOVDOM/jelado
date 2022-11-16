using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using jelado;
using System.Runtime.InteropServices;

namespace jelado
{
    public class adatok
    {
        public int sor1;
        public int sor2;
        public int sor3;
        public int sor4;
        public int sor5;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<adatok> list = new List<adatok>();
            StreamReader sr = new StreamReader("jel.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] darabok = line.Split(' ');
                adatok a = new adatok();
                a.sor1 = int.Parse(darabok[0]);
                a.sor2 = int.Parse(darabok[1]);
                a.sor3 = int.Parse(darabok[2]);
                a.sor4 = int.Parse(darabok[3]);
                a.sor5 = int.Parse(darabok[4]);
                list.Add(a);
            }
            sr.Close();

            Console.WriteLine("2.feladat");
            Console.Write("Adja meg a jel sorszámát! ");
            int sorszam = int.Parse(Console.ReadLine());
            Console.WriteLine($"x={list[sorszam-1].sor4} y={list[sorszam - 1].sor5}");

            Console.WriteLine("4. feladat");
            int elso = list.Select(x => x.sor1).First();
            int masodik = list.Select(x => x.sor2).First();
            int harmadik = list.Select(x => x.sor3).First();
            int utolso = list.Select(x => x.sor1).Last();
            int utolso1 = list.Select(x => x.sor2).Last();
            int utolso2 = list.Select(x => x.sor3).Last();

            string kezdido = new DateTime(2022 , 11 , 16, elso, masodik, harmadik).ToString("HH:mm:ss");
            string vegdido = new DateTime(2022, 11, 16, utolso, utolso1, utolso2).ToString("HH:mm:ss");

            var ossz = DateTime.Parse(vegdido) - DateTime.Parse(kezdido);
            Console.WriteLine($"{ossz}");

            int leftCornerX =  list[0].sor4;
            int leftCornerY =  list[0].sor5;
            int rightCornerX = list[0].sor4;
            int rightCornerY = list[0].sor5;
            foreach (var item in list)
            {
                if (item.sor4 < leftCornerX)
                {
                    leftCornerX = item.sor4;
                }
                if (item.sor5 < leftCornerY)
                {
                    leftCornerY = item.sor5;
                }
                if (item.sor4 > rightCornerX)
                {
                    rightCornerX = item.sor4;
                }
                if (item.sor5 > rightCornerY)
                {
                    rightCornerY = item.sor5;
                }
            }
            Console.WriteLine("5. feladat");
            Console.WriteLine("Bal alsó: " + leftCornerX + " " + leftCornerY + ", jobb felső: " + rightCornerX + " " + rightCornerY);
            //6.feladat
            double xysum = 0;
            for (int x = 0; x < list.Count - 1; x++)
            {
                double x2 = (list[x].sor4 - list[x + 1].sor4) * (list[x].sor4 - list[x + 1].sor4);
                double y2 = (list[x].sor5 - list[x + 1].sor5) * (list[x].sor5 - list[x + 1].sor5);
                double x2y2 = x2 + y2;
                double xy = Math.Round(Math.Sqrt(x2y2),3);
                xysum += xy;
            }
            Console.WriteLine("6. feladat");
            Console.WriteLine("Elmozdulás {0} egység",xysum);

            Console.ReadKey();
        }
    }
}
