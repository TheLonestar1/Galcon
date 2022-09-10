using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlanet : MonoBehaviour
{
    List<GameObject> _planetList = new List<GameObject>();
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Player" && _planetList.Find(x => x.transform.position == hit.collider.transform.position) == null)
            {
                _planetList.Add(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color += new Color(0.2f,0,0);
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
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
   
