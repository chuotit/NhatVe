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
    public class AirPort : DomainEntity<string>, ISwitchable, IHasSeoMetaData, IHasSoftDelete
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Thumbnail { get; set; }

        public bool IsDeleted { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywork { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
    }
}
