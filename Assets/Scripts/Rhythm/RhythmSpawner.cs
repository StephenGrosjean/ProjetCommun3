using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groupToSpawn;

    public void Spawn()
    {
        Instantiate(groupToSpawn, transform.position, Quaternion.identity);
    }
}
