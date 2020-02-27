namespace dotnet_samples
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public class GenericHandler {

        IDictionary<string, Func<string, string>> Handler = new Dictionary<string, Func<string, string>>();

        public void Register<TPayload, TResult>(string topic, IWorker<TPayload, TResult> worker) 
            where TPayload: new() 
            where TResult: new()
        {
            Func<TPayload, TResult> handler = (TPayload payload) => {
                TResult result = default(TResult);

                result = worker.Work(payload);

                return result;
            };

            Func<string, string> HandleExternalTask = (string rawPayload) => {
                string rawResult = default(string);

                TPayload payload = default(TPayload);

                payload = JsonSerializer.Deserialize<TPayload>(rawPayload);

                TResult result = handler(payload);

                rawResult = JsonSerializer.Serialize<TResult>(result);

                return rawResult;
            };

            this.Handler.Add(topic, HandleExternalTask);
        }

        public string HandleExternalTask(string topic, string payload) {
            if (this.Handler.ContainsKey(topic)) {
                var handler = this.Handler[topic];

                return handler(payload);
            } 
            else 
            {
                return string.Empty;
            }
        }
    }
}