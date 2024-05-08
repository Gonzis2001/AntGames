using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2d : MonoBehaviour
{
   private ControlesPJ2D input =null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb= null;
    private Animator animator = null;
    [SerializeField] private float speedMove;
    private void Awake()
    {
        input = new ControlesPJ2D();   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += Move_performed;
        input.Player.Move.canceled += Move_canceled;
    }

  

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= Move_performed;
        input.Player.Move.canceled -= Move_canceled;
    }
    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveVector = obj.ReadValue<Vector2>();
    }
    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveVector = Vector2.zero;
    }
    private void Update()
    {
        animator.SetFloat("Velocity",rb.velocity.magnitude);
        animator.SetFloat("X", moveVector.x);
        animator.SetFloat("Y", moveVector.y);


    }
    private void FixedUpdate()
    {
        rb.velocity = moveVector*speedMove;
    }
}
