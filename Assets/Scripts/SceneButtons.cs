using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame(){
        Application.Quit();
    }
    public void TryAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
