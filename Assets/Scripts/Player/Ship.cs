using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    [SerializeField] private bool invincible;
    [SerializeField] private GameManager GM;
    [SerializeField] private int speed;
    [SerializeField] private float maxVel;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float delayFire;

    private Rigidbody2D rigid;
    private int Vaxis, Haxis;

    private bool canShoot = true;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //Vertical 
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vaxis = 1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vaxis = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vaxis = -1;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            Vaxis = 0;
        }


        //Horizontal
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Haxis = 1;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Haxis = 0;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Haxis = -1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Haxis = 0;
        }

        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine("shootDelay");
            Shoot();
        }

        
    }

    private void FixedUpdate()
    {
        if (rigid.velocity.magnitude < maxVel)
        {
            rigid.AddForce(new Vector2(Haxis * speed, Vaxis * speed));
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RhythmParticle")
        {
            if (!invincible) {
                GM.LooseSequence();
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(shootPrefab, shootPoint.position, transform.rotation);
        bullet.name = "Bullet_" + Random.Range(0, 100).ToString();
    }

    IEnumerator shootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(delayFire);
        canShoot = true;
    }
}
