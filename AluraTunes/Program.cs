using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using AluraTunes.Data;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query = from g in contexto.Generos
                            select g;

                foreach (var genero in query)
                {
                    Console.WriteLine("{0}\t{1}",genero.GeneroId, genero.Nome);
                }
                Console.WriteLine();
                var FaixaEGenero = from g in contexto.Generos
                                   join f in contexto.Faixas
                                   on g.GeneroId equals f.GeneroId
                                   select new { f, g };

                FaixaEGenero = FaixaEGenero.Take(10);

               // contexto.Database.Log = Console.WriteLine;

                foreach (var item in FaixaEGenero)
                {
                    Console.WriteLine("{0}\t{1}",item.f.Nome, item.g.Nome);
                }
                Console.ReadKey();
                Console.WriteLine();

                var busca = "Led";

                var artista = from a in contexto.Artistas
                              where a.Nome.Contains(busca)
                              select a;

                foreach (var item in artista)
                {
                    Console.WriteLine("{0}\t{1}", item.ArtistaId, item.Nome);
                }

                Console.WriteLine();

                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(busca));

                foreach (var item in query2)
                {
                    Console.WriteLine("{0}\t{1}", item.ArtistaId, item.Nome);
                }

                Console.ReadKey();

            }

        }

        
    }
}
