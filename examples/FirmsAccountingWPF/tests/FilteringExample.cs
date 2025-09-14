using System.Collections.Generic;
using VelocipedeUtils.Examples.FirmsAccounting.Models.DbConnections;
using VelocipedeUtils.Examples.FirmsAccounting.Models.Data;

namespace VelocipedeUtils.Examples.FirmsAccounting.Examples
{
    public class FirmsAccountingExample
    {
        private IFirmsDbConnection FilteringDbConnection = new PgDbConnection();

        public void PrintAllFilled()
        {
            string firmName = "FiRM1";
            string postCityName = "city1";
            string jurCityName = "cITY1";

            string msg = "Case: all filled.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            { 
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintFirmEmpty()
        {
            string firmName = string.Empty;
            string postCityName = "City1";
            string jurCityName = "citY2";

            string msg = "Case: firm name is empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            { 
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintFirmNull()
        {
#nullable enable
            string? firmName = null;
#nullable disable
            string postCityName = "city1";
            string jurCityName = "cITY2";

            string msg = "Case: firm name is null.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            { 
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintPostCityEmpty()
        {
            string firmName = "firm2";
            string postCityName = string.Empty;
            string jurCityName = "citY2";

            string msg = "Case: post city is empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            { 
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintPostCityNull()
        {
            string firmName = "fIrm14";
#nullable enable
            string? postCityName = null;
#nullable disable
            string jurCityName = "city4";

            string msg = "Case: post city is null.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            { 
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintJurCityEmpty()
        {
            string firmName = "firm12";
            string postCityName = "CiTy3";
            string jurCityName = string.Empty;

            string msg = "Case: jur city is empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintJurCityNull()
        {
            string firmName = "fIrm9";
            string postCityName = "city2";
#nullable enable
            string? jurCityName = null;
#nullable disable

            string msg = "Case: jur city is null.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintFirmAndPostCityEmpty()
        {
            string firmName = string.Empty;
            string postCityName = string.Empty;
            string jurCityName = "City2";

            string msg = "Case: firm name and post city are empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintFirmAndJurCityEmpty()
        {
            string firmName = string.Empty;
            string postCityName = "CiTy1";
            string jurCityName = string.Empty;

            string msg = "Case: firm name and jur city are empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintPostCityAndJurCityEmpty()
        {
            string firmName = "Firm4";
            string postCityName = string.Empty;
            string jurCityName = string.Empty;

            string msg = "Case: post city and jur city are empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

        public void PrintAllEmpty()
        {
            string firmName = string.Empty;
            string postCityName = string.Empty;
            string jurCityName = string.Empty;

            string msg = "Case: firm name, post city and jur city are empty.\n";
            msg += $"Searching for firm: '{firmName}', post city: '{postCityName}', jur city: '{jurCityName}'";
            System.Console.WriteLine(msg);

            try
            {
                PrintCityFirm(firmName, postCityName, jurCityName);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Exception: {e}");
            }
            System.Console.WriteLine("");
        }

#nullable enable
        public void PrintCityFirm(string? firmName, string? postCityName, 
            string? jurCityName)
        {
#nullable disable

            List<FirmCity> result = new List<FirmCity>();
            try
            {
                result = FilteringDbConnection.GetFirmCity(firmName, postCityName, 
                    jurCityName);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            System.Console.WriteLine("| firm_name\t| post_city_name\t| jur_city_name\t|");
            foreach (var item in result)
            {
                System.Console.WriteLine($"| {item.FirmName} \t| {item.PostalAddressCity} \t\t| {item.JurAddressCity} \t|");
            }
        }
    }
}