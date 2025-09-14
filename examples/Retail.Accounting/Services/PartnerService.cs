using System;
using System.Collections.Generic;
using System.Linq;
using VelocipedeUtils.Examples.Retail.Accounting.Models;

namespace VelocipedeUtils.Examples.Retail.Accounting.Services
{
    public static class PartnerService
    {
        public static void InsertPartner(string partnerName, string email, 
            string phone)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new Partner 
                { 
                    PartnerName = partnerName, 
                    Email = email, 
                    Phone = phone 
                });
                db.SaveChanges();
            }
        }

        public static int? GetPartnerId(string partnerName)
        {
            int? partnerId = 0;
            using (var db = new AccountingContext())
            {
                var PartnerList = db.Partner
                    .Where(c => c.PartnerName == partnerName)
                    .ToList();
                if (PartnerList.Count != 0)
                {
                    partnerId = PartnerList[0].PartnerId;
                }
                else
                {
                    partnerId = null;
                }
            }
            return partnerId;
        }

        public static List<Partner> GetPartners()
        {
            List<Partner> Partners = new List<Partner>();
            using (var db = new AccountingContext())
            {
                Partners = db.Partner.OrderBy(c => c.PartnerId).ToList();
            }
            return Partners;
        }

        public static void UpdatePartner(int partnerId, string partnerName, 
            string email, string phone)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var Partner = db.Partner
                        .Where(ii => ii.PartnerId == partnerId)
                        .ToList()
                        .First();
                    Partner.PartnerName = partnerName;
                    Partner.Email = email;
                    Partner.Phone = phone;
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeletePartner(int partnerId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var Partner = db.Partner
                        .Where(c => c.PartnerId == partnerId)
                        .ToList()
                        .First();
                    db.Remove(Partner);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}