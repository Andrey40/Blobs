using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Interfaces;
using Blobs_exam.Models.Enums;

namespace Blobs_exam.Models
{
   public class Blob:IBlob
    {
        private string name;
        private int health;
        private int damage;
        private Behavior behaviorType;
        private Attack attackType;
        private  int cycleCount = 0;

        public int CycleCount
        {
            get { return cycleCount; }
            set { this.cycleCount = 0; }
        }
     

        public Blob(string name, int health, int damage, Behavior behaviorType, Attack attackType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.BehaviorType = behaviorType;
            this.AttackType = attackType;
           // this.cycleCount = cycleCount;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                { throw new ArgumentNullException("Name cannot be empty!");}
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (this.health < 0)
                {
                    throw new ArgumentOutOfRangeException("Health must be positive number!");
                }
                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (this.damage < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage must be positive number!");
                }
                this.damage = value;
            }
        }
        public Behavior BehaviorType { get; set; }
        public Attack AttackType { get; set; }

        public bool HasUpdate()
        {
            this.CountingCycle();
            return true;
        }
        public void CountingCycle()
        {
            cycleCount++;
        }
        public bool AggressiveBehavior()
        {
            int damageSec = this.Damage;
            damage *= 2;
            if (this.HasUpdate())
            {
              damageSec  -= 5;
            }
            if (damageSec < this.Damage)
            {
                damageSec = this.Damage;
            }
            
            //ne po-malko ot pyrvonachalnata damage!
            return true;
        }

        public bool InflatedBehavior()
        {
            this.health += 50;
            if (HasUpdate())
            {
                this.health -= 10;
            }
            return true;
        }

        public void PutridFartAttack(IBlob target)
        {
            target.Health -= this.Damage;
        }

       public bool HasTriggeredBehavior()
       {
           if (AggressiveBehavior() || InflatedBehavior())
           {
               return true;
           }
           return false;
       }
       

        public void BlobplodeAttack(IBlob target)
        {
            this.Health -= this.Health/2;
            target.Health -= 2*this.Damage;
            if (this.Health < 1)
            {
                this.Health = 1;
            }
        }

       public bool HasDied(IBlob blob)
       {
           if (blob.Health == 0)
           {
               return true;
           }
           return false;
       }

       public override string ToString()
       {
           return string.Format("Blob {0}: {1} HP, {2} Damage", this.Name, this.Health, this.Damage);
       }
    }
}
