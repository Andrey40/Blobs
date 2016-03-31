using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models;
namespace Blobs_exam.Engine
{
    public sealed class GameEngine : IGameEngine
    {
        public GameEngine(Manager Manager)//
        {
            this.Manager = Manager;
            this.BlobFactory = new BlobFactory();
            this.Blobs = new List<IBlob>();
        }

        public BlobFactory BlobFactory { get; set; }

        public IList<IBlob> Blobs { get; set; }

       

        public Manager Manager { get; set; }//

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.Manager.Engine = this;
            this.Manager.SeedCommands();
            this.UpdateGame();
            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.Manager.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (this.IsRunning);
        }
        private void UpdateGame()
        {
            foreach (IBlob blob in this.Blobs)
            {
                blob.CountingCycle();
            }
        }
    }
}
