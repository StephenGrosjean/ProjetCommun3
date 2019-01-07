using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using SonicBloom.Koreo.Players;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textPercentage;
    [SerializeField] private SimpleMusicPlayer musicPlayer;

    [SerializeField] private GameObject player, deathParticle;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText, winScoreText;


    [Header("Other")]
    [SerializeField] private GameObject looseMenu, winMenu;
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
        get { return asLost; }
    }

    private int percentage, prevPercentage;
    private bool finished;
    private int totalSample;
    private AudioSource source;


    void Start () {
        totalSample = musicPlayer.GetTotalSampleTimeForClip(musicPlayer.GetCurrentClipName());
        source = GetComponent<AudioSource>();
	}

    private void Update() {
        prevPercentage = percentage;
        percentage = (musicPlayer.GetSampleTimeForClip(musicPlayer.GetCurrentClipName())*100)/totalSample;
        if(percentage != prevPercentage) {
            textPercentage.text = percentage.ToString() + " %";
        }

        if(percentage > 99) {
            percentage = 100;
        }
        if(percentage == 100 && !finished) {
            finished = true;
            Finished();
        }
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
        PlayerPrefs.SetInt("MaxPercentage", percentage);
        PlayerPrefs.SetInt("MaxScore", score);
    }

    public void IncrementScore(int incrementBy)
    {
        score += incrementBy;
        scoreText.text = "Score : " + score.ToString();
        winScoreText.text = "Score : " + score.ToString();

    }

    void Finished() {
        PlayerPrefs.SetInt("MaxPercentage", percentage);
        PlayerPrefs.SetInt("MaxScore", score);


        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        GameObject[] allObj = GameObject.FindGameObjectsWithTag("RhythmParticle");

        foreach (GameObject obj in allObj) {
            Destroy(obj);
        }

        GameObject[] objToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");

        foreach (GameObject obj in objToDestroy) {
            Destroy(obj);
        }

        winMenu.SetActive(true);
    }
}
