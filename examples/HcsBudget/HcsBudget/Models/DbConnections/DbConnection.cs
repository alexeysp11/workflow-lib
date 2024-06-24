using System.Collections.Generic; 
using System.Data; 
using System.Globalization; 
using WorkflowLib.Examples.HcsBudget.Models; 
using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.Models.DbConnections
{
    public class DbConnection : BaseDbConnection, IHcsDbConnection, IStateDbConnection
    {
        public void InsertDate(int month, int year)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("InsertDate.sql"), 
                    month, year); 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<Month> GetMonths()
        {
            List<Month> result = new List<Month>(); 
            try 
            {
                SetPathToDb(); 
                string sqlRequest = GetSqlRequest("GetMonths.sql"); 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new Month(
                        System.Convert.ToInt32(row["period_id"]), 
                        System.Convert.ToInt32(row["month_no"]), 
                        System.Convert.ToInt32(row["year"]), 
                        ToTitleCase(row["english"].ToString().ToLower()), 
                        ToTitleCase(row["german"].ToString().ToLower()), 
                        ToTitleCase(row["russian"].ToString().ToLower()), 
                        ToTitleCase(row["spanish"].ToString().ToLower()), 
                        ToTitleCase(row["portugues"].ToString().ToLower()), 
                        ToTitleCase(row["french"].ToString().ToLower()), 
                        ToTitleCase(row["italian"].ToString().ToLower())
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public List<Hcs> GetHcs(int periodId)
        {
            List<Hcs> result = new List<Hcs>(); 
            try 
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("GetHcs.sql"), 
                    periodId); 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new Hcs(
                        System.Convert.ToInt32(row["hcs_id"]), 
                        ToTitleCase(row["hcs_name"].ToString().ToLower()),
                        System.Convert.ToSingle(row["qty"]), 
                        System.Convert.ToSingle(row["price_usd"]), 
                        ToTitleCase(row["participant_name"].ToString().ToLower()),
                        System.Convert.ToSingle(row["total_price"]), 
                        System.Convert.ToInt32(row["month"]), 
                        System.Convert.ToInt32(row["year"]), 
                        System.Convert.ToInt32(row["period_id"])
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }
        public void InsertHcs(int periodId, string hcsName, float qty, float price, 
            List<string> newParticipants)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = @$"
                    INSERT INTO hcs (name, qty, price_usd, period_id)
                    VALUES (
                        '{hcsName}', 
                        {qty.ToString(new CultureInfo("en-US"))}, 
                        {price.ToString(new CultureInfo("en-US"))}, 
                        {periodId}
                    )"; 
                ExecuteSql(sqlRequest); 
                foreach (string item in newParticipants)
                {
                    InsertParticipant(item); 
                    sqlRequest = @$"
                    INSERT INTO hcs_participant (hcs_id, participant_id)
                    VALUES (
                        (SELECT MAX(hcs_id) FROM hcs), 
                        (
                            SELECT MIN(participant_id) 
                            FROM participant 
                            WHERE UPPER(name) LIKE UPPER('{item}')
                        )
                    )"; 
                    ExecuteSql(sqlRequest); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public void UpdateHcs(int hcsId, string hcsName, float qty, float price, 
            List<string> oldParticipants, List<string> newParticipants)
        {
            try 
            {
                SetPathToDb(); 

                // Update hcs table
                string sqlRequest = @$"
                    UPDATE hcs
                    SET 
                        name = '{hcsName}', 
                        qty = {qty.ToString(new CultureInfo("en-US"))}, 
                        price_usd = {price.ToString(new CultureInfo("en-US"))}
                    WHERE hcs_id = {hcsId}"; 
                ExecuteSql(sqlRequest); 

                // Update hcs_participant table
                int minLength = System.Math.Min(oldParticipants.Count, newParticipants.Count); 
                for (int i = 0; i < minLength; i++)
                {
                    sqlRequest = @$"
                        UPDATE hcs_participant
                        SET participant_id = (
                            SELECT MIN(participant_id) 
                            FROM participant
                            WHERE UPPER(name) LIKE UPPER('{newParticipants[i]}')
                        )
                        WHERE hcs_participant_id = (
                            SELECT MIN(hcs_participant_id)
                            FROM hcs_participant
                            WHERE hcs_id = {hcsId} AND participant_id = (
                                SELECT MIN(participant_id) 
                                FROM participant
                                WHERE UPPER(name) LIKE UPPER('{oldParticipants[i]}')
                            )
                        )"; 
                    ExecuteSql(sqlRequest); 
                }
                if (minLength < newParticipants.Count)
                {
                    for (int i = minLength; i < newParticipants.Count; i++)
                    {
                        sqlRequest = $@"
                            INSERT INTO hcs_participant (hcs_id, participant_id)
                            VALUES ({hcsId}, (
                                SELECT participant_id 
                                FROM participant 
                                WHERE UPPER(name) LIKE UPPER('{newParticipants[i]}')
                            ))";
                        ExecuteSql(sqlRequest); 
                    }
                }
                else if (minLength < oldParticipants.Count)
                {
                    for (int i = minLength; i < oldParticipants.Count; i++)
                    {
                        sqlRequest = $@"
                            DELETE FROM hcs_participant 
                            WHERE hcs_participant_id = (
                                SELECT MIN(hcs_participant_id)
                                FROM hcs_participant
                                WHERE hcs_id = {hcsId} AND participant_id = (
                                    SELECT MIN(participant_id) 
                                    FROM participant
                                    WHERE UPPER(name) LIKE UPPER('{oldParticipants[i]}')
                                )
                            )";
                        ExecuteSql(sqlRequest); 
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public void DeleteHcs(int hcsId)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = @$"
                    DELETE FROM hcs_participant WHERE hcs_id = {hcsId};
                    DELETE FROM hcs WHERE hcs_id = {hcsId}; "; 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public void GetDistinctYears(ref List<int> years)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = "SELECT DISTINCT year FROM period"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    years.Add(System.Convert.ToInt32(row["year"])); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<string> SelectAllParticipants()
        {
            List<string> result = new List<string>();
            try 
            {
                SetPathToDb(); 
                string sqlRequest = "SELECT name FROM participant"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(ToTitleCase(row["name"].ToString().ToLower())); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public List<string> SelectAllHcs()
        {
            List<string> result = new List<string>();
            try 
            {
                SetPathToDb(); 
                string sqlRequest = "SELECT name FROM hcs"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(ToTitleCase(row["name"].ToString().ToLower())); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public void InsertParticipant(string name)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("InsertParticipant.sql"), 
                    name); 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public void UpdateParticipant(string oldName, string newName)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("UpdateParticipant.sql"), 
                    newName, oldName); 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public void DeleteParticipant(string name)
        {
            string sqlRequest = @$"
                DELETE FROM participant 
                WHERE UPPER(name) LIKE UPPER('{name}')"; 
            try 
            {
                SetPathToDb(); 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<User> SelectUserSettings()
        {
            List<User> result = new List<User>(); 
            try
            {
                SetPathToDb(); 
                string sqlRequest = GetSqlRequest("SelectUserSettings.sql"); 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new User(
                        System.Convert.ToInt32(row["user_id"]), 
                        ToTitleCase(row["username"].ToString().ToLower()), 
                        ToTitleCase(row["language"].ToString().ToLower()), 
                        ToTitleCase(row["curr_name"].ToString().ToLower()), 
                        row["curr_abbreviation"].ToString(), 
                        ToTitleCase(row["db_name"].ToString().ToLower()), 
                        System.Convert.ToInt32(row["is_protected"]) == 1 ? true : false, 
                        ToTitleCase(row["password"].ToString().ToLower())
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public void UpdateUserSettings(int userId, string language, 
            string currency, string database)
        {
            try
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("UpdateUserSettings.sql"), 
                    language, currency, database, userId); 
                ExecuteSql(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<ReportRow> GetReport(int monthFrom, int yearFrom, int monthTo, int yearTo)
        {
            List<ReportRow> result = new List<ReportRow>(); 
            try
            {
                SetPathToDb(); 
                string sqlRequest = string.Format(GetSqlRequest("GetReport.sql"), 
                    monthFrom, yearFrom, monthTo, yearTo); 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new ReportRow(
                        ToTitleCase(row["p_name"].ToString().ToLower()), 
                        row["hcs_qty"].ToString(), 
                        row["hcs_price_usd"].ToString()
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }
    }
}