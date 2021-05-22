namespace RsjFramework.Contracts
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }
        string IpAddress { get; }
        string TransactionId { get; }
    }
}
