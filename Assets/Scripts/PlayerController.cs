using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    private NewInputAction inputActions;    
  
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float moveSpeed=5;
    [SerializeField] private float jumpHeight=5;
    [SerializeField] private AudioClip jumpSFX;
    private Animator animator;
    

    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer = 1; // Слой Ground
    [SerializeField] private Vector2 boxSize = new Vector2(0.5f, 0.1f); // Размер области проверки
   
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -0.1f); // Смещение относительно центра
    private bool isGrounded=true;
  
   

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        inputActions = new();
        inputActions.Enable();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnDisable() => inputActions.Disable();
    void Start()
    {
        SetupInput();   

    }

    private void SetupInput()
    {
        inputActions.Player.Movement.performed += Movement_performed;
        inputActions.Player.Movement.canceled += Movement_canceled;
        inputActions.Player.Jump.started += Jump_performed;
      
    }



    private void Jump_performed(CallbackContext obj)
    {
        if (isGrounded)
        {
            AudioSFX.instance.PlaySFX(jumpSFX);
            isGrounded = false;
            rb.velocity = Vector2.up * jumpHeight;
            
        }
        
    }
 
    private void Movement_performed(CallbackContext context)
    {
        float inputValue = context.ReadValue<float>();
        UpdateFacingDirection(inputValue);
        movement.x = inputValue * moveSpeed;
        

        animator.SetFloat("MovementX", Mathf.Abs(movement.x));


    }
    private void UpdateFacingDirection(float inputValue)
    {
        if (Mathf.Abs(inputValue) > 0.01f) // Избегаем микродвижений
        {
            float targetRotation = inputValue > 0 ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);
        }
    }
    //private void UpdateFacingDirection(float inputValue)
    //{
    //    localScale = transform.localScale;
    //   localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(inputValue);
    //    transform.localScale = localScale;
    //}

    private void Movement_canceled(CallbackContext obj)
    {
        movement.x = 0;
        animator.SetFloat("MovementX", 0);
    }


    private void FixedUpdate()
    {
        CheckGrounded();
        
        ApplyMovement();
       
    }

    private void CheckGrounded()
    {
        Vector2 pointCheck = transform.position + (Vector3)boxOffset;
        isGrounded = Physics2D.OverlapBox(pointCheck, boxSize, 0f, groundLayer);
        animator.SetBool("isGround", isGrounded);
    }

    private void ApplyMovement()
    {
        movement.y = rb.velocity.y;
        rb.velocity = movement;
        
    }

  

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)boxOffset, boxSize);
     
    }
}
