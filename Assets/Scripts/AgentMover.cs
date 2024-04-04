using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Transform _body;
    public Vector2 MovementInput;
    public Animator Ànimator;
    public float MoveSpeed;

    private void Start()
    {
        _body = gameObject.transform;
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + (MovementInput.normalized * MoveSpeed) * Time.fixedDeltaTime);
        _body.rotation = MovementInput.x > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        Ànimator.SetBool("IsWalking", MovementInput != Vector2.zero);
    }
}

