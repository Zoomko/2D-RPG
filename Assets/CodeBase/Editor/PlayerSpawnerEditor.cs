using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(PlayerSpawner))]
    public class PlayerSpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmos(PlayerSpawner target, GizmoType gizmoType)
        {
            Vector3 position = target.transform.position;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}