using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Engine;

namespace Blobs_exam.Interfaces
{
    public interface IGameEngine
    {
        BlobFactory BlobFactory { get; set; }
        
        IList<IBlob> Blobs { get; set; }
        
        Manager Manager { get; set; }

        bool IsRunning { get; set; }

        void Run();
    }
}
