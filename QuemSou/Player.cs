using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuemSou
{
    public class Player
    {
        public int points;
        public string category;
        public string currentWord;
        public List<string> words;

        public Player(string category)
        {
            this.category = category;
            this.words = new List<string>();
            this.points = 0;
        }

        public void increasePoints()
        {
            this.points++;
        }
    }
}
