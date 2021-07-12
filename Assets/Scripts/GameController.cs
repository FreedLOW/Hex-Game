using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int playerMoney = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        playerMoney = Random.Range(5, 10);
    }
}