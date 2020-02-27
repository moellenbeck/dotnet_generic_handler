namespace dotnet_samples.SampleWorker 
{
    using System;

    public class TheHandler: IHandler<ThePayload, TheResult> 
    {

        public TheResult Handle(ThePayload payload) {
            Console.WriteLine($"Payload: {payload.Name}");

            TheResult result = new TheResult
            {
                ResultName = $"Payload: {payload.Name}"
            };

            return result;
        }
    }

}