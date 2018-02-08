using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void StartGame() {
        SceneManager.LoadScene("Main");
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void Win() {
        SceneManager.LoadScene("Win");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
