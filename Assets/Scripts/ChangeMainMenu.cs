using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
