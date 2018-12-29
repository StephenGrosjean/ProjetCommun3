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

    [SerializeField] private int randomID;
    public int RandomID
    {
        get { return randomID; }
        set { randomID = value; }
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
            part.name = "R1_" + i.ToString();
            part.transform.SetParent(transform);
            groupObj.Add(part.transform);
        }

        int a = 0;
        foreach (Transform obj in groupObj)
        {
            a++;
            float x = Mathf.Cos(((Mathf.Deg2Rad * 360) / partNumber) * a);
            float y = Mathf.Sin(((Mathf.Deg2Rad * 360) / partNumber) * a);
            Vector2 pos = new Vector2(x, y);
            obj.transform.localPosition= pos * spawnRange;
        }

        foreach (Transform obj in groupObj)
        {
            obj.GetComponent<RhythmController>().AsignOrder(groupObj);
        }
    }

    private void Start()
    {
        foreach (Transform obj in groupObj)
        {
            obj.GetComponent<RhythmController>().RandomID = randomID;
        }
    }

    public void Begin()
    {
        
    }
}
