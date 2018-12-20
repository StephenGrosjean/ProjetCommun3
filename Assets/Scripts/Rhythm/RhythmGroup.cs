using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGroup : MonoBehaviour
{
    [SerializeField] private List<Transform> groupObj;
    [SerializeField] private GameObject rPart;

    [SerializeField] private int partNumber;

    [SerializeField] private float spawnRange;
    public float SpawnRange
    {
        set { spawnRange = value; }
    }


    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }*/

    private void Awake()
    {
        for (int i = 0; i < partNumber; i++)
        {
            GameObject part = Instantiate(rPart, transform.position, Quaternion.identity);
            part.transform.SetParent(transform);
            groupObj.Add(part.transform);
        }

        foreach (Transform obj in groupObj)
        {
            obj.transform.position = Random.insideUnitCircle * spawnRange;
        }

        foreach (Transform obj in groupObj)
        {
            obj.GetComponent<RhythmController>().AsignOrder(groupObj);
        }
    }

    public void Begin()
    {
        
    }
}
