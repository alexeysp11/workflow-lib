using System.Collections.Generic;
using System.Data.SqlTypes;
using Npgsql;
using VelocipedeUtils.Examples.FirmsAccounting.Models.Data;

namespace VelocipedeUtils.Examples.FirmsAccounting.Models.DbConnections
{
    public class PgDbConnection : IFirmsDbConnection, IDocsDbConnection
    {
        private string ConnString = "Host=localhost;Username=postgres;Database=chtpz_test";

        private string SelectDocsRequest = @"
            SELECT 
                COALESCE(year, 0) AS year,
                COALESCE(jan_sum, 0) AS jan_sum,
                COALESCE(feb_sum, 0) AS feb_sum,
                COALESCE(mar_sum, 0) AS mar_sum,
                COALESCE(apr_sum, 0) AS apr_sum,
                COALESCE(may_sum, 0) AS may_sum,
                COALESCE(jun_sum, 0) AS jun_sum,
                COALESCE(jul_sum, 0) AS jul_sum,
                COALESCE(aug_sum, 0) AS aug_sum,
                COALESCE(sep_sum, 0) AS sep_sum,
                COALESCE(oct_sum, 0) AS oct_sum,
                COALESCE(nov_sum, 0) AS nov_sum,
                COALESCE(dec_sum, 0) AS dec_sum
            FROM test_task.cache_docs
            ORDER BY year;
        ";

#nullable enable
        private string GetSelectRequestFirmCity(string? firmName, 
            string? postCityName, string? jurCityName)
        {
#nullable disable
            string selectRequest = @$"
                SELECT 
                    f.firm_id AS firm_id, 
                    f.name AS firm_name, 
                    pc.name AS post_city_name, 
                    jc.name AS jur_city_name
                FROM test_task.firm f 
                INNER JOIN test_task.city pc ON pc.city_id = f.post_city_id
                INNER JOIN test_task.city jc ON jc.city_id = f.jur_city_id
                WHERE 
                    (
                        UPPER(f.name) LIKE UPPER('{firmName}') 
                            AND UPPER(pc.name) LIKE UPPER('{postCityName}')
                            AND UPPER(jc.name) LIKE UPPER('{jurCityName}')
                    )
                    OR 
                    (
                        UPPER(f.name) LIKE UPPER('{firmName}') 
                ";
            if (postCityName == null || postCityName == string.Empty)
            {
                selectRequest += @$"AND UPPER({SqlInt32.Null}) IS NULL";
            }
            else
            {
                selectRequest += @$"AND UPPER('{postCityName}') IS NULL";
            }
            selectRequest += @$"
                            AND UPPER(jc.name) LIKE UPPER('{jurCityName}')
                    ) 
                    OR 
                    (
                        UPPER(f.name) LIKE UPPER('{firmName}') 
                        AND UPPER(pc.name) LIKE UPPER('{postCityName}') 
                ";
            if (jurCityName == null || jurCityName == string.Empty)
            {
                selectRequest += @$"AND UPPER({SqlInt32.Null}) IS NULL)";
            }
            else
            {
                selectRequest += @$"AND UPPER('{jurCityName}') IS NULL)";
            }
            selectRequest += "ORDER BY firm_id;";
            return selectRequest;
        }

#nullable enable
        public List<FirmCity> GetFirmCity(string? firmName, 
            string? postCityName, string? jurCityName)
        {
#nullable disable
            List<FirmCity> result = new List<FirmCity>();

            NpgsqlConnection connection = new NpgsqlConnection(ConnString);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = GetSelectRequestFirmCity(firmName, 
                    postCityName, jurCityName);
                cmd.CommandType = System.Data.CommandType.Text;
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result.Add( new FirmCity(
                                dataReader.GetInt32(0), 
                                dataReader.GetString(1), 
                                dataReader.GetString(2), 
                                dataReader.GetString(3)
                            ) );
                    }
                    dataReader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Dispose();
            }
            return result;
        }

        public List<FirmCity> GetFirmCity()
        {
            string selectRequest = @"
                SELECT 
                    f.firm_id AS firm_id, 
                    f.name AS firm_name, 
                    pc.name AS post_city_name, 
                    jc.name AS jur_city_name
                FROM test_task.firm f 
                INNER JOIN test_task.city pc ON pc.city_id = f.post_city_id
                INNER JOIN test_task.city jc ON jc.city_id = f.jur_city_id
                ORDER BY firm_id;
            ";

            List<FirmCity> result = new List<FirmCity>();

            NpgsqlConnection connection = new NpgsqlConnection(ConnString);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = selectRequest;
                cmd.CommandType = System.Data.CommandType.Text;
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result.Add( new FirmCity(
                                dataReader.GetInt32(0), 
                                dataReader.GetString(1), 
                                dataReader.GetString(2), 
                                dataReader.GetString(3)
                            ) );
                    }
                    dataReader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Dispose();
            }
            return result;
        }

        public List<DocsCalendarSum> GetDocs(int firmId)
        {
            string funcRequest = System.IO.File.ReadAllText("C:\\Users\\User\\Desktop\\projects\\utility\\employment\\TMK\\TestTask\\VelocipedeUtils.Examples.FirmsAccounting\\SQL\\SelectDocsFirm.sql");
            funcRequest += $"SELECT test_task.GetDocsFirm({firmId});";
            
            List<DocsCalendarSum> result = new List<DocsCalendarSum>();

            NpgsqlConnection connection = new NpgsqlConnection(ConnString);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = funcRequest;
                cmd.ExecuteNonQuery();

                cmd.CommandText = SelectDocsRequest;
                cmd.CommandType = System.Data.CommandType.Text;
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result.Add(
                            new DocsCalendarSum(
                                dataReader.GetInt32(0), 
                                dataReader.GetFloat(1), 
                                dataReader.GetFloat(2), 
                                dataReader.GetFloat(3), 
                                dataReader.GetFloat(4), 
                                dataReader.GetFloat(5), 
                                dataReader.GetFloat(6), 
                                dataReader.GetFloat(7), 
                                dataReader.GetFloat(8), 
                                dataReader.GetFloat(9), 
                                dataReader.GetFloat(10), 
                                dataReader.GetFloat(11), 
                                dataReader.GetFloat(12)
                            )
                        );
                    }
                    dataReader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Dispose();
            }
            return result;
        }

        public List<DocsCalendarSum> GetDocs()
        {
            string funcRequest = System.IO.File.ReadAllText("C:\\Users\\User\\Desktop\\projects\\utility\\employment\\TMK\\TestTask\\VelocipedeUtils.Examples.FirmsAccounting\\SQL\\SelectDocs.sql");
            
            List<DocsCalendarSum> result = new List<DocsCalendarSum>();

            NpgsqlConnection connection = new NpgsqlConnection(ConnString);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = funcRequest;
                cmd.ExecuteNonQuery();

                cmd.CommandText = SelectDocsRequest;
                cmd.CommandType = System.Data.CommandType.Text;
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result.Add(
                            new DocsCalendarSum(
                                dataReader.GetInt32(0), 
                                dataReader.GetFloat(1), 
                                dataReader.GetFloat(2), 
                                dataReader.GetFloat(3), 
                                dataReader.GetFloat(4), 
                                dataReader.GetFloat(5), 
                                dataReader.GetFloat(6), 
                                dataReader.GetFloat(7), 
                                dataReader.GetFloat(8), 
                                dataReader.GetFloat(9), 
                                dataReader.GetFloat(10), 
                                dataReader.GetFloat(11), 
                                dataReader.GetFloat(12)
                            )
                        );
                    }
                    dataReader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Dispose();
            }
            return result;
        }
    }
}