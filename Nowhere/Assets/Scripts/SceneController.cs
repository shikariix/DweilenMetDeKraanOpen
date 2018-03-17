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


    //vanaf hier is de code die ik heb toegevoegd
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
            Cursor.visible = true;
        }
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
}
