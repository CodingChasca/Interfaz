using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interfaz.Models
{
    public class UpdateHistory
    {
        private List<Memento> savedStates;

        public UpdateHistory()
        {
            savedStates = new List<Memento>();
        }

        public void AddMemento(Memento m)
        {
            savedStates.Add(m);
        }

        public Memento getMemento(int index)
        {
            return savedStates[index];
        }
    }
}