using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers;

public static class EntityHelpers
{
    public static string GetEnumName<TEnum>(int value)
        where TEnum : Enum
    {
        return Enum.GetName(typeof(TEnum), value) ?? string.Empty;
    }
}
