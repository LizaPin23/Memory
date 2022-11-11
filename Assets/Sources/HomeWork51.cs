using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork51 : MonoBehaviour
{
    public int Five = 0;

    void Start()
    {
        for (int i = 5; i > Five; i--)
        {
            Debug.Log(i);
        }
    }
}
