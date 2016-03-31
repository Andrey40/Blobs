using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models;
using Blobs_exam.Models.Enums;

namespace Blobs_exam.Engine.Commands
{
    class AttackCommand:Command
    {
        public AttackCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackersName = commandArgs[1];
            string targetsName = commandArgs[2];

            var attaker = this.GetBlobByName(attackersName);
            var target = this.GetBlobByName(targetsName);

            this.Process(attaker, target);
        }

        private void Process(IBlob attaker, IBlob target)
        {
            if (attaker.HasTriggeredBehavior())
            {
                throw new ArgumentException("Behavior can be triggered only once!");
                
            }
            if (attaker.HasTriggeredBehavior() && attaker.HasUpdate())
            {
                throw new ArgumentException("Behavior can be triggered only once!");
            }
            else
            {
                if (attaker.BehaviorType == Behavior.Aggressive)
                {
                    attaker.AggressiveBehavior();
                    if (attaker.AttackType == Attack.Blobplode)
                    {
                        attaker.BlobplodeAttack(target);
                    }
                    else
                    {
                        attaker.PutridFartAttack(target);
                    }
                }
                else
                {
                    attaker.InflatedBehavior();
                    if (attaker.AttackType == Attack.PutridFart)
                    {
                        attaker.PutridFartAttack(target);
                    }
                    else
                    {
                        attaker.BlobplodeAttack(target);
                    }
                }
            }
        }
    }
}
