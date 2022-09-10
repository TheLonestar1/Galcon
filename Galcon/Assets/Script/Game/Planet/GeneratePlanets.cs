using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanets : MonoBehaviour
{
    [SerializeField]
    LevelData _levelData;
    [SerializeField]
    GameObject _planteObject;

    List<Vector2> _planetPosition;
    Vector2 _pointLeftBottom, _pointRightTop;
    List<GameObject> _planets;
    private void Start()
    {
        _planetPosition = new List<Vector2>();
        _planets = new List<GameObject>();  
        _pointRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        _pointLeftBottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        for (int i = 0; i < _levelData.countPlanet; i++)
        {
            GameObject planet = Instantiate(_planteObject);
            planet.tag = "Neutral";
            planet.GetComponent<CounterPower>().ships = Random.Range(0 + (50 * ((int)_levelData.difficultie)),(50 + ((int)_levelData.difficultie)));
            planet.transform.position = FindPlace(planet.GetComponent<SpriteRenderer>().size.x / 1.5f );
            _planets.Add(planet);
        }
    }

    private Vector2 FindPlace(float merge)
    {
       
            _planetPosition.Add(new Vector2(Random.Range(_pointLeftBottom.x + merge, _pointRightTop.x - merge),
                                            Random.Range(_pointLeftBottom.y + merge, _pointRightTop.y - merge)));
            if(_planetPosition.Count == 1)
                return _planetPosition[^1];
            while (true)
            {
                _planetPosition[^1] = new Vector2(Random.Range(_pointLeftBottom.x + merge, _pointRightTop.x - merge),
                                            Random.Range(_pointLeftBottom.y + merge, _pointRightTop.y - merge));
                float sum = 0;
                float distance;
                foreach (Vector2 point in _planetPosition)
                {
                    var heading = _planetPosition[^1] - point;
                    distance = heading.magnitude;
                    Debug.Log(distance);
                if (distance < _levelData.distanceForNeighboring && distance != 0)
                    {
                        
                        sum += _planets.Find(x => x.transform.position.x == point.x).GetComponent<CircleCollider2D>().radius+0.2f;
                    }
                }
                if(sum == 0)
                    return _planetPosition[^1];
            
                int index = 0;
                foreach(Vector2 point in _planetPosition)
                {
                    index++;
                    var heading = _planetPosition[^1] - point;
                    distance = heading.magnitude;
                    if (distance < sum)
                    {
                        break;
                    }
                }
                if(_planetPosition.Count == index)
                    return _planetPosition[^1];
            }
            
        
    }
}