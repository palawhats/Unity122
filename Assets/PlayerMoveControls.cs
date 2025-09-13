using UnityEngine;  

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private int direction = 1;
    public float jumpForce;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    private bool grounded = false;



    void Awake()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimatorValues();
    }
    
    private void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }
    
    private void Move() 
    {
        Flip();
        // แก้ไขบรรทัดนี้: เปลี่ยน velocity เป็น linearVelocity
        rigidbody2D.linearVelocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.linearVelocity.y);
    }

    private void Flip() 
    { 
        if(gatherInput.valueX * direction < 0) 
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues() 
    {
        // แก้ไขบรรทัดนี้: เปลี่ยน velocity เป็น linearVelocity
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.linearVelocity.x));
        animator.SetFloat("vSpeed", rigidbody2D.linearVelocity.y);
        animator.SetBool("Grounded", grounded);
    }
    
    private void JumpPlayer() 
    {
        if (gatherInput.jumpInput && grounded)
        {
            rigidbody2D.velocity = new Vector2(gatherInput.valueX * speed, jumpForce);
        }
        gatherInput.jumpInput = false;
    } 

    private void CheckStatus()
    {
     RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
     grounded = leftCheckHit;
	}
}
