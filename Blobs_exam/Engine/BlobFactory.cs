using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models;
using Blobs_exam.Models.Enums;
namespace Blobs_exam.Engine
{
  public class BlobFactory
    {
       // private Dictionary<Behavior, Attack> BlobType;
        public IBlob CreateBlob(string name,int health, int damage, Behavior behavior, Attack attack)
        {
            if (behavior == Behavior.Aggressive)
            {
                switch (attack)
                {
                        case Attack.Blobplode:
                        return new Blob(name,health,damage,Behavior.Aggressive, Attack.Blobplode);
                        case Attack.PutridFart:
                        return new Blob(name,health,damage,Behavior.Aggressive,Attack.PutridFart);
                        default:
                        throw new ArgumentException("Attack type not supported!");
                        
                }
            }
            switch (attack)
            {
                case Attack.Blobplode:
                    return new Blob(name, health, damage, Behavior.Inflated, Attack.Blobplode);
                case Attack.PutridFart:
                    return new Blob(name, health, damage, Behavior.Inflated, Attack.PutridFart);
                default:
                    throw new ArgumentException("Attack type not supported!");
            }
        }
    }
}
