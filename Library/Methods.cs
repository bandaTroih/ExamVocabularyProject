using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vocabulary
{
    public interface IEntity { int Id { get; set; } }
    public static class Methods
    {
        public static int GetLastElementId(IEnumerable<IEntity> lst)
            => (lst.OrderByDescending(w => w.Id).FirstOrDefault() is null) ? 0 : lst.OrderByDescending(w => w.Id).FirstOrDefault().Id;
    }
}
