using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    private PlayerMove _point;
    private List<Vector3> _targetPosition = new List<Vector3>();

    private void Start()
    {
        _point = GetComponent<PlayerMove>();
        _targetPosition = _point.TargetPosition;
    }

    private void Update()
    {
        if (_targetPosition.Count > 0)
            LineRen();
    }

    private void LineRen()
    {
        Vector3[] copiedArray = new Vector3[100];
        Vector3[] pastedArray = new Vector3[101];
        copiedArray = _targetPosition.ToArray();
        pastedArray[0] = transform.position;
        copiedArray.CopyTo(pastedArray, 1);
        _lineRenderer.positionCount = _targetPosition.Count + 1;
        _lineRenderer.SetPositions(pastedArray);
    }
}
