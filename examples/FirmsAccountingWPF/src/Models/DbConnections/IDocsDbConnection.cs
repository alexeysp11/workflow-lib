using System.Collections.Generic;
using WorkflowLib.Examples.FirmsAccounting.Models.Data; 

namespace WorkflowLib.Examples.FirmsAccounting.Models.DbConnections
{
    public interface IDocsDbConnection
    {
        List<DocsCalendarSum> GetDocs(int firmId); 
        List<DocsCalendarSum> GetDocs(); 
    }
}