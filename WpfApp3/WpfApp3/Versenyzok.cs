using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    internal class Versenyzok
    {
        string nev, csoport, nemzet;
        private double d3;
        private double eredmeny;
        private double d1;
        private double d2;

        public string Nev { get => nev; set => nev = value; }
        public string Csoport { get => csoport; set => csoport = value; }
        public string Nemzet { get => nemzet; set => nemzet = value; }
        public double D1 { get => d1; set => d1 = value; }
        public double D2 { get => d2; set => d2 = value; }
        public double D3 { get => d3; set => d3 = value; }
        public double Eredmeny { get => eredmeny; set => eredmeny = value; }
        public String Kód => this.Nemzet.Substring(this.Nemzet.IndexOf('(') + 1, 3);
        public String Nemzet2 => this.Nemzet.Substring(0, this.Nemzet.IndexOf('(') - 1);

        public float Eredmény()
        {
            return (float)Math.Max(Math.Max(this.D1, this.D2), this.D3);
        }


        public static ObservableCollection<Versenyzok> Beolvasas(string fajlnev)
        {
            ObservableCollection<Versenyzok> Versenyzok = new ObservableCollection<Versenyzok>();

            foreach (var sor in File.ReadLines(fajlnev).Skip(1))
            {
                Versenyzok.Add(new Versenyzok(sor));
            }
            return Versenyzok;
        }



        public Versenyzok(string sor)
        {
            string[] adatok = sor.Split(';');
            this.Nev = adatok[0];
            this.Csoport = adatok[1];
            this.Nemzet = adatok[2];
            D1 = ParseResult(adatok[3]);
            D2 = ParseResult(adatok[4]);
            D3 = ParseResult(adatok[5]);
            this.Eredmeny = Math.Max(D1, Math.Max(D2, D3));
        }

        private double ParseResult(string eredmeny)
        {
            if (eredmeny == "X") return -1.0;
            if (eredmeny == "-") return -2.0;
            return double.Parse(eredmeny);
        }
    }
}
