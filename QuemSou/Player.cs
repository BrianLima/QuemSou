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

        #region Prop
        public int Points { 
            get {return this.points; } 
            set {this.points = value; } 
        }

        public string Category { 
            get { return this.category; } 
            set { this.category = value; } 
        }

        public string CurrentWord { 
            get { return this.currentWord; } 
            set { this.currentWord = value; } 
        }

        public List<string> Words { 
            get { return this.words; } 
            set { this.words = value; } 
        }

        public Player(string category)
        {
            this.category = category;
            this.words = new List<string>();
            this.points = 0;
        }
        #endregion

        public void increasePoints()
        {
            this.points++;
        }

        public void setCurrentWord(String word)
        {
            this.currentWord = word;
            this.words.Add(word);
        }
    }
}
