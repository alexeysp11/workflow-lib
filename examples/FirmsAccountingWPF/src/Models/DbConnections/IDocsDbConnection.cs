using System.Collections.Generic;
using VelocipedeUtils.Examples.FirmsAccounting.Models.Data;

namespace VelocipedeUtils.Examples.FirmsAccounting.Models.DbConnections
{
    public interface IDocsDbConnection
    {
        List<DocsCalendarSum> GetDocs(int firmId);
        List<DocsCalendarSum> GetDocs();
    }
}