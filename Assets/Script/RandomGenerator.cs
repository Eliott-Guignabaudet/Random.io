using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RandomGenerator : MonoBehaviour
{
    private Dictionary<int, int[]> _towerPattern = new Dictionary<int, int[]>();

    private System.Random _random = new();
    private int _minRoom = 3;
    private int _maxRoom = 21;
    public int nbrRooms = 3;

    public PlayerController playerControl = FindObjectOfType<PlayerController>();
    public GameObject enemy;
    //public EnnemyController enemyControl = FindObjectOfType<EnnemyController>();

    public List<int> enemyLevels = new List<int>();
    private int _globalLevel = 0;
    private int _bossLevel = 0;

    public List<List<int>> allTowers = new List<List<int>>();
    private List<int> _firstTower;
    private List<int> _secondTower;
    private List<int> _thirdTower;
    private List<int> _fourthTower;

    public GameObject prefab3Rooms;
    public GameObject prefab4Rooms;
    public GameObject prefab5Rooms;

    public void GenerateRooms()
    {
        InstentiateTowerPattern();
        GetRandomRooms();
        int[] patternToGenerate = _towerPattern[nbrRooms]; //int[4] { 4, 5, 0, 0 }
        _globalLevel += playerControl.level;
        GenerateEnemiesLvl();
        _firstTower = ShuffleList(RemovePartOfList((List<int>)enemyLevels.Take(patternToGenerate[0]), patternToGenerate[0]));
        _secondTower = ShuffleList(RemovePartOfList((List<int>)enemyLevels.Take(patternToGenerate[1]), patternToGenerate[1]));
        _thirdTower = ShuffleList(RemovePartOfList((List<int>)enemyLevels.Take(patternToGenerate[2]), patternToGenerate[2]));
        _fourthTower = ShuffleList(RemovePartOfList((List<int>)enemyLevels.Take(patternToGenerate[3]), patternToGenerate[3]));
        allTowers.Add(_firstTower); allTowers.Add(_secondTower); allTowers.Add(_thirdTower); allTowers.Add(_fourthTower);
        // récupérer un préfab de tour correspondant aux nombres d'étages
        // instancier un énnemie, lui donner un lvl de la liste et le mettre dans une room
        // pour la last room, mettre le boss
        foreach (List<int> tower in allTowers)
        {
            if (tower.Count != 0)
            {
                var prefabTower = ChoosePrefab(tower.Count);
                Instantiate(prefabTower);
                var towerVar = prefabTower.GetComponent<TowerVariables>();
                for (int i = 0; i < tower.Count; i++)
                {
                    var newEnemy = Instantiate(enemy);
                    EnnemyController enemyControl = newEnemy.GetComponent<EnnemyController>();
                    enemyControl.levelEnnemy = tower[i];
                    towerVar.rooms[i].ennemyController[0] = enemyControl;
                }
            }
        }
    }

    public void GetRandomRooms()
    {
        nbrRooms = RandomInt(_minRoom, _maxRoom);
    }

    public void GenerateEnemiesLvl()
    {
        int nextEnemy;
        int minLvl = _globalLevel - (_globalLevel * 20 / 100);
        for (int i = 0; i < nbrRooms; i++)
        {
            if (i == nbrRooms - 1)
            {
                _bossLevel = RandomInt(minLvl, _globalLevel);
            } else 
            {
                nextEnemy = RandomInt(minLvl, _globalLevel);
                enemyLevels.Add(nextEnemy);
                _globalLevel += nextEnemy;
            }
        }
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

    public List<int> RemovePartOfList(List<int> enemyLevels, int range)
    {
        for (int i = 0; i < range; i++)
        {
            enemyLevels.RemoveAt(i);
        }
        return enemyLevels;
    }

    public GameObject ChoosePrefab(int rooms)
    {
        if (rooms == 3)
        {
            return prefab3Rooms;
        } else if (rooms == 4)
        {
            return prefab4Rooms;
        } else if (rooms == 5)
        {
            return prefab5Rooms;
        }
        return prefab3Rooms;
    }

    public void InstentiateTowerPattern()
    {
        int[] pattern1 = new int[4] { 3, 0, 0, 0 }; _towerPattern.Add(3, pattern1);
        int[] pattern2 = new int[4] { 4, 0, 0, 0 }; _towerPattern.Add(4, pattern2);
        int[] pattern3 = new int[4] { 5, 0, 0, 0 }; _towerPattern.Add(5, pattern3);
        int[] pattern4 = new int[4] { 3, 3, 0, 0 }; _towerPattern.Add(6, pattern4);
        int[] pattern5 = new int[4] { 3, 4, 0, 0 }; _towerPattern.Add(7, pattern5);
        int[] pattern6 = new int[4] { 3, 5, 0, 0 }; _towerPattern.Add(8, pattern6);
        int[] pattern7 = new int[4] { 4, 5, 0, 0 }; _towerPattern.Add(9, pattern7);
        int[] pattern8 = new int[4] { 3, 3, 4, 0 }; _towerPattern.Add(10, pattern8);
        int[] pattern9 = new int[4] { 3, 4, 4, 0 }; _towerPattern.Add(11, pattern9);
        int[] pattern10 = new int[4] { 3, 4, 5, 0 }; _towerPattern.Add(12, pattern10);
        int[] pattern11 = new int[4] { 3, 3, 3, 4 }; _towerPattern.Add(13, pattern11);
        int[] pattern12 = new int[4] { 3, 3, 4, 4 }; _towerPattern.Add(14, pattern12);
        int[] pattern13 = new int[4] { 3, 3, 4, 5 }; _towerPattern.Add(15, pattern13);
        int[] pattern14 = new int[4] { 3, 4, 4, 5 }; _towerPattern.Add(16, pattern14);
        int[] pattern15 = new int[4] { 3, 4, 5, 5 }; _towerPattern.Add(17, pattern15);
        int[] pattern16 = new int[4] { 4, 4, 5, 5 }; _towerPattern.Add(18, pattern16);
        int[] pattern17 = new int[4] { 4, 5, 5, 5 }; _towerPattern.Add(19, pattern17);
        int[] pattern18 = new int[4] { 5, 5, 5, 5 }; _towerPattern.Add(20, pattern18);
    }
}
