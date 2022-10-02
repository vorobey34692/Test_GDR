using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<bool> GameOver;
    public static event Action<int> AddCoin;
    public static event Action TakeCoin;

    public static void OnGameOver(bool win)
    {
        GameOver?.Invoke(win);
    }

    public static void OnAddCoin(int coin)
    {
        if (coin > 0)
            AddCoin?.Invoke(coin);
    }

    public static void OnTakeCoin()
    {
        TakeCoin?.Invoke();
    }
}
