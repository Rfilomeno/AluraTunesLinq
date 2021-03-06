﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"..\..\Data\AluraTunes.xml");
            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica")
                            on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new
                        {
                            MusicaId = m.Element("MusicaId").Value,
                            Musica = m.Element("Nome").Value,
                            Genero = g.Element("Nome").Value
                        };
            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.MusicaId, item.Musica, item.Genero);
            }
            Console.ReadKey();
        }
    }
}
