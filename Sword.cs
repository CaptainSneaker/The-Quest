using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace The_Quest
{
    class Sword : Weapon
    {
        public override string Name { get { return "Sword"; } }

        public Sword(Game game, Point location)
        : base(game, location) { }

        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, 30, 4, random))
            {
                if (!DamageEnemy(Turn(direction, true), 10, 4, random))
                {
                    DamageEnemy(Turn(direction, false), 10, 4, random);
                }
            }
        }
    }
}
