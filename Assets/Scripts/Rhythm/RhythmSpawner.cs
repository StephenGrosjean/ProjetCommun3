using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groupToSpawn;
    [SerializeField] private float spawnRange;
    [SerializeField] private Transform player;
    [SerializeField] private int random;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

    private void Start()
    {

    }

    private void Update()
    {
        transform.position = player.position;
    }

    public void Spawn(string koreoEvent)
    {

        switch (koreoEvent)
        {
            case "Normal":
                random = Random.Range(-10000, 10000);
                GameObject group = Instantiate(groupToSpawn, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                Vector3 pos = Random.onUnitSphere + transform.position;

                float randomX = Random.Range(-spawnRange, spawnRange);
                float randomY = Random.Range(-spawnRange, spawnRange);


                group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
                group.GetComponent<RhythmGroup>().RandomID = random;
                random = 0;
                break;
        }

        //group.transform.SetParent(transform);
        //group.GetComponent<RhythmGroup>().SpawnRange = spawnRange;
        //group.GetComponent<RhythmGroup>().Begin();
    }
}
