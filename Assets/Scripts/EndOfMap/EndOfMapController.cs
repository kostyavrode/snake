using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMapController : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if(Snake.isPlayerAlive)
        transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
