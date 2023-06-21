using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain.Enum
{
    public enum RefListHealthStatus : int
    {
        [Description("Healthy")]
        healthy = 1,
        [Description("Sick")]
        sick = 2,
    }
}
