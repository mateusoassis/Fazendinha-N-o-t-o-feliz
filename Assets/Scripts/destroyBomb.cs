using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBomb : MonoBehaviour
{
	const int STATE_WALK = 0;
	int currentAnimationState = STATE_WALK;
	
	private Animator animator;
	
    void Start()
    {
		animator = this.GetComponent<Animator>();
        Destroy(this.gameObject,12);
		changeState(STATE_WALK);
    }
	
	void changeState (int state){
		if (currentAnimationState == state)
			return;
		
		switch (state) {
			
		case STATE_WALK:
			animator.SetInteger ("state", STATE_WALK);
			break;
				
		}
		
		currentAnimationState = state;
		
	}
}
