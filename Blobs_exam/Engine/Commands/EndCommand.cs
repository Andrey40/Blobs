using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;

namespace Blobs_exam.Engine.Commands
{
    class EndCommand:Command
    {
        public EndCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.GameEngine.IsRunning = false;
        }
    }
}
