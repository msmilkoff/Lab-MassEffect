using System.Text;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
        }

        public int ProjectilesFired
        {
            get { return this.projectilesFired; }
        }

        public override IProjectile ProduceAttack()
        {
            projectilesFired++;
            return new ShieldRiever(this.Damage);
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                output.AppendLine(string.Format("-Projectiles fired: {0}", this.ProjectilesFired));
            }

            return output.ToString();
        }
    }
}
