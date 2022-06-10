using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeIncreaser : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        Time.timeScale+=0.00005f;
    }
}
