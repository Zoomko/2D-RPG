using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
    public class Settings : ScriptableObject
    {
        public string PersistentPath;
    }
}
