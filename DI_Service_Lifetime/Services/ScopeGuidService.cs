namespace DI_Service_Lifetime.Services;

public class ScopeGuidService : IScopedGuidService
{
    private readonly Guid Id;

    public ScopeGuidService()
    {
        Id = Guid.NewGuid();
    }
    public string GetGuid()
    {
        return Id.ToString();
    }
}