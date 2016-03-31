using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Models.Enums;
using Blobs_exam.Models;

namespace Blobs_exam.Interfaces
{
  public  interface IBlob
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        Behavior BehaviorType { get; set; }
        Attack AttackType { get; set; }

        bool AggressiveBehavior();
        bool InflatedBehavior();
        void PutridFartAttack(IBlob target);
        void BlobplodeAttack(IBlob target);
        bool HasDied(IBlob blob);
        bool HasUpdate();
        bool HasTriggeredBehavior();
        void CountingCycle();


    }
}
