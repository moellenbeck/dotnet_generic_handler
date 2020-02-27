namespace dotnet_samples
{
    public interface IHandler<TPayload, TResult>
        where TPayload: new()
        where TResult: new()
    {
        TResult Handle(TPayload payload);
    }

}
