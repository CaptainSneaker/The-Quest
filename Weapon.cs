using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    abstract class Weapon: Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
        :base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius/2; distance++)
            {
                foreach(Enemy enemy in game.Enemies)
                {
                    if(Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }

                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        public bool Nearby(Point locationToCheck, Point secondLocation, int distance)
        {
            Player temporary = new Player(game, secondLocation);
            return temporary.Nearby(locationToCheck, distance);
        }

        public Point Move(Direction direction, Point location, Rectangle boundaries)
        {
            Player temporary = new Player(game, location);
            return temporary.Move(direction, boundaries);
        }


        public Direction Turn(Direction direction, bool clockWise)
        {
            int directionInt = (int)direction;
            if (clockWise)
            {
                directionInt++;
                if (directionInt > 3)
                {
                    directionInt -= 4;
                }
            }
            else
            {
                directionInt--;
                if (directionInt < 0)
                {
                    directionInt += 4;
                }
            }

            return (Direction)directionInt;
        }
    }

}
