namespace dotnet_samples
{
    using System.Threading.Tasks;
    
    public interface IWorker<TPayload, TResult>
        where TPayload: new()
        where TResult: new()
    {
        TResult Work(TPayload payload);
    }

}
