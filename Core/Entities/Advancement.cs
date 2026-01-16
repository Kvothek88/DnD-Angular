using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Advancement : BaseEntity
{
    public int CharacterId { get; set; }
    public int Level { get; set; }
}
