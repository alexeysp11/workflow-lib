using System;
using System.Collections.Generic;

namespace VelocipedeUtils.Examples.Retail.Accounting.Models
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<ImportDoc> ImportDocs { get; set; }
        public List<ExportDoc> ExportDocs { get; set; }
    }
}
