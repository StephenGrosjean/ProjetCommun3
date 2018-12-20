using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RhythmController : MonoBehaviour
{

    [SerializeField] private List<Transform> objOrder;
    [SerializeField] private bool asTouched;

    public GameObject toDestroy;

    private bool callOnce = true;

    private Color gizmoColor;

    private void Start()
    {
        gizmoColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));  
    }

    private void OnDrawGizmos()
    {
        if (toDestroy != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawLine(transform.position, toDestroy.transform.position);
        }
    }

    void Update()
    {
        if (asTouched && callOnce)
        {
            callOnce = false;
            AsignToDestroy(objOrder[1].gameObject);
            StartDestroyAsign(1);
            Invoke("DOrder", 0.1f);
        }
    }

    public void AsignOrder(List<Transform> obj)
    {
        objOrder = obj;
        objOrder = objOrder.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();

        foreach(Transform o in objOrder){
            Debug.Log(Vector2.Distance(this.transform.position, o.transform.position));
        }
    }
    

    public void StartDestroyAsign(int id)
    {
        foreach(Transform obj in objOrder)
        {
            if (obj != this && id < objOrder.Count)
            {
               
                obj.GetComponent<RhythmController>().AsignToDestroy(objOrder[id].gameObject);
                id++;
            }
        }
    }

    public void AsignToDestroy(GameObject objDestroy)
    {
        toDestroy = objDestroy;
    }

    void DOrder()
    {
        StartCoroutine("DestroySequence", 0.2f);
    }

    public IEnumerator DestroySequence(float time)
    {
        time += 0.2f;
        Debug.Log("Order to destroy GM : " + gameObject.name + " in : " + time);
        if (toDestroy != null)
        {
            toDestroy.GetComponent<RhythmController>().StartCoroutine("DestroySequence", time);
        }
        yield return new WaitForSeconds(time);
        Debug.Log("Destroyed : " + gameObject.name);
        Destroy(gameObject);
    }
}
