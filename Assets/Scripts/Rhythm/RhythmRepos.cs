using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmRepos : MonoBehaviour {

    [SerializeField] private Transform parent;

    private bool asMoved;

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if (!asMoved)
        {
            if (collision.gameObject != parent)
            {
                if (collision.gameObject.tag == "RhythmParticle")
                {
                    asMoved = true;
                    parent.position = Random.insideUnitCircle * 5;
                }
            }
        }*/
    }
}
