using ALAYSchoolGest.Infra.CrossCutting.Helpers._01_Services;

namespace ALAYSchoolGest.Infra.CrossCutting.Helpers._03_Domain;

public class Configuration
{

    public static SecretsConfiguration Secrets { get; set; } = new();
    public static EmailConfiguration Email { get; set; } = new();
    public static SendGridConfiguration SendGrid { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();









    //// TOKEN- Formatos(JWT Jason Web Token)
    //public static string JwtKey = "lYmgpKdIWkusZjuV69poIg==GBEC8pcePkWlTCSi5GQaYg==";
    //public static string ApiKeyName = "api_key";
    //public static string ApiKey = "curso_api_lYmgpKdIWkusZjuV69poIg==G";
    ////public static SmtpConfiguration Smtp = new();

}