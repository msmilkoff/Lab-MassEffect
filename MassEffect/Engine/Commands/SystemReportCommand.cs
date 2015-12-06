using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> intactShips = null;
            intactShips = this.GameEngine.Starships
                .Where(x => x.Health > 0 && x.Location.Name == locationName)
                .OrderByDescending(x => x.Health)
                .ThenByDescending(x => x.Shields);

            var output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any()
                ? string.Join("\n", intactShips)
                : "N/A");

            IEnumerable<IStarship> destroyedShips = null;
            destroyedShips = this.GameEngine.Starships
                .Where(x => x.Health <= 0 && x.Location.Name == locationName)
                .OrderBy(x => x.Name);

            output.AppendLine("Destroyed ships:");
            output.AppendLine(destroyedShips.Any()
                ? string.Join("\n", destroyedShips)
                : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}
