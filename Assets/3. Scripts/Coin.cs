using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    private float _speedRotation = 100;


    private void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * _speedRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            EventManager.OnTakeCoin();
            Destroy(gameObject);
        }
    }
}
