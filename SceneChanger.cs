using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Main_Loop
{
    public void swapScene(string sceneName)
    {
        Save_stats();
        SceneManager.LoadScene(sceneName);
    }
}
