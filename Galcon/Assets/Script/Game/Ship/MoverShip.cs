using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShip : MonoBehaviour
{
    private Vector2 _target;
    [SerializeField]
    private float _acceleration;
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void setTarget(Vector2 target)
    {
        _target = target;
        Debug.Log(target);
    }
    void Update()
    {
        if(_target != null)
        {
            var direction = (_target - (Vector2)transform.position).normalized * _acceleration;

            _rigidbody2D.AddForce(direction);
        }
    }
}
