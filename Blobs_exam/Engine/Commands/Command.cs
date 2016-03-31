using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;

namespace Blobs_exam.Engine.Commands
{
   public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }



        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected IBlob GetBlobByName(string name)
        {
            return this.GameEngine.Blobs
                .First(s => s.Name == name);
        }

        protected void ValidateAlive(IBlob ship)
        {
            if (ship.Health <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot be negative!");
            }
        }
    }
}
