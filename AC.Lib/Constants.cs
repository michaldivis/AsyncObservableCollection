using System;
using System.Collections.Generic;
using System.Text;
using AsyncObservableCollectionTest.Lib.Models;

namespace AsyncObservableCollectionTest.Lib
{
    public static class Constants
    {
        public static List<Minion> Minions => new List<Minion>
        {
            new Minion
            {
                Cost = 8,
                Name = "Ragnaros, the Firelord",
                Description = "At the end of your turn, deal 8 damage to a random enemy",
                Attack = 8,
                Health = 8,
                Type = MinionType.Elemental
            },
            new Minion
            {
                Cost = 2,
                Name = "Scavenging hyena",
                Description = "Whenever a friendly beast dies, gain +2/+1",
                Attack = 2,
                Health = 2,
                Type = MinionType.Beast
            },
            new Minion
            {
                Cost = 9,
                Name = "Malygos",
                Description = "Spell damage +5",
                Attack = 4,
                Health = 12,
                Type = MinionType.Dragon
            },
            new Minion
            {
                Cost = 3,
                Name = "Murloc warleader",
                Description = "Your other murlocs have +2 attack",
                Attack = 3,
                Health = 3,
                Type = MinionType.Murloc
            },
            new Minion
            {
                Cost = 6,
                Name = "Shieldbearer",
                Description = "Battlecry: Gain 5 armor",
                Attack = 5,
                Health = 5,
                Type = MinionType.None
            },
            new Minion
            {
                Cost = 20,
                Name = "Molten Giant",
                Description = "Costs (1) less for each damage your hero has taken",
                Attack = 8,
                Health = 8,
                Type = MinionType.Elemental
            },
            new Minion
            {
                Cost = 10,
                Name = "Aviana",
                Description = "Your minions cost (1)",
                Attack = 5,
                Health = 5,
                Type = MinionType.None
            },
            new Minion
            {
                Cost = 9,
                Name = "Jord Jaraxxus",
                Description = "Battlecry: Destroy your hero and replace it with Lord Jaraxxus",
                Attack = 3,
                Health = 15,
                Type = MinionType.Demon
            },
            new Minion
            {
                Cost = 9,
                Name = "Obsidian statue",
                Description = $"Taunt, Lifesteal{Environment.NewLine}Deathrattle: Destroy a{Environment.NewLine}random enemy minion",
                Attack = 4,
                Health = 8,
                Type = MinionType.None
            },
        };
    }
}
