using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    [Header("Circles")]
    [SerializeField] private GameObject four_C;
    [SerializeField] private GameObject six_C;
    [SerializeField] private GameObject ten_C;

    [Header("Other")]
    [SerializeField] private GameObject single;

    [Header("Parameters")]
    [SerializeField] private float spawnRange;
    [SerializeField] private Transform player;


    [Header("Colors")]
    [SerializeField] private Color[] colors;

    private int random;
    private int randomColorIndex;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

    private void Update()
    {
        transform.position = player.position;
    }

    public void Spawn(string koreoEvent)
    {
        randomColorIndex = Mathf.CeilToInt(Random.Range(0, colors.Length-1));

        switch (koreoEvent)
        {
            case "4C":
                Four_Circle(colors[randomColorIndex]);
                break;

            case "6C":
                Six_Circle(colors[randomColorIndex]);
                break;

            case "10C":
                Ten_Circle(colors[randomColorIndex]);
                break;

            case "Single":
                Single(colors[randomColorIndex]);
                break;
            case "10O":
                 Ten_O(colors[randomColorIndex]);
                break;
        }

        
    }


    void Four_Circle(Color color)
    {
        random = Random.Range(-10000, 10000);
        GameObject group = Instantiate(four_C, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Vector3 pos = Random.onUnitSphere + transform.position;

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);

        
        group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
        group.GetComponent<RhythmGroup>().RandomID = random;
        group.GetComponent<RhythmGroup>().SetColor(color);
        random = 0;
    }

    void Six_Circle(Color color)
    {
        random = Random.Range(-10000, 10000);
        GameObject group = Instantiate(six_C, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Vector3 pos = Random.onUnitSphere + transform.position;

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);


        group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
        group.GetComponent<RhythmGroup>().RandomID = random;
        group.GetComponent<RhythmGroup>().SetColor(color);
        random = 0;
    }
    void Ten_Circle(Color color)
    {
        random = Random.Range(-10000, 10000);
        GameObject group = Instantiate(ten_C, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Vector3 pos = Random.onUnitSphere + transform.position;

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);


        group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
        group.GetComponent<RhythmGroup>().RandomID = random;
        group.GetComponent<RhythmGroup>().SetColor(color);
        random = 0;
    }


    void Single(Color color)
    {
        random = Random.Range(-10000, 10000);
        GameObject group = Instantiate(single, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Vector3 pos = Random.onUnitSphere + transform.position;

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);


        group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
        group.GetComponent<RhythmGroup>().RandomID = random;
        group.GetComponent<RhythmGroup>().SetColor(color);
        random = 0;
    }


    void Ten_O(Color color)
    {
        random = Random.Range(-10000, 10000);
        GameObject group = Instantiate(ten_C, transform.position, Quaternion.Euler(Random.Range(15.0f, 45.0f), Random.Range(15.0f, 45.0f), Random.Range(0.0f, 360.0f)));
        Vector3 pos = Random.onUnitSphere + transform.position;

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);


        group.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, 0);
        group.GetComponent<RhythmGroup>().RandomID = random;
        group.GetComponent<RhythmGroup>().SetColor(color);
        random = 0;
    }

   
}
