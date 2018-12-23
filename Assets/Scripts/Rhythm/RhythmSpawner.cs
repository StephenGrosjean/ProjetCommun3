using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groupToSpawn;
    [SerializeField] private float spawnRange;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

    private void Start()
    {
       Spawn();
    }

    public void Spawn()
    {
        GameObject group = Instantiate(groupToSpawn, transform.position, Quaternion.identity);
        group.transform.position = Random.insideUnitCircle * spawnRange;
       // group.transform.SetParent(transform);
        //group.GetComponent<RhythmGroup>().SpawnRange = spawnRange;
        //group.GetComponent<RhythmGroup>().Begin();
    }
}
