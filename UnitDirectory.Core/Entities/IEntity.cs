using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDirectory.Core.Entities
{
    public interface IEntity<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
