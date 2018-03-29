using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public Transform canvas;
    public Transform menuCanvas;
    public Texture2D c;

    private Texture2D cur;
    private bool isVisible;

    public void StartGame() {
        SceneManager.LoadScene("Main");
    }

    public void GameOver() {
        cur = c;
        isVisible = true;
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        cur = c;
        isVisible = true;
        SceneManager.LoadScene("Win");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void MainMenu()
    {
        isVisible = true;
        cur = c;
        SceneManager.LoadScene("Menu");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
            //Cursor.visible = true;
        }
        Cursor.visible = isVisible;
        Cursor.SetCursor(cur, Vector2.zero, CursorMode.Auto);
    }

    public void PauseGame() {
        if (!canvas.gameObject.activeSelf)
        {
            isVisible = true;
            cur = null;
            canvas.gameObject.SetActive(true);
            StartCoroutine("SetTimeScale");
        }
        else {
            isVisible = false;
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public IEnumerator SetTimeScale() {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
