using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void IdleAnimation(bool isIdle)
    {
        if (isIdle == _animator.GetBool("isIdle")) return;
        {
            _animator.SetBool("isIdle", isIdle);
        }
    }

    public void RunningAnimation(bool isRunning)
    {
        if (isRunning == _animator.GetBool("isRunning")) return;
        {
            _animator.SetBool("isRunning", isRunning);
        }
    }

    public void ThrowingAnimation(bool isThrowing)
    {
        if (isThrowing == _animator.GetBool("isThrowing")) return;
        {
            _animator.SetBool("isThrowing", isThrowing);
        }
    }

    public void CatchingAnimation(bool isCatching)
    {
        if (isCatching == _animator.GetBool("isCatching")) return;
        {
            _animator.SetBool("isCatching", isCatching);
        }
    }
}
