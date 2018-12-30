using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject looseMenu;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerSnapshot normalSnap, looseSnap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
}
