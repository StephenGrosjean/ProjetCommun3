using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RhythmController : MonoBehaviour
{

    [SerializeField] private List<Transform> objOrder;
    [SerializeField] private bool asTouched;
    [SerializeField] private GameObject particle;


    private GameObject toDestroy;
    
    private bool callOnce = true;
    private bool startOnce = true;

    private Color gizmoColor;

    /*private void OnDrawGizmos()
    {
        if (toDestroy != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawLine(transform.position, toDestroy.transform.position);
        }
    }*/

    private void Start()
    {
        gizmoColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

    }

    void Update()
    {
        if (asTouched && callOnce)
        {
            StartDestroyAsign();
            callOnce = false;
            AsignToDestroy(objOrder[1].gameObject);
            //Invoke("DOrder", 0.1f);
        }
    }

    public void AsignOrder(List<Transform> obj)
    {
        objOrder = obj;
        objOrder = objOrder.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
    }
    

    public void StartDestroyAsign()
    {
       int id = 1;
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
        StartCoroutine("DestroySequence", 0);
    }


    public void DestroySequence()
    {
        Instantiate(particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(particle, transform.position, Quaternion.identity);
            asTouched = true;
            collision.rigidbody.isKinematic = true;
            collision.collider.isTrigger = true;
            collision.gameObject.GetComponent<Bullet>().BulletPong(objOrder);
            collision.gameObject.GetComponent<Bullet>().Next(gameObject);

            //Destroy(collision.gameObject);
        }
    }
}
