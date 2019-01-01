using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;


    [Header("Other")]
    [SerializeField] private GameObject looseMenu;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerSnapshot normalSnap, looseSnap;
    [SerializeField] private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
	
	void Update () {
		
	}

    public void LooseSequence()
    {
        GameObject[] allObj = GameObject.FindGameObjectsWithTag("RhythmParticle");

        foreach(GameObject obj in allObj)
        {
            Destroy(obj);
        }

        GameObject[] objToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");

        foreach (GameObject obj in objToDestroy)
        {
            Destroy(obj);
        }

        looseMenu.SetActive(true);
        looseSnap.TransitionTo(1f);
        //Time.timeScale = 0.1f;
    }

    public void IncrementScore(int incrementBy)
    {
        score += incrementBy;
        scoreText.text = "Score : " + score.ToString();
    }
}
