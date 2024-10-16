using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1darbas
{
    // Naudojama abstrakti klase
    public abstract class BasePlayer
    {
        public string Name { get; set; }

        protected BasePlayer(string name)
        {
            Name = name;
        }
    }

    public class Player : BasePlayer
    {
        public Player(string name) : base(name) { }
    }

}
