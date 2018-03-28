using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public Transform canvas;
    public Transform menuCanvas;

    public void StartGame() {
        SceneManager.LoadScene("Main");
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Win() {
        SceneManager.LoadScene("Win");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
            //Cursor.visible = true;
        }
    }

    public void PauseGame() {
        if (!canvas.gameObject.activeSelf) {
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
}
