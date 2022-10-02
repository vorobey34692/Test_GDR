using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private List<Vector3> _targetPosition = new List<Vector3>();
    [SerializeField] private GameObject _targetPoint;
    private Rigidbody _targetRigidbody;
    [SerializeField] private float _speedMove = 5;
    [SerializeField] LineRenderer _lineRenderer;


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
            if (hit.collider == null) return;
            Vector3 targetPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            GameObject targetPointClone = Instantiate(_targetPoint, targetPoint, Quaternion.identity);
            _targetPosition.Add(targetPointClone.transform.position);
        }
    }

    private void Move()
    {
        if (_targetPosition.Count > 0)
            LineRen();

        while (_targetPosition.Count > 0)
        {
            _targetRigidbody.MovePosition(Vector3.MoveTowards(transform.position, _targetPosition[0], _speedMove * Time.deltaTime));

            if (Vector3.Distance(transform.position, _targetPosition[0]) > 0.3f) return;
            else
            {
                _targetPosition.RemoveAt(0);
                return;
            }
        }
    }

    private void LineRen()
    {
        Vector3[] array = new Vector3[100];
        Vector3[] array2 = new Vector3[101];
        array = _targetPosition.ToArray();
        array2[0] = transform.position;
        array.CopyTo(array2, 1);
        _lineRenderer.positionCount = _targetPosition.Count + 1;
        _lineRenderer.SetPositions(array2);
    }
}
