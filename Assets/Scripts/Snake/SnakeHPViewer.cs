using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SnakeHPViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private void Start()
    {
        SnakeHead.OnHpChange += HPView;
    }
    private void HPView(int hp)
    {
        hp++;
        text.text = hp.ToString();
    }
    private void OnDestroy()
    {
        SnakeHead.OnHpChange -= HPView;
    }
}
