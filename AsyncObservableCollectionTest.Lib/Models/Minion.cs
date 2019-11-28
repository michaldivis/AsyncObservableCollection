using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncObservableCollectionTest.Lib.Models
{
    public class Minion
    {
        public int Cost { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MinionType Type { get; set; }

        public Minion()
        {
            Health = 1;
            Attack = 1;
            Name = "Unnamed thing";
            Type = MinionType.None;
        }
    }
}
