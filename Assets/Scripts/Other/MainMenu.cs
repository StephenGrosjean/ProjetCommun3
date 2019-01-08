using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool isInTutorial;
    [SerializeField] private GameObject tutorialButton;

    private void Start() {
        if (!isInTutorial) {
            setScore();
        }
    }

    void setScore() {
        text.text = "Max Percentage : " + PlayerPrefs.GetInt("MaxPercentage").ToString() + "%" + "\n" + "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString();

        if (PlayerPrefs.GetInt("AsPlayedTutorial") == 1) {
            tutorialButton.SetActive(true);
        }
        else {
            tutorialButton.SetActive(false);

        }
    }

    public void Begin() {
        if (PlayerPrefs.GetInt("AsPlayedTutorial") == 1) {
            SceneManager.LoadScene("Main");
        }
        else {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void Run() {
        PlayerPrefs.SetInt("AsPlayedTutorial", 1);
        SceneManager.LoadScene("Main");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Reset() {
        PlayerPrefs.SetInt("MaxPercentage", 0);
        PlayerPrefs.SetInt("MaxScore", 0);
        PlayerPrefs.SetInt("AsPlayedTutorial", 0);
        setScore();
    }

    public void Return() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }


}
