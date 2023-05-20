using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Inventory.Item
{
    [CreateAssetMenu(fileName ="Item", menuName = "Item")]
    public class ItemData:ScriptableObject
    {
        public int Id;
        public Sprite Sprite;
        public string Name;
    }
}
