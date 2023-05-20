using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Inventory
{    
    public class ModelSlot
    {
        public readonly int SlotId;

        public SlotType SlotType { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }

        public ModelSlot(int slotId)
        {
            SlotId = slotId;
        }
    }
}
