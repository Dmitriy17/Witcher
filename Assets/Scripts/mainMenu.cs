using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public Button startButton;
    public AudioClip menu;
    public AudioClip d;
    public Button exitButton;

    public void loadLevel()
    {
        SceneManager.LoadScene(1);
        SoundMenu.instance.Stop(menu);
        SoundManager.instance.Play1(d);
    }
	
	public void quit()
    { 
        Application.Quit();
    }
}
