using System.Text;
using WokflowLib.Authentication.Models.ConfigParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// The class that helps to use configs.
/// </summary>
public class ConfigHelper
{
    /// <summary>
    /// Get policies for checking user credentials, from the config file.
    /// </summary>
    public CheckUCConfig GetUCConfigs(
        bool isLoginRequired = true, 
        bool isEmailRequired = false, 
        bool isPhoneNumberRequired = false, 
        bool isPasswordRequired = true)
    {
        // 
        return new CheckUCConfig()
        {
            IsLoginRequired = isLoginRequired,
            IsEmailRequired = isEmailRequired,
            IsPhoneNumberRequired = isPhoneNumberRequired,
            IsPasswordRequired = isPasswordRequired
        };
    }

    /// <summary>
    /// Get authentiacation DB settings.
    /// </summary>
    public AuthDBSettings GetAuthDBSettings(
        string dbProvider = "", 
        string connectionString = "", 
        string usersTableName = "users", 
        string loginColName = "login",
        string emailColName = "email", 
        string phoneColName = "phone_number", 
        string pswdColName = "password")
    {
        // 
        if (string.IsNullOrWhiteSpace(dbProvider))
            dbProvider = "postgres";
        if (string.IsNullOrWhiteSpace(connectionString))
            connectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        // 
        var sbAddUserSQL = new StringBuilder();
        var sbVUC = new StringBuilder();
        //
        sbAddUserSQL.Append("insert into ").Append(usersTableName).Append(" (")
            .Append(loginColName).Append(", ")
            .Append(emailColName).Append(", ")
            .Append(phoneColName).Append(", ")
            .Append(pswdColName).Append(") ")
            .Append("values ({0}, {1}, {2}, {3});");
        sbVUC.Append("select count(*) qty from ").Append(usersTableName).Append(" u ")
            .Append("where u.").Append(loginColName).Append(" = {0}").Append(" and u.").Append(pswdColName).Append(" = {1};");
        //
        return new AuthDBSettings
        {
            DBProvider = dbProvider,
            ConnectionString = connectionString,
            AddUserSQL = sbAddUserSQL.ToString(),
            VerifyUserCredentialsSQL = sbVUC.ToString()
        };
    }
}