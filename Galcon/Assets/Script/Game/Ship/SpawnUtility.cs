using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public  class SpawnUtility : MonoBehaviour
    {
        [SerializeField]
        private float _timeBeetweenSpawn;
        [SerializeField]
        private GameObject _ships;
        private  Vector3 Vector3OffsetByDegrees(Vector3 center, float distance, float degrees)
        {
            Vector3 offset = Vector3.zero;
            offset.x = distance * Mathf.Sin(degrees * Mathf.Deg2Rad);
            offset.y = distance * Mathf.Cos(degrees * Mathf.Deg2Rad);
          
            return center + offset;
        }
        public IEnumerator SpawnShips(Vector3 targetPoint, GameObject planet)
        {

            int countShips = planet.GetComponent<CounterPower>().ships / 2;
            planet.GetComponent<CounterPower>().DecreseCoutner(countShips);
            int coutRows = Mathf.CeilToInt(Mathf.Sqrt((float)countShips));
            float _koefmargin = coutRows + .9f;
            for (int i = 1; i < coutRows; i++)
            {
                int k = i * 2;
                for (int j = -(k / 2); j < (k / 2); j++)
                {
                    if (countShips == 0)
                        break;
                    var ship = Instantiate(_ships);
                    ship.GetComponent<SpriteRenderer>().color = planet.GetComponent<SpriteRenderer>().color;
                    Debug.Log("target pos: " + targetPoint);
                    ship.layer = LayerMask.NameToLayer("Ship");
                    var angle = Vector3.Angle(targetPoint, planet.transform.position);
                    ship.transform.position = planet.transform.position + Vector3OffsetByDegrees((targetPoint - planet.transform.position).normalized * (_koefmargin * 0.25f), j * 0.25f, angle);
                    ship.GetComponent<MoverShip>().setTarget(targetPoint);
                    ship.GetComponent<AttackPlanet>().setTarget(targetPoint);
                    ship.tag = planet.tag;
                    Vector3 relative = ship.transform.InverseTransformPoint(targetPoint);
                    angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
                    ship.transform.Rotate(0, 0, -angle);
                    countShips--;
                    yield return new WaitForSeconds(_timeBeetweenSpawn);
                }
                _koefmargin--;
            }


        }
   
    }

