using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models;

namespace Blobs_exam.Engine.Commands
{
    public class PassCommand:Command
    {
       //????
        public PassCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }
        private void UpdateGame()
        {
            foreach (IBlob blob in GameEngine.Blobs )
            {
                blob.CountingCycle();
            }
        }
        public override void Execute(string[] commandArgs)
        {
            UpdateGame();
        }
    }
}
