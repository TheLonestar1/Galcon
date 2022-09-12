using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackPlanet : MonoBehaviour
{
    public static UnityEvent<int> onAttackPlanet = new UnityEvent<int>();
    private Vector2 _targetPosition;
    [SerializeField]
    private int damage;
    public void  setTarget(Vector2 target)
    {
        _targetPosition = target;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((Vector2)collision.collider.transform.position == _targetPosition)
        {
            collision.gameObject.GetComponent<CounterPower>().TakeDamge(damage, this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
