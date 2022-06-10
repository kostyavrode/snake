using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SnakeTailGenerator))]
[RequireComponent(typeof(InputController))]
public class Snake : MonoBehaviour
{
    public static Action OnPlayerDeath;
    public static bool isPlayerAlive;
    [SerializeField] private int tailSize;
    [SerializeField] private float speed;
    [SerializeField] private float tailSpeed;
    [SerializeField] private SnakeHead snakeHead;
    private InputController inputController;
    [HideInInspector]public List<TailPart> tail;
    private SnakeTailGenerator snakeTailGenerator;
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        snakeTailGenerator = GetComponent<SnakeTailGenerator>();
        tail = snakeTailGenerator.Generate(tailSize);
        isPlayerAlive = true;
    }
    private void FixedUpdate()
    {
        Move(snakeHead.transform.position + snakeHead.transform.up * speed * Time.fixedDeltaTime);
        snakeHead.transform.up = inputController.DistanceToClick(snakeHead.transform.position);
    }
    private void Move(Vector2 nextPos)
    {
        Vector2 lastPos = snakeHead.transform.position;
        foreach(var tailPart in tail)
        {
            Vector2 tempPos = tailPart.transform.position;
            tailPart.transform.position = Vector2.Lerp(tailPart.transform.position, lastPos, tailSpeed * Time.deltaTime);
            lastPos = tempPos;
        }
        snakeHead.Move(nextPos);
    }
    public void ReceiveDamage()
    {
        if (tail.Count <= 0)
        {
            Destroy(gameObject);
            isPlayerAlive = false;
            OnPlayerDeath?.Invoke();
        }
        else
        {
            TailPart deletedPart = tail[tail.Count - 1];
            tail.Remove(deletedPart);
            Destroy(deletedPart.gameObject);
        }
    }
    public void IncreaseHP()
    {
        tail.AddRange(snakeTailGenerator.Generate(1));
    }
}
