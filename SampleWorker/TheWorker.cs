namespace dotnet_samples.SampleWorker 
{
    using System;

    public class TheWorker: IWorker<ThePayload, TheResult> 
    {

        public TheResult Handle(ThePayload payload) {
            Console.WriteLine(payload);

            TheResult result = new TheResult
            {
                Name = $"Payload: {payload}"
            };

            return result;
        }
    }

}