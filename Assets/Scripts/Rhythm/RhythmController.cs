using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;
using SonicBloom.Koreo;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private ParticleSystem particleGlow;
    [SerializeField] private List<Transform> objOrder;
    [SerializeField] private bool asTouched;
    [SerializeField] private GameObject particle;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private int randomID;
    public int RandomID
    {
        get { return randomID; }
        set { randomID = value; }
    }

    private GameObject toDestroy;
    
    private bool callOnce = true;
    private bool startOnce = true;

    private Color gizmoColor;
    private Rigidbody2D rigid;
    private IDManager idManager;
    private GameManager gameManager;
    private RhythmGroup RG;

    [SerializeField] private bool isBugged;
    public int partNumber;
    private bool canCheckBugged;
    public List<Transform> currentObj;
    public int objCount;

    private void OnDrawGizmos()
    {
            Gizmos.color = gizmoColor;
            Gizmos.DrawLine(transform.position, player.position);
    }

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        idManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<IDManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        RG = transform.parent.GetComponent<RhythmGroup>();

        gizmoColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = GetComponent<Rigidbody2D>();

    }

    void Update() {


        if (asTouched && callOnce) {
            StartDestroyAsign();
            callOnce = false;
            AsignToDestroy(objOrder[1].gameObject);
        }

        if (Time.timeScale == 1 && !RG.NoFollow) {
            transform.position = Vector2.Lerp(transform.position, player.position, speed / 1000);
        }


        if (!isBugged && canCheckBugged && gameObject.name != "Single") {
            currentObj.Clear();
            objCount = 0;
            foreach (Transform obj in objOrder) {
                if (obj != null) {
                    currentObj.Add(obj);
                }
            }
            objCount = currentObj.Count;

            if (objCount < partNumber && !isBugged) {
                StartCoroutine("DestroyIfBugged");
            }
        }
    }


    public void SetColor(Color color)
    {
        //GetComponent<SpriteRenderer>().color = color;
        //particleGlow.startColor = color;
    }

    public void AsignOrder(List<Transform> obj)
    {
        objOrder = obj;
        objOrder = objOrder.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();

        Invoke("tog", 0.5f);
    }
    
    void tog() {
        partNumber = objOrder.Count;
        canCheckBugged = true;
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
        gameManager.IncrementScore(10);
        PlaySound();
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!idManager.CheckIfUsed(randomID))
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                asTouched = true;
                collision.rigidbody.isKinematic = true;
                collision.collider.isTrigger = true;
                collision.gameObject.GetComponent<Bullet>().BulletPong(objOrder);
                collision.gameObject.GetComponent<Bullet>().Next(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void PlaySound() {
        source.PlayOneShot(clip);
    }

    IEnumerator DestroyIfBugged() {
        isBugged = true;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
