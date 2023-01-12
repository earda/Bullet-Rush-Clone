using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [Range(100,500)][SerializeField] private float moveSpeed;
    protected void Move(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
   
}
