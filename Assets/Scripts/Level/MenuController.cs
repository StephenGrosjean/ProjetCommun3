using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour {
    [SerializeField] private GameManager GM;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioMixerSnapshot normalSnap;
    [SerializeField] private GameObject pauseMenu;

    private int score;
    private int prevScore;

    private string thisScene;

	// Use this for initialization
	void Start () {
        thisScene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P) && !GM.AsLost) {
            Pause();
        }

        prevScore = score;
        score = GM.Score;
        
        if(prevScore != score) {
            scoreText.text = "Score : " + score.ToString();
        }
	}

    public void Restart() {
        normalSnap.TransitionTo(1f);
        SceneManager.LoadScene(thisScene);
        Time.timeScale = 1;

    }

    public void Menu() {
        normalSnap.TransitionTo(1f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Pause() {
        pauseMenu.SetActive(!pauseMenu.active);
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
