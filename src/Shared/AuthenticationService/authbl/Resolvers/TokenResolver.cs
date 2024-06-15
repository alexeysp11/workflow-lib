using System.Data;
using WorkflowLib.DbConnections;
using WorkflowLib.Models.ErrorHandling;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// The class that resolves tokens.
/// </summary>
public class TokenResolver
{
    /// <summary>
    /// Database connection object.
    /// </summary>
    private PgDbConnection PgDbConnection { get; }
    /// <summary>
    /// Connection string for using a database.
    /// </summary>
    private string ConnectionString { get; }
    /// <summary>
    /// Number of hours during which the token will be valid.
    /// </summary>
    private int HoursToAdd { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public TokenResolver()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
        HoursToAdd = 5;
    }

    /// <summary>
    /// Method for creating a token and saving it in the database.
    /// </summary>
    public void CreateToken(SessionToken response)
    {
        try
        {
            response.TokenGuid = System.Guid.NewGuid().ToString();
            response.TokenBeginDt = System.DateTime.Now;
            response.TokenEndDt = response.TokenBeginDt.AddHours(HoursToAdd);
            PgDbConnection.ExecuteSqlCommand(@$"-- 
insert into public.deliveryservice_auth_token(session_token_guid,begin_datetime,end_datetime)
values ('{response.TokenGuid}','{response.TokenBeginDt}','{response.TokenEndDt}');");
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
    }
    /// <summary>
    /// Method for obtaining a token by user GUID.
    /// </summary>
    public void GetTokenByGuid(System.Guid guid)
    {
//         var dataTable = PgDbConnection.ExecuteSqlCommand(@$"
// select
// 	at.deliveryservice_auth_token_id,
// 	at.session_token_guid,
// 	at.begin_datetime,
// 	at.end_datetime
// from public.deliveryservice_auth_token at
// where at.session_token_guid = '{guid}';");
        // TODO: check the number of rows and columns' names
        // for example, the number of rows is correct if only one record was returned
        // var dt1 = (System.DateTime)dataTable.Rows[0][2];
        // var dt2 = (System.DateTime)dataTable.Rows[0][3];
        // return new SessionVSURequest
        // {
        //     SessionTokenGuid = guid,
        //     TokenActivityBegin = dt1,
        //     TokenActivityEnd = dt2
        // }; 
    }
}
