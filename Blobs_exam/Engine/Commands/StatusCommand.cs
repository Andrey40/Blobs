using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models;
using Blobs_exam.Engine;

namespace Blobs_exam.Engine.Commands
{
    class StatusCommand:Command
    {
        void PrintingCommand(IBlob blob)
        {
            if (blob.HasDied(blob))
            {
                Console.WriteLine("Blob {0} KILLED",blob.Name);
            }
            else
            {
                Console.WriteLine(blob.ToString());
            }
        }

        public StatusCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            List<IBlob> printList = new List<IBlob>();
            foreach (var blob in GameEngine.Blobs)
            {
                printList.Add(blob);
            }
            foreach (Blob blob in printList )
             this.PrintingCommand(blob);
        }
    }
}
