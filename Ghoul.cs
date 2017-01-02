using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location)
        :base(game, location, 10){ }

        public override void Move(Random random)
        {
            if (random.Next(0, 3) == 0)
            {

            }
            else
            {
                Direction direction = FindPlayerDirection(game.PlayerLocation);
                location = Move(direction, game.Boundaries);
            }
            if (NearPlayer())
            {
                game.HitPlayer(5, random);
            }
        }
    }
}