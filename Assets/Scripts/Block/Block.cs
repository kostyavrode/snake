using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private Action OnUpdateHp;
    [SerializeField] private TMP_Text viewHP;
    private int hp;
    private void Start()
    {
        hp = UnityEngine.Random.Range(1, 30);
        OnUpdateHp += SetHP;
        OnUpdateHp?.Invoke();
        SetColor();
    }
    public void ReceiveDamage()
    {
        hp--;
        OnUpdateHp?.Invoke();
        if(hp<1)
        {
            OnUpdateHp -= SetHP;
            Destroy(gameObject);
        }
    }
    private void SetHP()
    {
        viewHP.text = hp.ToString();
    }
    private void SetColor()
    {
        if (hp<10)
            gameObject.GetComponent<SpriteRenderer>().color= new Color(0.5019608f, 1f, 0.8588235f, 1f);
       else if (hp < 20)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3921569f, 0.8745098f, 0.8745098f, 1f);
        else if (hp < 30)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.282353f, 0.7490196f, 0.8901961f, 1f);
    }
}
