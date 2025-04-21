using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }
    }
    public void CloseScene()
    {
        Application.Quit();
    }
}
