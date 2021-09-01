using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public float speed = 8.0f;
	public float stairSpeed = 3.0f;
	public float iHorizontal;
	public float iVertical;
	private Rigidbody2D rb;
	public LayerMask stairs;
	
	public float up;
	
	public bool isClimbing;
	public bool isGrounded;
	
	public float jumpForce;
	
	public bool isLadder;
	public float climbSpeed;
	
	
	
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		jumpForce = 5f;
		
    }
	
    void FixedUpdate()
    {
		//movimentação lateral
        iHorizontal = Input.GetAxisRaw("Horizontal");
				
			rb.velocity = new Vector2(iHorizontal * speed, rb.velocity.y );
		
		//check da escada
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, up, stairs);
		if (isLadder == true){
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				isClimbing = true;
			print("Dale Escadinha");
			
			} else {
				if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.	GetKeyDown(KeyCode.RightArrow)){
					isClimbing = false;
				}
			}
		}
		if(isClimbing == true){
			
			iVertical = Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(0, iVertical * stairSpeed);
			rb.gravityScale = 0;
			
		} else {
			
			iVertical = Input.GetAxisRaw("Vertical");
			rb.gravityScale = 1;
			
		}
		
		if(Input.GetKeyDown(KeyCode.Space)){
			print("SAmueeeeeeeeelLLLLLLLLLLLL aaaaaaaaaaaaaaaaa");
			rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
			}
		}
		
}
