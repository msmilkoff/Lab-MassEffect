using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Shields/2 + this.Damage);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;

            base.RespondToAttack(projectile);

            this.Shields -= 50;
        }
    }
}
