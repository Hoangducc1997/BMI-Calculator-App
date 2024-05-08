using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Function : MonoBehaviour
{
    public void NextScene()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentLevel + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
