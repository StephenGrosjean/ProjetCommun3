using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player, deathParticle;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;


    [Header("Other")]
    [SerializeField] private GameObject looseMenu;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerSnapshot normalSnap, looseSnap;
    [SerializeField] private AudioClip death;
    [SerializeField] private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private bool asLost;
    public bool AsLost {
        get { return AsLost; }
    }

    private AudioSource source;


    void Start () {
        source = GetComponent<AudioSource>();
	}

    public void LooseSequence()
    {
        asLost = true;
        source.PlayOneShot(death);
        StartCoroutine("Loose");
    }

    IEnumerator Loose() {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        looseSnap.TransitionTo(1f);
        GameObject[] allObj = GameObject.FindGameObjectsWithTag("RhythmParticle");

        foreach (GameObject obj in allObj) {
            Destroy(obj);
        }

        GameObject[] objToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");

        foreach (GameObject obj in objToDestroy) {
            Destroy(obj);
        }
        yield return new WaitForSeconds(2.5f);
        looseMenu.SetActive(true);

    }

    public void IncrementScore(int incrementBy)
    {
        score += incrementBy;
        scoreText.text = "Score : " + score.ToString();
    }
}
