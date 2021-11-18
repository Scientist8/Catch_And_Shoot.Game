using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _moveSpeed;
    public bool _running = false;

    public CharacterAnimations _characterAnimations;

    float _currentPositionOfFirstTouch;
    float _currentPositionOfPlayer;

    Rigidbody _rigidbody;
    InputController _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = new InputController();
        _characterAnimations = GetComponentInChildren<CharacterAnimations>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _running = true;
            _characterAnimations.RunningAnimation(_running);
        }

        DragMouse();
    }

    private void FixedUpdate()
    {
        if (_running)
        {
            _rigidbody.velocity = (Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    private void DragMouse()
    {
        if (_running)
        {
            if (_input.FirstMouseClick)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
                _currentPositionOfFirstTouch = mousePosition.x;
                _currentPositionOfPlayer = transform.position.x;
            }

            if (_input.MouseClick)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
                float playerPosition = mousePosition.x - _currentPositionOfFirstTouch + _currentPositionOfPlayer;
                float playerPositionLimited = Mathf.Clamp(playerPosition, -5f, 5f);
                transform.position = new Vector3(playerPositionLimited, transform.position.y, transform.position.z);
            }
        }
    }
}
