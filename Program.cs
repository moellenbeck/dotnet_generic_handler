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

            var worker = new GenericWorker();

            worker.Register<ThePayload, TheResult>(aTopic, new HandlerActivater<ThePayload, TheResult>());
            
            ThePayload payload = new ThePayload {
                Name = "Hello world"
            };

            string jsongPayload = JsonSerializer.Serialize<ThePayload>(payload);

            var result = worker.HandleExternalTask(aTopic, jsongPayload);

            Console.WriteLine($"result is: {result}");


        }
    }
}
