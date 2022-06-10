using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float offsetY;
    private GameObject target;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if(Snake.isPlayerAlive)
        transform.position = Vector3.Lerp(transform.position, GetTargetPos(), cameraSpeed * Time.fixedDeltaTime);
    }
    private Vector3 GetTargetPos()
    {
        return new Vector3(this.transform.position.x, target.transform.position.y + offsetY, this.transform.position.z);
    }
}
