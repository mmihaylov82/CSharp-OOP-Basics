using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    var tokens = Console.ReadLine()
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string artistName = tokens[0];
                    string songName = tokens[1];
                    List<long> timeTokens = new List<long>();

                    try
                    {
                        timeTokens = tokens[2]
                            .Split(':', StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToList();
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Invalid song length.");
                    }
                    long minutes = timeTokens[0];
                    long seconds = timeTokens[1];

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var playlistTimeInSeconds = songs.Sum(s => s.SongLength.TotalSeconds);
            TimeSpan totalTime = TimeSpan.FromSeconds(playlistTimeInSeconds);

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
        }
    }
}
