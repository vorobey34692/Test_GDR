using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public List<Vector3> TargetPosition { get; private set; } = new List<Vector3>();
    [SerializeField] private GameObject _targetPoint;
    private Rigidbody _targetRigidbody;
    [SerializeField] private float _speedMove = 5;
    private int _maxTargetPoint = 100;

    private void Start()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (Input.touchCount == 1)
        //    SetTarget();

        if (Input.GetMouseButtonDown(0))
            SetTarget();

        Move();
    }

    private void SetTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null || TargetPosition.Count > _maxTargetPoint) return;
            Vector3 targetPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            GameObject targetPointClone = Instantiate(_targetPoint, targetPoint, Quaternion.identity);
            TargetPosition.Add(targetPointClone.transform.position);
        }
    }

    private void Move()
    {
        while (TargetPosition.Count > 0)
        {
            _targetRigidbody.MovePosition(Vector3.MoveTowards(transform.position, TargetPosition[0], _speedMove * Time.deltaTime));

            if (Vector3.Distance(transform.position, TargetPosition[0]) > 0.3f) return;
            else
            {
                TargetPosition.RemoveAt(0);
                return;
            }
        }
    }
}
