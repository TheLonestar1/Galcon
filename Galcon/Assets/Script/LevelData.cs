using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]

public class LevelData : ScriptableObject
{
    
    [SerializeField]
    private int _countPlanet;
    [SerializeField]
    private difficulties _diff;
    [SerializeField]
    private int _startShipsOnPlanet;
    [SerializeField]
    private int _distanceForNeighboring;
    
    public int distanceForNeighboring
    {
        get { return _distanceForNeighboring; }
    }
    public int countPlanet
    {
        get { return _countPlanet; }
    }
    public int startShipsOnPlanet 
    { 
        get { return _startShipsOnPlanet; }
    }
    public difficulties difficultie
    {
        get { return _diff; }
    }
    
    public enum difficulties 
    {
        easy,
        medium,
        hard
    };
}
