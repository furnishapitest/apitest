using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Address : BaseEntity
    {
        public Address(string addressLine, string district, string zipCode, long cityId)
        {
            AddressLine = addressLine;
            District = district;
            ZipCode = zipCode;
            CityId = cityId;
        }

        public string AddressLine { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
    }
}
