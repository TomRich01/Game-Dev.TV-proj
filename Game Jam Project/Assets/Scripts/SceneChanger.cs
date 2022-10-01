using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneNum;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
