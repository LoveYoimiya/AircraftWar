using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int selectPrefab = 0;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
    }
    public GameManager()
    {
    }
}
