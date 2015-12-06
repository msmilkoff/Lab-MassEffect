using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Shields -= this.Damage;

            if (this.Damage > targetShip.Shields)
            {
                int remainingDamage = this.Damage - targetShip.Shields;
                targetShip.Health -= remainingDamage;
            }
        }
    }
}
