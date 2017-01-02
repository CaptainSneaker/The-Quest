using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Mace: Weapon
    {
        public override string Name { get { return "Mace"; } }

        public Mace(Game game, Point location)
        : base(game, location) { }

        public override void Attack(Direction direction, Random random)
        {
            Direction usedDirection = direction;
            if (!DamageEnemy(usedDirection, 20,7, random))
            {
                usedDirection = Turn(usedDirection, false);
                if (!DamageEnemy(usedDirection, 20, 7, random))
                {
                    usedDirection = Turn(usedDirection, false);
                    if (!DamageEnemy(usedDirection, 20, 7, random))
                    {
                        usedDirection = Turn(usedDirection, false);
                        DamageEnemy(usedDirection, 20, 7, random);
                    }
                }
            }
        }
    }
}
