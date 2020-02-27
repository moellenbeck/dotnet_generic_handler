namespace dotnet_samples.SampleWorker 
{
    using System;

    public class TheWorker: IWorker<ThePayload, TheResult> 
    {

        public TheResult Work(ThePayload payload) {
            Console.WriteLine($"Payload: {payload.Name}");

            TheResult result = new TheResult
            {
                ResultName = $"Payload: {payload.Name}"
            };

            return result;
        }
    }

}