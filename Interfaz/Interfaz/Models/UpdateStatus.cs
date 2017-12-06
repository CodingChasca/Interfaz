using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interfaz.Models
{
    public class UpdateStatus
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

        public Memento SaveMemento()
        {
            return new Memento(likes, time);
        }

        public void RestoreMemento(Memento memento)
        {
            this.likes = memento.Likes;
            this.time = memento.Time;
        }
    }
}