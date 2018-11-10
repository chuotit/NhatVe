using NhatVe.Application.ViewModels.AirPort;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhatVe.Application.Interfaces
{
    public interface IAirPortService
    {
        AirPortViewModel Add(AirPortViewModel airPortVm);

        void Update(AirPortViewModel airPortVm);

        void Delete(int id);

        List<AirPortViewModel> GetAll();

        List<AirPortViewModel> GetAll(string keyword);

        List<AirPortViewModel> GetAllByParentId(int parentId);

        AirPortViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        List<AirPortViewModel> GetHomeCategories(int top);

        void Save();
    }
}
