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
    SpawnUtility _spawnUtility;
    [SerializeField]
    private LayerMask _layerMask;
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
                foreach (GameObject planet in _planetList)
                {
                    if(planet.tag == "Player")
                     StartCoroutine(_spawnUtility.SpawnShips(hit.collider.transform.position,planet));
                }
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

   

    

}
   
