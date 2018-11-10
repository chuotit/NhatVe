using NhatVe.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhatVe.Application.ViewModels.AirPort
{
    public class AirPortViewModel
    {
        public string Id { get; set; }
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
