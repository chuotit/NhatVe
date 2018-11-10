using AutoMapper;
using AutoMapper.QueryableExtensions;
using NhatVe.Application.Interfaces;
using NhatVe.Application.ViewModels.AirPort;
using NhatVe.Data.Entities;
using NhatVe.Data.IRepositories;
using NhatVe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhatVe.Application.Implementations
{
    public class AirPortService : IAirPortService
    {
        private IAirPortRepository _airPortRepository;
        private IUnitOfWork _unitOfWork;
        public AirPortService(IAirPortRepository airPortRepository, IUnitOfWork unitOfWork)
        {
            _airPortRepository = airPortRepository;
            _unitOfWork = unitOfWork;
        }

        public AirPortViewModel Add(AirPortViewModel airPortVm)
        {
            var airPort = Mapper.Map<AirPortViewModel, AirPort>(airPortVm);
            _airPortRepository.Add(airPort);
            return airPortVm;
        }

        public void Delete(int id)
        {
            _airPortRepository.Remove(id);
        }

        public List<AirPortViewModel> GetAll()
        {
            return _airPortRepository.FindAll().OrderBy(x=>x.Id).ProjectTo<AirPortViewModel>().ToList();
        }

        public List<AirPortViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _airPortRepository.FindAll(x => x.Name.Contains(keyword) || x.AirCode.Contains(keyword) || x.City.Contains(keyword))
                    .OrderBy(x => x.Id).ProjectTo<AirPortViewModel>().ToList();
            else
                return _airPortRepository.FindAll().OrderBy(x => x.Id).ProjectTo<AirPortViewModel>().ToList();
        }

        public List<AirPortViewModel> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public AirPortViewModel GetById(int id)
        {
            return Mapper.Map<AirPort, AirPortViewModel>(_airPortRepository.FindById(id));
        }

        public List<AirPortViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(AirPortViewModel airPortVm)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
