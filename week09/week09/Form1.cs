﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week09.Entities;

namespace week09
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {
                // Végigmegyünk az összes személyen
                for (int i = 0; i < Population.Count; i++)
                    SimStep(year, Population[i]);

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} \t Fiúk:{1} \t Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
        }

            private void SimStep(int year, Person person)
            {
                //Ha halott akkor kihagyjuk, ugrunk a ciklus következő lépésére
                if (!person.IsAlive) return;

                // Letároljuk az életkort, hogy ne kelljen mindenhol újraszámolni
                byte age = (byte)(year - person.BirthYear);

                // Halál kezelése
                // Halálozási valószínűség kikeresése
                double pDeath = (from x in DeathProbabilities
                                 where x.Gender == person.Gender && x.Age == age
                                 select x.P).FirstOrDefault();
                // Meghal a személy?
                if (rng.NextDouble() <= pDeath)
                    person.IsAlive = false;

                //Születés kezelése - csak az élő nők szülnek
                if (person.IsAlive && person.Gender == Gender.Female)
                {
                    //Szülési valószínűség kikeresése
                    double pBirth = (from x in BirthProbabilities
                                     where x.Age == age
                                     select x.P).FirstOrDefault();
                    //Születik gyermek?
                    if (rng.NextDouble() <= pBirth)
                    {
                        Person újszülött = new Person();
                        újszülött.BirthYear = year;
                        újszülött.NbrOfChildren = 0;
                        újszülött.Gender = (Gender)(rng.Next(1, 3));
                        Population.Add(újszülött);
                    }
                }
            }

        private List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            var deathProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return deathProbabilities;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            var birthProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = (byte)int.Parse(line[1]),
                        P = double.Parse(line[2])
                        
                    });
                }
            }

            return birthProbabilities;
        }

        public List<Person> GetPopulation(string csvpath)
        {
            var population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = (byte)int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
