using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI text;

    private void Start() {
        setScore();
    }

    void setScore() {
        text.text = "Max Percentage : " + PlayerPrefs.GetInt("MaxPercentage").ToString() + "%" + "\n" + "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString();
    }

    public void Begin() {
        SceneManager.LoadScene("Main");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Reset() {
        PlayerPrefs.SetInt("MaxPercentage", 0);
        PlayerPrefs.SetInt("MaxScore", 0);
        setScore();
    }
}
