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
    }

    public void GameOver()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Win");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        Cursor.SetCursor(c, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene("Menu");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
            //Cursor.visible = true;
        }
    }

    public void PauseGame() {
        if (!canvas.gameObject.activeSelf)
        {
            Cursor.visible = true;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            canvas.gameObject.SetActive(true);
            StartCoroutine("SetTimeScale");
        }
        else {
            Cursor.visible = false;
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public IEnumerator SetTimeScale() {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
