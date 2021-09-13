using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            //luodaan pelikartta
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            //spawnataan pelihahmot
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            //spawnataan viholliset
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            //pelaajan vuoro
            case GameState.HeroesTurn:
                break;
            //vihollisten vuoro
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}
