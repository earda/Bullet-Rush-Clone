using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private TouchController inputTouch;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    private void Move(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        var param = new Vector3(inputTouch.Direction.x,0,inputTouch.Direction.y);
        Move(param);
    }
}
