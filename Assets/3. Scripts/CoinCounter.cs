using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private Coin[] _coins;
    private int _coinCount;

    private void Start()
    {
        EventManager.TakeCoin += OnTakeCoin;
        EventManager.GameOver += CoinZero;
        _coins = FindObjectsOfType<Coin>();
    }

    private void OnTakeCoin()
    {
        _coinCount++;
        EventManager.OnAddCoin(_coinCount);
        AllCoinCollected();
    }

    private void AllCoinCollected()
    {
        if (_coinCount == _coins.Length)
            EventManager.OnGameOver(true);
    }

    private void CoinZero(bool win)
    {
        _coinCount = 0;
    }
}
