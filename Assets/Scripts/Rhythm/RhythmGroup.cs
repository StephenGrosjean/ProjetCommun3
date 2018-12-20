using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGroup : MonoBehaviour
{
    [SerializeField] private List<Transform> groupObj;

    // Start is called before the first frame update
    void Start()
    {
       foreach(Transform obj in groupObj)
        {
            obj.GetComponent<RhythmController>().AsignOrder(groupObj);
        } 
    }
}
