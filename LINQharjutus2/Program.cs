using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LINQharjutus2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\opilane\Desktop\tekst.txt");

            #region Sõnade arv

            char[] Vahed = new char[] { ' ', '\r', '\n' };
            int arv = text.Split(Vahed, StringSplitOptions.RemoveEmptyEntries).Length;

            Console.WriteLine("Sõnu on kokku: " + arv);
            #endregion

            #region Tähtede arv
            var Tähed = text.Count(char.IsLetter);
            Console.WriteLine("Tähti on kokku: " + Tähed);
            #endregion

            #region Erinevate tähtede arv
            var TähtedeArv = text.ToLower().GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count(char.IsLetter) }).OrderByDescending(c => c.Count);

            var TähtedeArvNullideta = (from täht in TähtedeArv
                                       where täht.Count > 0
                                       select täht).ToList();
            foreach (var item in TähtedeArvNullideta)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Kordumatud sõnad
            var Sõnad = new List<string> { };

            var sõnad = text.Split(Vahed, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in sõnad)
            {
                if (!Sõnad.Contains(item))
                {
                    Sõnad.Add(item);
                }
            }
            Console.WriteLine("Tekst kus sõnad ei kordu:");
            foreach (var item in Sõnad)
            {
                Console.Write(item + " ");
            }
            #endregion

            Console.ReadLine();
        }
    }
}
