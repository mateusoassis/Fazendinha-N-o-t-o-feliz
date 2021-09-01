using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationLouvaDeus : MonoBehaviour
{
	public float timer1 = 1.2f;
	public float timer2 = 6.0f;
	public float timeToThrow = 6.0f;
	
	private Animator animator;
	
	const int STATE_IDLE = 0;
	const int STATE_FENO = 1;
	int currentAnimationState = STATE_IDLE;
	
	public Rigidbody2D[] feno = new Rigidbody2D[2];
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
		speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
		
	}
	
	public void fenoNow()
	{
		
		Rigidbody2D clone;
				
		int r = Random.Range(0,2);
			
		clone = Instantiate (feno[r], transform.position, Quaternion.identity) as Rigidbody2D;
		clone.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
	}
	
	void changeState (int state){
		if (currentAnimationState == state)
			return;
		
		switch (state) {
			
		case STATE_IDLE:
			animator.SetInteger ("state", STATE_IDLE);
			break;
			
		case STATE_FENO:
			animator.SetInteger ("state", STATE_FENO);
			break;
			
		}
		
		currentAnimationState = state;
		
	}
}

