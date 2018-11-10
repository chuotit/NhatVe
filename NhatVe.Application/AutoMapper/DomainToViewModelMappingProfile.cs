using AutoMapper;
using NhatVe.Application.ViewModels.AirPort;
using NhatVe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhatVe.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AirPort, AirPortViewModel>();
        }
    }
}
