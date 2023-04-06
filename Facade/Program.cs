using FacadeNS;

var facade = new Facade();

facade.OperationAB();
facade.OperationBC();

namespace FacadeNS
{
    public class Facade
    {
        private SubsystemA _subsystemA = new SubsystemA();
        private SubsystemB _subsystemB = new SubsystemB();
        private SubsystemC _subsystemC = new SubsystemC();

        public void OperationAB()
        {
            _subsystemA.OperationA();
            _subsystemB.OperationB();
        }

        public void OperationBC()
        {
            _subsystemB.OperationB();
            _subsystemC.OperationC();
        }
    }

    public class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("Operation from Subsystem A");
        }
    }
    
    public class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("Operation from Subsystem B");
        }
    }
    
    public class SubsystemC
    {
        public void OperationC()
        {
            Console.WriteLine("Operation from Subsystem C");
        }
    }
}
