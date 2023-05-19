using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public void Spawn(GameObject enemy)
    {
        enemy.transform.position = transform.position;
    }
}
