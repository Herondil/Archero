using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heading : StateMachineBehaviour
{
    public GameObject   _target;
    public float        _speed;
    public Vector2      _dir;
    private Rigidbody2D _rgbd;

    private void Awake()
    {
        _target = GameObject.Find("Player");
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.TryGetComponent<Rigidbody2D>(out _rgbd);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //calculer la direction vers _target
        _dir = _target.transform.position - animator.transform.position;
        _dir = _dir.normalized;
        _rgbd.velocity = _dir * _speed * Time.deltaTime;
    }

}
