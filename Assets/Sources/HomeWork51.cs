using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork51 : MonoBehaviour
{
    [SerializeField] private int _number = 3;

    void Start()
    {
        for (int i = 1; i < 11; i++)
        {
            Debug.Log(_number*i);
        }
    }
}
