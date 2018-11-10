using NhatVe.Infrastructure.SharedKernel;
using NhatVe.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using NhatVe.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatVe.Data.Entities
{
    [Table("AirPorts")]
    public class AirPort : DomainEntity<int>, ISwitchable, IHasSeoMetaData, IHasSoftDelete
    {
        public AirPort()
        {

        }

        public AirPort(string name, string airCode, string shortName, string city, double lat, double lng, string thumbnail, bool isDeleted, string seoPageTitle, string seoAlias, string seoKeyworks, string seoDescription, Status status)
        {
            AirCode = airCode;
            Name = name;
            ShortName = shortName;
            City = city;
            Lat = lat;
            Lng = lng;
            Thumbnail = thumbnail;
            IsDeleted = isDeleted;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeyworks = seoKeyworks;
            SeoDescription = seoDescription;
            Status = status;
        }

        public string AirCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Thumbnail { get; set; }

        public bool IsDeleted { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeyworks { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
    }
}
