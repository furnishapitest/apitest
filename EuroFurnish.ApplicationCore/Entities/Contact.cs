using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Contact : BaseEntity
    {
        public Contact(string phone, string fax, string mobilePhone, string webUrl, string eMail)
        {
            Phone = phone;
            Fax = fax;
            MobilePhone = mobilePhone;
            WebUrl = webUrl;
            EMail = eMail;
        }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string MobilePhone { get; set; }
        public string WebUrl { get; set; }
        public string EMail { get; set; }
    }
}
