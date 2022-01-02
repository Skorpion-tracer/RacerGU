using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public ItemInfo Info { get; set; }
    }
}
