using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Engine;
using Blobs_exam.Interfaces;

namespace Blobs_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager commandManager = new Manager();//
            GameEngine engine = new GameEngine(commandManager);
            engine.Run();
        }
    }
}
