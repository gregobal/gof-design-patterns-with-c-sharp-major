using CommandNS;

var receiver = new Receiver();
Command command = new ConcreteCommand(receiver);
var invoker = new Invoker();

invoker.StoreCommand(command);
invoker.ExecuteCommand();

namespace CommandNS
{
    public class Invoker
    {
        Command Command;

        public void StoreCommand(Command command)
        {
            Command = command;
        }

        public void ExecuteCommand()
        {
            Command.Execute();
        }
    }
    
    public abstract class Command
    {
        protected Receiver Receiver;

        public Command(Receiver receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receive");
        }
    }

    internal class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver):
            base(receiver)
        {
        }

        public override void Execute()
        {
            Receiver.Action();
        }
    }
}
