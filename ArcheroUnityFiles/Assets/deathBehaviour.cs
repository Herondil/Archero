using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathBehaviour : StateMachineBehaviour
{
    public KillCount _kc;

    private void Awake()
    {
        //_kc = 
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
        //
        _kc.killCount++;
    }

}
