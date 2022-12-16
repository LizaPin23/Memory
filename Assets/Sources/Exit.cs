using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitOnClick()
    {
        Debug.Log("привет");
        Application.Quit();
    }
}
