using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        if(sceneName == string.Empty)
        {
            Debug.LogError("You forget to set scene name, the script is component of Canvas :D");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
