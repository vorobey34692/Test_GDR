using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 5f);
        }
    }
}