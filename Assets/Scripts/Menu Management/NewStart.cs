using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewStart : MonoBehaviour {

    [SerializeField] GameObject main;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject buttonList;
    
	// Use this for initialization
	void Start () {
        main.SetActive(true);
        levels.SetActive(false);
        credits.SetActive(false);
        setButtons();
    }

    public void LoadScene(int level) {
        StaticVars.current = level;
        SceneManager.LoadScene(level);
    }

    public void CloseGame() {
        Application.Quit();
    }

    public void GoToMainMenu() {
        main.SetActive(true);
        levels.SetActive(false);
        credits.SetActive(false);
    }

    public void GoToLevels() {
        main.SetActive(false);
        levels.SetActive(true);
        credits.SetActive(false);
    }

    public void GoToCredits() {
        main.SetActive(false);
        levels.SetActive(false);
        credits.SetActive(true);
    }

    public void setButtons() {
        Button[] items = buttonList.GetComponentsInChildren<Button>();

        for(int i = StaticVars.level; i<items.Length; i++)
        {
            items[i].interactable = false;
        }

    }

}
