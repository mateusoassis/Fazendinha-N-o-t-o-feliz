using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
	public float jumpForce = 5.0f;
	public float speed = 5.0f;
	public float stairSpeed = 3.0f;
	
	private Rigidbody2D rb;
	
	public float iHorizontal;
	public float direcao;
	public float iVertical;
	
	public bool isLadder;
	public bool isGrounded;
	public bool isClimbing;
	public bool isJumping;
	public bool jumpingEnemy;
	
	public AudioSource audioSource;
	
	public bool rightDirection = true;
	
	public Transform groundCheck;
	public float radiusCheck;
	public LayerMask layerGround;
	
	public Transform scoreCheck;
	public float radius2Check;
	public LayerMask layerScore;
	
	public Vector3 upLadder;
	
	//animações
	const int STATE_IDLE = 0;
	const int STATE_JUMP = 1;
	const int STATE_CLIMB = 2;
	const int STATE_WALK = 3;
	const int STATE_CLIMB_IDLE = 4;
	int currentAnimationState = STATE_IDLE;
	private Animator animator;	
	
	private float nextActionTime = 0.5f;
	public float period = 0.01f;
	
	
	// chamar os componentes acoplados no objeto
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		animator = this.GetComponent<Animator>();
    }

    void Update()
    {
		checkOnTheFloor();
		Playfootsteps();
		
		//pulo
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
				rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
				
		}
	
		
		//definição da direção de movimentação vertical + troca de direção
		// -1 = esquerda
		// 1 = direita
		iHorizontal = Input.GetAxisRaw("Horizontal");
		if(iHorizontal == 1 && isGrounded == true){
			if(rightDirection == false){
				changeDirection();
			}
		} else if(iHorizontal == -1 && isGrounded == true){
			if(rightDirection == true){
				changeDirection();
			}
		
		}
		
        //movimentação lateral
		if (iHorizontal != 0){
			if(isGrounded == true && isClimbing == false){
			rb.velocity = new Vector2(iHorizontal * speed, rb.velocity.y );
			
			//adicionei o iHorizontal em condições para detectar que estava no chão e não climbing, e assim, trocar de STATE
			changeState (STATE_WALK);
		} 
			
		} else {
			if (isGrounded == true){
				changeState(STATE_IDLE);
			}
		}	
		//definição da direção de movimentação vertical
		iVertical = Input.GetAxisRaw("Vertical");
		
		//check se está escalando escada
		if(isLadder == true && iVertical != 0){
			isClimbing = true;
			
			//fácil, só adicionar o state_climb
			changeState (STATE_CLIMB);
		}
		
		//movimentação vertical
		if(isClimbing == true){
			rb.gravityScale = 0;
			transform.position = new Vector2(upLadder.x, rb.position.y);
			rb.velocity = new Vector2(0, iVertical * stairSpeed);
			if(iVertical == 0){
				changeState (STATE_CLIMB_IDLE);
			}
		} else {
			rb.gravityScale = 2;
		}
	}
	
	//check de física (chamar o que checa se está ou não no chão)
	void FixedUpdate()
	{
		checkScore();
	}
	
	//troca de animação
	void changeState (int state){
		if (currentAnimationState == state)
			return;
		
		switch (state) {
			
		case STATE_IDLE:
			animator.SetInteger ("state", STATE_IDLE);
			break;
			
		case STATE_JUMP:
			animator.SetInteger ("state", STATE_JUMP);
			break;
				
		case STATE_CLIMB:
			animator.SetInteger ("state", STATE_CLIMB);
			break;
				
		case STATE_WALK:
			animator.SetInteger ("state", STATE_WALK);
			break;
			
		case STATE_CLIMB_IDLE:
			animator.SetInteger ("state", STATE_CLIMB_IDLE);
			break;
			
		}
		
		currentAnimationState = state;
		
	}
	
	//som dos passos
	private void Playfootsteps()
	{
		if (iHorizontal != 0 && isGrounded == true)
		{
			audioSource.enabled = true;
			audioSource.loop = true;		
			
		} else {
			
			audioSource.enabled = false;
			audioSource.loop = false;

		}
	}
	//check do chão
	void checkOnTheFloor() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, layerGround);
		if (isGrounded == true){
			isClimbing = false;
			isJumping = false;
		} else if(isClimbing == false && isGrounded == false){
		
			isJumping = true;
			changeState(STATE_JUMP);
		
		}
    }
	
	void checkScore() {
		jumpingEnemy = Physics2D.OverlapCircle(scoreCheck.position, radius2Check, layerScore);
		if(jumpingEnemy == true){
			if (Time.time > nextActionTime ){
				nextActionTime = Time.time + period;
				ScoreScript.scoreValue += 100;
			}
		}
	}
	
	//triggers para detectar a escada
	void OnTriggerEnter2D(Collider2D other){		
		if(other.gameObject.tag == "ladder"){
			isLadder = true;
			upLadder = other.transform.position;
		}
		if(other.gameObject.tag == "victory"){
			SceneManager.LoadScene("YouWinScene");
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "ladder"){
			isLadder = false;
		}
	}
	
	//troca de direção
	void changeDirection()
	{
		rightDirection = !rightDirection;
		Vector3 changeScale = transform.localScale;
		changeScale.x *= -1;
		transform.localScale = changeScale;
	}
}

