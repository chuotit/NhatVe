using System;

namespace NhatVe.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { set; get; }
        DateTime DateModified { get; set; }
    }
}