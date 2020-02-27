namespace dotnet_samples
{
    using System;
    using System.Text.Json;

    using SampleWorker;

    class Program
    {
        static void Main(string[] args)
        {
            var aTopic = "aTopic";

            var handler = new GenericHandler();

            handler.Register<ThePayload, TheResult>(aTopic, new TheWorker());
            
            ThePayload payload = new ThePayload {
                Name = "Hello world"
            };

            string jsongPayload = JsonSerializer.Serialize<ThePayload>(payload);

            var result = handler.handleTask(aTopic, jsongPayload);

            Console.WriteLine($"result is: {result}");


        }
    }
}
