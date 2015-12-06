using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public abstract class Projectile : IProjectile
    {
        public int Damage { get; set; }

        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public abstract void Hit(IStarship ship);
    }
}
