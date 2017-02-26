using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AluraTunes
{
	public class LinqToObjects
	{
		public LinqToObjects()
		{
			List<Genero> generos = new List<Genero>
				{
					new Genero { Id = 1, Nome = "Rock" },
					new Genero { Id = 2, Nome = "Reggae" },
					new Genero { Id = 3, Nome = "Rock Progressivo" },
					new Genero { Id = 4, Nome = "Jazz" },
					new Genero { Id = 5, Nome = "Punk Rock" },
					new Genero { Id = 6, Nome = "Classica" }
				};

			List<Musica> musicas = new List<Musica>
				{
					new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
					new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
					new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 }
				};

			var GeneroQuery = from g in generos
							  where g.Nome.Contains("Rock")
							  select g;

			foreach (var genero in GeneroQuery)
			{
				Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
			}

			Console.WriteLine();

			var MusicaQuery = from m in musicas
							  where m.GeneroId == 1
							  select m;

			foreach (var musica in MusicaQuery)
			{
				Console.WriteLine("{0}\t{1}\t{2}", musica.Id, musica.Nome, musica.GeneroId);
			}

			Console.WriteLine();

			var Query = from m in musicas
						join g in generos on m.GeneroId equals g.Id
						where g.Nome.Equals("Reggae")
						select new { m, g };

			foreach (var musica in Query)
			{
				Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
			}

			Console.ReadKey();

		}

		class Genero
		{
			public int Id { get; set; }
			public string Nome { get; set; }
		}

		class Musica
		{
			public int Id { get; set; }
			public string Nome { get; set; }
			public int GeneroId { get; set; }
		}

	}
}
