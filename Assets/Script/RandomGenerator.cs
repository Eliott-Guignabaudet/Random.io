using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomGenerator : MonoBehaviour
{
    private System.Random _random = new();
    private int _minRoom = 3;
    private int _maxRoom = 21;
    public int nbrRooms;

    public PlayerController player = FindObjectOfType<PlayerController>();
    public EnnemyController enemy = FindObjectOfType<EnnemyController>();

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
        int globalLvl = playerLvl;
        int firstEnemy = _random.Next(player.level);
        enemy.levelEnnemy = firstEnemy;
        globalLvl += firstEnemy;
        int nextEnemy;
        for (int i = 1; i < nbrRooms; i++)
        {
            int minLvl = globalLvl * 20 / 100;
            nextEnemy = RandomInt(minLvl, globalLvl);
            //Keep nextEnemy value somewhere
            enemy.levelEnnemy = nextEnemy;
            globalLvl += nextEnemy;
        }
    }

    public int RandomInt(int min, int max)
    {
        return _random.Next(min, max);
    }
}
