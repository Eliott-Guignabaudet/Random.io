using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RandomGenerator : MonoBehaviour
{
    private System.Random _random = new();
    private int _minRoom = 3;
    private int _maxRoom = 21;
    public int nbrRooms = 3;

    public PlayerController player = FindObjectOfType<PlayerController>();
    public EnnemyController enemy = FindObjectOfType<EnnemyController>();
    public List<int> enemyLevels = new List<int>();
    private int _globalLevel = 0;
    private int _bossLevel = 0;

    public void GetRandomRooms()
    {
        nbrRooms = RandomInt(_minRoom, _maxRoom);
    }

    public void GenerateRooms()
    {
        for (int i = 0; i < nbrRooms; i++)
        {
            //Generate rooms
        }
    }

    public void GenerateEnemiesLvl()
    {
        int playerLvl = player.level;
        _globalLevel = playerLvl;
        int firstEnemy = _random.Next(player.level);
        enemyLevels.Add(firstEnemy);
        _globalLevel += firstEnemy;
        int nextEnemy;
        for (int i = 1; i < nbrRooms; i++)
        {
            int minLvl = _globalLevel * 20 / 100;
            if (i == nbrRooms - 1)
            {
                _bossLevel = RandomInt(minLvl, _globalLevel);
                enemyLevels.Add(_bossLevel);
            }
            nextEnemy = RandomInt(minLvl, _globalLevel);
            enemyLevels.Add(nextEnemy);
            _globalLevel += nextEnemy;
        }
        enemyLevels = ShuffleList(enemyLevels);
    }

    public int RandomInt(int min, int max)
    {
        return _random.Next(min, max);
    }

    public List<int> ShuffleList(List<int> enemyLevels)
    {
        List<int> shuffledEnemyLevels = new List<int>(enemyLevels.OrderBy(enemy => _random.Next()));
        return shuffledEnemyLevels;
    }
}
