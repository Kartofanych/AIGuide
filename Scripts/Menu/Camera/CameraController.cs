using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speedScale = 0.03f;
    public bool _isDragged = true;
    private Vector3 _lastMousePos;
    private Vector3 _sumMove;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePos = Input.mousePosition;
            StartCoroutine(TouchTime(_lastMousePos));
        }
        
        if (Input.GetMouseButton(0))
        {
            var move = Input.mousePosition - _lastMousePos;
            move.z = 0;
            move *= -1;

            _sumMove += move;
            if (_sumMove.magnitude > 1)
            {
                _isDragged = true;
            }

            _camera.transform.position += move * _speedScale;

            _lastMousePos = Input.mousePosition;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f),
        Mathf.Clamp(transform.position.y,-6f, 6f),
            transform.position.z
            );
    }

    IEnumerator TouchTime(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 _nowPos = Input.mousePosition;
        Debug.Log(Vector3.Distance(_nowPos, lastPos) + " " + lastPos + " " + _nowPos);
        if (Vector3.Distance(_nowPos, lastPos) < 4f)
        {
            _isDragged = false;
        }
        else
        {
            _isDragged = true;
        }
    }
}