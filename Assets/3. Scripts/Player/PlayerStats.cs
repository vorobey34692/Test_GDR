using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageble
{
    private int _health = 5;
    
    public void ApplayDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            EventManager.OnGameOver(false);
    }
}