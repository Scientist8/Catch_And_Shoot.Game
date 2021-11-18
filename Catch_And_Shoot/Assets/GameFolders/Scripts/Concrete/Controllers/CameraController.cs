using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _ball;

    //public PlayerController _playerController;

    public Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _ball.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, _ball.transform.position.y + _offset.y, _ball.transform.position.z + _offset.z);
    }
}
