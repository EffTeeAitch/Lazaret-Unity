using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ResCorutine());
    }

    IEnumerator ResCorutine()
    {
        yield return new WaitForSeconds(5);

        Application.Quit();
    }

}
