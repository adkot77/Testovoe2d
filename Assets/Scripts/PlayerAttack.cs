
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerAttack : DealDamage
{
    private Animator animator;
    private NewInputAction inputActions;

    [Header("Fireball settings")]
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private int fireballDamage= 1;
    [SerializeField] private float fireballColdown = 1;
    private float timeToFireball;

    [Header("Smash settings")]
    [SerializeField] private int smashDamage = 1;
    [SerializeField] private float smashColdown = 1;
    private float timeToSmash;
    [SerializeField] private Transform smashPoint;
    [SerializeField] private float smashRadius = 1;
    [SerializeField] private LayerMask smashAttackLayer;


    [Header("StompedSettings")]
    [SerializeField] private float stompedDistance = 1;
    [SerializeField] private float stompedYOffset ;
    [SerializeField] private LayerMask stompedLayer;
    [SerializeField] private int stompedDamage = 1;

    [Header("AudioClips")]
    [SerializeField] private AudioClip smashSFX;
    [SerializeField] private AudioClip fireballSFX;
    [SerializeField] private AudioClip stompedSFX;



    private void Awake()
    {
        InitializeComponents();
    }
    private void Start()
    {
        SetupInput();
    }

    private void SetupInput()
    {
        inputActions.Player.Smash.performed += Smash_performed;
        inputActions.Player.Fire.performed += Fire_performed;
    }

    private void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        inputActions = new();
        inputActions.Enable();
    }

    private void OnDisable()=> inputActions.Disable();

    private void UpdateColdowns()
    {
        timeToFireball -= Time.fixedDeltaTime;
        timeToSmash -= Time.fixedDeltaTime;
    }
    private void Smash_performed(CallbackContext obj)
    {
        if ( timeToSmash < 0)
        {
            AudioSFX.instance.PlaySFX(smashSFX);
            timeToSmash = smashColdown;
            animator.SetTrigger("Smash");
        }
    }
    private void Smash()
    {
       
        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)smashPoint.position, smashRadius,smashAttackLayer);
      
        foreach (Collider2D collider in colliders) 
        { 
           
            TryDealDamage(collider.gameObject,smashDamage);
        }
    }

    private void Fire_performed(CallbackContext obj)
    {
        if ( timeToFireball < 0)
        {
            timeToFireball = fireballColdown;
            animator.SetTrigger("Cast");
        }

    }
    private void StompedAttack()
    {
        Vector3 startRayPosition = transform.position + Vector3.down * stompedYOffset;
        RaycastHit2D hitInfo = Physics2D.Raycast(startRayPosition, -transform.up, stompedDistance, stompedLayer);
        if(hitInfo)
        {
            AudioSFX.instance.PlaySFX(stompedSFX);
            TryDealDamage(hitInfo.transform.parent.gameObject,stompedDamage);
            
           
        }
    }
    private void SpawnFireball()
    {
        AudioSFX.instance.PlaySFX(fireballSFX);
        Instantiate(fireballPrefab, fireballSpawnPoint.position, transform.rotation);
     
    }


    private void FixedUpdate()
    {
        UpdateColdowns();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         StompedAttack();
        
    }
    private void OnDrawGizmos()
    {
        Vector3 startDrawLine = transform.position + Vector3.down * stompedYOffset;
       Gizmos.DrawLine(startDrawLine, startDrawLine+Vector3.down* stompedDistance);
        Gizmos.DrawWireSphere(smashPoint.position, smashRadius);
    }
}
