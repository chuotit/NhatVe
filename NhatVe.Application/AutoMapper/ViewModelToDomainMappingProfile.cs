using AutoMapper;
using NhatVe.Application.ViewModels.AirPort;
using NhatVe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhatVe.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AirPortViewModel, AirPort>()
                .ConstructUsing(c => new AirPort(c.Name, c.AirCode, c.ShortName, c.City, c.Lat, c.Lng, c.Thumbnail, c.IsDeleted, c.SeoPageTitle, c.SeoAlias, c.SeoKeyworks,c.SeoDescription, c.Status));
        }
    }
}
