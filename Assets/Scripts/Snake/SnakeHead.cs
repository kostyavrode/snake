using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    [SerializeField] private Snake snakeScript;
    public static Action<int> OnHpChange;
    private Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        OnHpChange?.Invoke(snakeScript.tail.Count);
    }
    public void Move(Vector2 newpos)
    {
        rigidbody.MovePosition(newpos);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Block blockScript = collision.gameObject.GetComponent<Block>();
            blockScript.ReceiveDamage();
            snakeScript.ReceiveDamage();
            OnHpChange?.Invoke(snakeScript.tail.Count);
        }
        if (collision.gameObject.CompareTag("Bonus"))
        {
            Bonus bonus = collision.gameObject.GetComponent<Bonus>();
            bonus.ReceiveDamage();
            snakeScript.IncreaseHP();
            OnHpChange?.Invoke(snakeScript.tail.Count);
        }
    }
}
