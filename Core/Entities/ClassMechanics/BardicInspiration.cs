using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class BardicInspiration
{
    public int CharacterId { get; set; }
    public int Uses { get; set; } = 0;
    public int DieSize { get; set; } = 6;
}
