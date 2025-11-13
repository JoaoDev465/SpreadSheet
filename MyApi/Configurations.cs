namespace Spreadsheet;

public  static class Configurations
{
    
}

public static class SmtpConfig
{
    public static int Port { get; set; }
    public static string Host { get; set; } = string.Empty;
    public static string UserName { get; set; } = string.Empty;
    public static string Password { get; set; } = string.Empty;
}