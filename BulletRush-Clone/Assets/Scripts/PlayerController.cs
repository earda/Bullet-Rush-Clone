using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MyCharacterController
{

    [SerializeField] private TouchController inputTouch;
    [SerializeField] private ShootController shootController;

    private List<Transform> _enemies = new List<Transform>();
    private void FixedUpdate()
    {
        var param = new Vector3(inputTouch.Direction.x, 0, inputTouch.Direction.y);
        Move(param);
    }
    private void Update()
    {
        if (_enemies.Count > 0)
            transform.LookAt(_enemies[0]);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag($"Enemy"))
        {
            Dead();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            if (_enemies.Contains(other.transform))
            {
                _enemies.Add(other.transform);
            }
            AutoShoot();
        }
    }

    private bool _isShooting = false;

    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (_enemies.Count > 0)
            {
                var enemy = _enemies[0];
                var myTransform = transform;
                var position = myTransform.position;
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                shootController.Shoot(direction, position);
                transform.LookAt(enemy.transform);
                _enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.Delay);
            }
            _isShooting = false;
        }
        if (!_isShooting)
        {
            _isShooting = true;
            StartCoroutine(Do());
        }
       
    }
    private void Dead()
    {

    }
}
