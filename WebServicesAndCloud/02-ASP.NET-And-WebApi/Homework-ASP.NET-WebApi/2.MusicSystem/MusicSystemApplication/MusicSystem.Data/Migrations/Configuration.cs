namespace MusicSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicSystemDbContext context)
        {
            if (!context.Artists.Any())
            {
                Artist artistOne = new Artist()
                {
                    Country = "Triavna",
                    BirthDay = new DateTime(1994, 2, 3),
                    Name = "Zahari Triavnev"
                };
                context.Artists.Add(artistOne);

                Artist artistTwo = new Artist()
                {
                    Country = "Burgas",
                    BirthDay = new DateTime(1975, 2, 3),
                    Name = "Anatoli Burgazliev"
                };
                context.Artists.Add(artistTwo);

                Artist artistThree = new Artist()
                {
                    Country = "Dolno Konare",
                    BirthDay = new DateTime(1981, 2, 3),
                    Name = "Haralampi Konarev"
                };
                context.Artists.Add(artistThree);

                Song songZahariOne = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Zahari 1",
                    Year = 1996
                };
                context.Songs.Add(songZahariOne);
                Song songZahariTwo = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Zahari 2",
                    Year = 1996
                };
                context.Songs.Add(songZahariTwo);
                Song songZahariThree = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Zahari 3",
                    Year = 1996
                };
                context.Songs.Add(songZahariThree);

                Song songAnatoliOne = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Anatoli 1",
                    Year = 1996
                };
                context.Songs.Add(songAnatoliOne);
                Song songAnatoliTwo = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Anatoli 2",
                    Year = 1996
                };
                context.Songs.Add(songAnatoliTwo);
                Song songAnatoliThree = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Anatoli 3",
                    Year = 1996
                };
                context.Songs.Add(songAnatoliThree);

                Song songHaralampiTwo = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Haralampi 2",
                    Year = 1996
                };
                context.Songs.Add(songHaralampiTwo);
                Song songHaralampiThree = new Song()
                {
                    Artist = artistOne,
                    Genere = "Popfolk",
                    Title = "Pesnicka na Haralampi 3",
                    Year = 1996
                };
                context.Songs.Add(songHaralampiThree);

                Album firstAlbum = new Album()
                {
                    Artists = new List<Artist>() { artistOne, artistTwo, artistThree},
                    Title = "Popfolk Album 1",
                    Songs = new List<Song>()
                    {
                        songAnatoliOne,songAnatoliTwo,songAnatoliThree,
                        songZahariOne, songZahariTwo, songZahariThree,
                        songHaralampiTwo,songHaralampiThree
                    },
                    Year = 1993,
                    Producer = "Folk Factory"
                };
                context.Albums.Add(firstAlbum);

                Album secondAlbum = new Album()
                {
                    Artists = new List<Artist>() { artistOne, artistTwo, artistThree },
                    Title = "Popfolk Album 1",
                    Songs = new List<Song>()
                    {
                        songAnatoliOne,songAnatoliTwo,songAnatoliThree,
                        songZahariOne, songZahariTwo, songZahariThree,
                        songHaralampiTwo,songHaralampiThree
                    },
                    Year = 1993,
                    Producer = "Folk Factory"
                };
                context.Albums.Add(secondAlbum);

                Album thirdAlbum = new Album()
                {
                    Artists = new List<Artist>() { artistOne, artistTwo, artistThree },
                    Title = "Popfolk Album 1",
                    Songs = new List<Song>()
                    {
                        songAnatoliOne,songAnatoliTwo,songAnatoliThree,
                        songZahariOne, songZahariTwo, songZahariThree,
                        songHaralampiTwo,songHaralampiThree
                    },
                    Year = 1993,
                    Producer = "Folk Factory"
                };
                context.Albums.Add(thirdAlbum);

                context.SaveChanges();
            }
        }
    }
}
