using System;
using System.Linq;
using MassEffect.Engine.Factories;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships
                .Any(x => x.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException("Ship already exists.");
            }

            var location = this.GameEngine.Galaxy
                .GetStarSystemByName(locationName);

            var shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            var shipFactory = new ShipFactory();
            var starship = shipFactory.CreateShip(shipType, shipName, location);

            GameEngine.Starships.Add(starship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)
                    Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = null;
                var enhancementFactory = new EnhancementFactory();
                enhancement = enhancementFactory.Create(enhancementType);
                starship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
