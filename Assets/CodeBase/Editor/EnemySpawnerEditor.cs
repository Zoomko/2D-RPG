using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(EnemySpanwer))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmos(EnemySpanwer target, GizmoType gizmoType)
        {
            Vector3 position = target.transform.position;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}