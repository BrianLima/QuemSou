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
        }
    }

    public class Category
    {
        public String category { get; set;}
        public String description { get; set; }
    }
}
