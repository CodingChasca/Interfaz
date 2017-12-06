using System;

namespace Interfaz.Models
{
    public class Memento
    {
        private int likes;

        private DateTime time;

        public int Likes
        {
            get { return likes; }
            set { this.likes = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { this.time = value; }
        }

        public Memento(int likes, DateTime time)
        {
            this.likes = likes;
            this.time = time;
        }
    }
}