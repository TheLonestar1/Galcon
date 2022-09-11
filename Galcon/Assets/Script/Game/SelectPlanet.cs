using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SelectPlanet : MonoBehaviour
{
    public static UnityEvent<Vector2> onAttack = new UnityEvent<Vector2>();
    private List<GameObject> _planetList = new List<GameObject>();
    [SerializeField]
    GameObject _ships;
    [SerializeField]
    private float _koefmargin;
    [SerializeField]
    private float _timeBeetweenSpawn;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Player" &&
                _planetList.Find(x => x.transform.position == hit.collider.transform.position) == null)
            {
                _planetList.Add(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color += new Color(0.2f,0,0);
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            }
            else if(hit.collider != null && hit.collider.tag != "Player")
            {
                StartCoroutine(SpawnShips(hit.collider.transform.position));
                
            }
            else
            {
                foreach(GameObject planet in _planetList)
                {
                    planet.GetComponent<SpriteRenderer>().color -= new Color(0.2f, 0, 0);
                }
                _planetList.Clear();
            }
        }
    }

    IEnumerator SpawnShips(Vector3 targetPoint)
    {
        foreach (GameObject planet in _planetList)
        {
            int countShips = planet.GetComponent<CounterPower>().ships / 2;
            planet.GetComponent<CounterPower>().DecreseCoutner(countShips);
            for (int i = 0; countShips > 2 && i < countShips; i++)
            {
                
                var ship = Instantiate(_ships);
                Debug.Log("target pos: " + targetPoint);
                ship.transform.position = planet.transform.position + (targetPoint - planet.transform.position).normalized * _koefmargin;
                Debug.DrawLine(planet.transform.position, ship.transform.position, Color.white);
                ship.GetComponent<MoverShip>().setTarget(targetPoint);
                ship.GetComponent<AttackPlanet>().setTarget(targetPoint);
                float angle = 0;
                Vector3 relative = ship.transform.InverseTransformPoint(targetPoint);
                angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
                ship.transform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(_timeBeetweenSpawn);
            }

        }
    }
}
   
