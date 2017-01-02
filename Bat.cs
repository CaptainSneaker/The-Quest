using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Bat: Enemy
    {
        public Bat(Game game, Point location)
        :base(game, location, 6){}

        public override void Move(Random random)
        {
            if(random.Next(0,2) == 0)
            {
                Direction direction = (Direction)random.Next(0, 4);
                location = Move(direction, game.Boundaries);
            }
            else
            {
                Direction direction = FindPlayerDirection(game.PlayerLocation);
                location = Move(direction, game.Boundaries);
            }



            if (NearPlayer())
            {
                game.HitPlayer(3, random);
            }
        }
    }
}
