using System.Collections.Generic;
using System.Data;

namespace VelocipedeUtils.Examples.HcsBudget.Models.DbConnections
{
    public interface IHcsDbConnection 
    {
        void InsertDate(int month, int year);
        void GetDistinctYears(ref List<int> years);
        List<Month> GetMonths();

        List<Hcs> GetHcs(int periodId);
        List<string> SelectAllHcs();
        void InsertHcs(int periodId, string hcsName, float qty, float price, 
            List<string> newParticipants);
        void UpdateHcs(int hcsId, string hcsName, float qty, float price, 
            List<string> oldParticipants, List<string> newParticipants);
        void DeleteHcs(int hcsId);

        List<string> SelectAllParticipants();
        void InsertParticipant(string name);
        void UpdateParticipant(string oldName, string newName);
        void DeleteParticipant(string name);

        List<User> SelectUserSettings();
        void UpdateUserSettings(int userId, string language, 
            string currency, string database);

        List<ReportRow> GetReport(int monthFrom, int yearFrom, int monthTo, int yearTo);
    }
}