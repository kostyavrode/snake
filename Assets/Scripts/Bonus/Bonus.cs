using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text viewHP;
    public int hp;
    private void Start()
    {
        hp = Random.Range(1, 15);
        SetHP();
    }
    public void ReceiveDamage()
    {
        if (hp < 1)
            Destroy(gameObject);
        hp--;
        SetHP();
    }
    private void SetHP()
    {
        viewHP.text = hp.ToString();
    }
}
