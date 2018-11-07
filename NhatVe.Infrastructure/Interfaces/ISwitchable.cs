using NhatVe.Infrastructure.Enums;

namespace NhatVe.Infrastructure.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}