using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static GADE6112_POE_part_1.Tile;

namespace GADE6112_POE_part_1
{
    internal class Leader : Enemy
    {
        private Tile Target;
        Random leaderMove = new Random();
        public Leader(int x, int y) : base(x, y, 20, 20, 2, TileType.Enemy)
        {
            this.x = x;
            this.y = y;
            weapon = new MeleeWeapon(MeleeWeapon.Types.LongSword);
            
        }
        public void setLeaderTarget(Hero target)
        {
            Target = target;
        }
        public Tile getLeaderTarget() { return Target; }
        public int getLeaderX() { return x; }
        public int getLeaderY() { return y; }   
        public override Movement ReturnMove(Movement direction = 0) // Leader needs to try and move towards the player at all times COME BACK AND CHANGE LATER NOT EVEN REMOTELY FINISHED
        {
            Leader leader = new Leader(this.x, this.y);
            int leaderX = leader.getX();
            int leaderY = leader.getY();
            int targetX = Target.getX();
            int targetY = Target.getY();
            
            int moveDirection; // Local variable used for assigning random direction
            moveDirection = leaderMove.Next(5); // randomly generates a number which is then correlated with a direction.
            if (leaderX < targetX && currentVision[1].getTileType() == Tile.TileType.Clear || leaderX < targetX && currentVision[1].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.down);
                return Movement.down;
            }
            if (leaderX > targetX && currentVision[0].getTileType() == Tile.TileType.Clear || leaderX > targetX && currentVision[0].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.up);
                return Movement.up;
            }
            if (leaderY < targetY && currentVision[3].getTileType() == Tile.TileType.Clear || leaderY < targetY && currentVision[3].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.right);
                return Movement.right;
            }
            if (leaderY > targetY && currentVision[2].getTileType() == Tile.TileType.Clear || leaderY > targetY && currentVision[2].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.left);
                return Movement.left;
            }
            else
            {
                if (moveDirection == 0 && currentVision[0].getTileType() == Tile.TileType.Clear || moveDirection == 0 && currentVision[0].getTileType() == Tile.TileType.Gold) // if random num is 0 then get tiles around Character and their respective Tiletypes. And if they are empty then move in the returned direction.
                {
                    setMovement(Movement.up);
                    return Movement.up;

                }
                if (moveDirection == 1 && currentVision[1].getTileType() == Tile.TileType.Clear || moveDirection == 1 && currentVision[1].getTileType() == Tile.TileType.Gold)
                {
                    setMovement(Movement.down);
                    return Movement.down;
                }
                if (moveDirection == 2 && currentVision[2].getTileType() == Tile.TileType.Clear || moveDirection == 2 && currentVision[2].getTileType() == Tile.TileType.Gold)
                {
                    setMovement(Movement.left);
                    return Movement.left;
                }
                if (moveDirection == 3 && currentVision[3].getTileType() == Tile.TileType.Clear || moveDirection == 3 && currentVision[3].getTileType() == Tile.TileType.Gold)
                {
                    setMovement(Movement.right);
                    return Movement.right;
                }
                else
                {
                    setMovement(Movement.noMovement);
                    return Movement.noMovement;
                }
            }
           
        }
    }
}
