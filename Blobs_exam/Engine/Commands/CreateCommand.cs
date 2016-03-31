using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models.Enums;

namespace Blobs_exam.Engine.Commands
{
   public class CreateCommand:Command
    {
       public CreateCommand(IGameEngine gameEngine) : base(gameEngine)
       {
       }

       public override void Execute(string[] commandArgs)
       {
           string name = commandArgs[1];
           int health = int.Parse(commandArgs[2]);
           int damage = int.Parse(commandArgs[3]);
           Behavior behavior =(Behavior)Enum.Parse(typeof(Behavior),commandArgs[4]) ;
           Attack attack = (Attack)Enum.Parse(typeof(Attack), commandArgs[5]);

            bool blobAlreadyExists = this.GameEngine.Blobs
                .Any(s => s.Name ==name);

            if (blobAlreadyExists)
            {
                throw new ArgumentException("Blob already exists!");
            }
            var blob = this.GameEngine.BlobFactory.CreateBlob(name, health, damage,behavior,attack);
            this.GameEngine.Blobs.Add(blob);
        }
    }
}
