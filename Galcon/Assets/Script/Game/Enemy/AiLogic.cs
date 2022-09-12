using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AiLogic : MonoBehaviour
{
    List<GameObject> _allPlanets = new List<GameObject>();
    List<GameObject> _enemyPlanets = new List<GameObject>();
    [SerializeField]
    SpawnUtility _spawnUtility;
    GameObject _target;
    List<GameObject> AttackPlanet = new List<GameObject> ();
    [SerializeField]
    float _timeBeetweenAttack;
    [SerializeField]
    LevelData _levelData;
    private void Awake()
    {
        GeneratePlanets.OnGeneration.AddListener(ResponsePlanets);
        Player.OnPlusEnemyPlanet.AddListener(PlusEnemyPlanet);
        Player.OnMinusEnemyPlanet.AddListener(MinusEnemyPlanet);
    }

    void ResponsePlanets(List<GameObject> allPlanets) => _allPlanets.AddRange(allPlanets);

    void PlusEnemyPlanet(GameObject planet) => _enemyPlanets.Add(planet);

    void MinusEnemyPlanet(GameObject planet) => _enemyPlanets.Remove(planet);


    private void Update()
    {

        if (_enemyPlanets.Count > 0 && AttackPlanet.Count < 1)
        {
            int rand = Random.Range(1, _enemyPlanets.Count);
            int min = 999;
            Debug.Log("Enemt planet : " + _enemyPlanets.Count);
      

            //foreach (GameObject planet in _allPlanets)
            //{
            //    if (planet.GetComponent<CounterPower>().ships < min && planet.tag != "Enemy")
            //        min = planet.GetComponent<CounterPower>().ships;
            //}
            
            Debug.Log(_allPlanets.Count + " " + rand + " " + min);
            _target = _allPlanets.FindAll(x => x.tag != "Enemy").OrderBy(x => x.GetComponent<CounterPower>().ships).First();
            Debug.Log(_target.GetComponent<CounterPower>().ships);
            AttackPlanet = _enemyPlanets.Take(rand).ToList();
            Debug.Log("Attack planet : " + AttackPlanet.Count);
            if (_target != null)
                StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        foreach (GameObject platen in AttackPlanet)
            StartCoroutine(_spawnUtility.SpawnShips(_target.transform.position, platen));
        yield return new WaitForSeconds(_timeBeetweenAttack * (4 - (int)_levelData.difficultie+1));
        AttackPlanet.Clear();
    }

}
