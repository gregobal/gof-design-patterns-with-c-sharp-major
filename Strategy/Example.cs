
namespace Strategy
{
    internal class Example
    {
        public static void Run()
        {
            var device = new SmartDevice("Alica", new RussianSpeakingAI());
            device.Speak();

            device.Speaker = new EnglishSpeakingAI();
            device.Speak();
        }
    }

    interface ISpeakable
    {
        void Speak();
    }

    class EnglishSpeakingAI: ISpeakable
    {
        public void Speak()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class RussianSpeakingAI: ISpeakable
    {
        public void Speak()
        {
            Console.WriteLine("Privet, Mir!");
        }
    }

    class SmartDevice(string name, ISpeakable speaker)
    {
        public string Name => name;

        public ISpeakable Speaker { private get; set; } = speaker;

        public void Speak()
        {
            Speaker.Speak();
        }
    }
}
