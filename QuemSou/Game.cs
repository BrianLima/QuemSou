using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuemSou
{
    public class Game
    {
        public List<Category> categories = new List<Category>();

        public void StartGame()
        {
            categories.Add(new Category() { category = "Musicas nacionais", description = "Musicas de artistas brasileiros" });
            categories.Add(new Category() { category = "Artistas nacionais", description = "Artistas famosos brasileiros" });
        }

        public string Play(String category)
        {
            var rand = new Random();
            switch (category)
            {
                case "Musicas nacionais":
                    var index = rand.Next(Music.Musics.Count);
                    return Music.Musics[index];
                default:
                    return null;
            }
        }
    }

    public class Category
    {
        public String category { get; set;}
        public String description { get; set; }
    }

    public static class Music
    {
        public static List<String> Musics = new List<String> 
        {
            "Robocop Gay", 
            "A lenda dessa paixão"
        };
    }
}
