using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void TurnOptions()
    {
        SceneManager.LoadScene(1);
    }
}
