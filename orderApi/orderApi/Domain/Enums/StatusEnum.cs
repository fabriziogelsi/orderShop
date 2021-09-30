using System.ComponentModel;

namespace orderApi.Domain.Enums
{
    public enum Status
    {
        [Description("PENDING")]
        PENDING = 0,
        [Description("CONFIRMED")]
        CONFIRMED = 1,
        [Description("READY")]
        READY = 2
    }
}
