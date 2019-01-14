namespace IDM.API.Repositories
{
    public interface IIDMRepository
    {
         IIssuerRepository Issuers { get; }
         IProviderRepository Providers { get; }

         IUserRepository Users { get; }
    }
}