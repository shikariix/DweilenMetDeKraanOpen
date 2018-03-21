using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public Transform canvas;
    public Transform menuCanvas;
    public Texture2D c;

    public void StartGame() {
        SceneManager.LoadScene("Main");
        StartCoroutine("WaitForStart"); //zie beneden
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

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
            Cursor.visible = true;
        }
        Cursor.SetCursor(c, Vector2.zero, CursorMode.Auto);
    }

    public void PauseGame() {
        if (!canvas.gameObject.active) {
            canvas.gameObject.SetActive(true);
            StartCoroutine("SetTimeScale");
        }
        else {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public IEnumerator SetTimeScale() {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    IEnumerator WaitForStart() {
        yield return new WaitForSeconds(5); //hoe laat ik t spel wachten met beginnen...?
    }
}
