namespace ALAYSchoolGest.Infra.CrossCutting.Helpers._01_Services;

public class SecretsConfiguration
{
    public string ApiKey { get; set; } = String.Empty;
    public string JwtPrivateKey { get; set; } = String.Empty;
    public string PasswordSaltKey { get; set; } = String.Empty;
}