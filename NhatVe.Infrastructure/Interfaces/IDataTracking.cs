using System;

namespace NhatVe.Infrastructure.Interfaces
{
    public interface IDataTracking
    {
        DateTime DateCreated { set; get; }
        DateTime DateModified { get; set; }
    }
}