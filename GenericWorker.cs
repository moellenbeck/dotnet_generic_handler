namespace dotnet_samples
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public class GenericWorker {

        IDictionary<string, Func<string, string>> Handler = new Dictionary<string, Func<string, string>>();

        //public void Register<TPayload, TResult>(string topic, IHandler<TPayload, TResult> handler) 
        public void Register<TPayload, TResult>(string topic, HandlerActivater<TPayload, TResult> handlerActivator) 
            where TPayload: new() 
            where TResult: new()
        {
            Func<TPayload, TResult> handlerFunc = (TPayload payload) => {
                TResult result = default(TResult);

                var handler = handlerActivator.Activate();

                result = handler.Handle(payload);

                return result;
            };

            Func<string, string> HandleExternalTaskFunc = (string rawPayload) => {
                string rawResult = default(string);

                TPayload payload = default(TPayload);

                payload = JsonSerializer.Deserialize<TPayload>(rawPayload);

                TResult result = handlerFunc(payload);

                rawResult = JsonSerializer.Serialize<TResult>(result);

                return rawResult;
            };

            this.Handler.Add(topic, HandleExternalTaskFunc);
        }

        public string HandleExternalTask(string topic, string payload) {
            if (this.Handler.ContainsKey(topic)) {
                var handlerFunc = this.Handler[topic];

                return handlerFunc(payload);
            } 
            else 
            {
                return string.Empty;
            }
        }
    }
}