using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public void Spawn(GameObject player)
    {            
        player.transform.position = transform.position;       
    }
}
