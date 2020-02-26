namespace dotnet_samples
{
    using System;

    using SampleWorker;

    class Program
    {
        static void Main(string[] args)
        {
            var aTopic = "aTopic";

            var handler = new GenericHandler();

            handler.Register<ThePayload, TheResult>(aTopic, new TheWorker());

            var result = handler.handleTask(aTopic, "a name");
            Console.WriteLine($"result is: {result}");
        }
    }
}
