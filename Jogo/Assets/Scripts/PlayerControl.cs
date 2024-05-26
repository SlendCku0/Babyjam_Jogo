using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;

    private PlayerInputs playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerControls = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
