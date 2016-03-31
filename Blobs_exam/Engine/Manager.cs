using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs_exam.Engine.Commands;
using Blobs_exam.Interfaces;

namespace Blobs_exam.Engine
{
  public  class Manager
    {
        protected readonly Dictionary<string, Command> commandsByName;

        public Manager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        public IGameEngine Engine { get; set; }

        public void ProcessCommand(string commandString)
        {
            string[] commandArgs = commandString.Split(' ');
            string commandName = commandArgs[0];

            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Command {0} does not exist.", commandName));
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public virtual void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["pass"] = new PassCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["drop"] = new EndCommand(this.Engine);
        }
    }
}
