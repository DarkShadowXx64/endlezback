namespace Core.Interface;

public interface IJwtValidator
{
    public Guid ValidateToken(string token);
}