using Assets.CodeBase.Data.PersistentData;
using UnityEngine;

namespace Assets.CodeBase.Extentions
{
    public static class VectorExtention
    {
        public static Vector ToSimpleVector(this Vector3 vector3)
        {
            var simpleVector = new Vector() { X = vector3.x, Y = vector3.y, Z = vector3.z };
            return simpleVector;
        }

        public static Vector3 ToVector3(this Vector simpleVector)
        {
            var vector = new Vector3(simpleVector.X, simpleVector.Y, simpleVector.Z);
            return vector;
        }
    }
}
