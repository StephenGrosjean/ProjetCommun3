using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed, step;


    private bool pongMode;
    private Transform destinationTransform;
    private List<Transform> poses;
    private bool arrived;
    private int i;

    private Vector2 LerpPos;
    private float moveTime;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere((Vector3)LerpPos, 0.1f);
    }

    // Use this for initialization
    void Start () {
        float angle = transform.localEulerAngles.z;
        Vector2 dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Update is called once per frame
    void Update () {
        if (pongMode)
        {
            moveTime += Time.deltaTime * step;
            transform.position = Vector2.Lerp(LerpPos, destinationTransform.position,moveTime);
        }
    }

    public void BulletPong(List<Transform> pos)
    {
        poses = pos;
        LerpPos = transform.position;
        destinationTransform = poses[0];
        pongMode = true;
    }

    public void Next(GameObject obj)
    {
        moveTime = 0;
        obj.GetComponent<RhythmController>().DestroySequence();
        LerpPos = poses[i].position;
        i++;

        if (i == poses.Count)
        {
            Destroy(gameObject);
        }
        else
        {
            destinationTransform = poses[i];
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RhythmParticle")
        {
            if(collision.gameObject == destinationTransform.gameObject)
            {
                    Next(collision.gameObject);
            }
        }
    }
}
