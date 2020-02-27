namespace dotnet_samples
{
    using System;
    using System.Text.Json;

    using SampleWorker;

    public class HandlerActivater<TPayload, TResult>
        where TPayload: new()
        where TResult: new()
    {
        public IHandler<TPayload, TResult> Activate() {
            return (IHandler<TPayload, TResult>)new TheHandler();
        }
    }
}