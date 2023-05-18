using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/Player")]
    public class PlayerStaticData : ScriptableObject
    {
        public GameObject Prefab;

        public int HP;        
    }
}