using ALAYSchoolGest.Infra.CrossCutting.Helpers._01_Services;

namespace ALAYSchoolGest.Infra.CrossCutting.Helpers._03_Domain;

public class Configuration
{

    public static SecretsConfiguration Secrets { get; set; } = new();
    public static EmailConfiguration Email { get; set; } = new();
    public static SendGridConfiguration SendGrid { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();

}