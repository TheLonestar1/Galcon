using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShip : MonoBehaviour
{
    private Vector2 _target;
    [SerializeField]
    private float _acceleration;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _angleSpeed;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void setTarget(Vector2 target)
    {
        _target = target;
        Debug.Log(target);
    }
    void FixedUpdate()
    {
        if(_target != null)
        {
            var direction = (_target - (Vector2)transform.position).normalized * _acceleration;
            var directionAngle = _target - (Vector2)transform.position;
            Quaternion rotation = Quaternion.LookRotation(transform.forward,directionAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _angleSpeed * Time.deltaTime);
            _rigidbody2D.AddForce(transform.up);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Force right" + transform.right);
        GetComponent<Rigidbody2D>().AddForce(transform.right * 4f);
    }
}
