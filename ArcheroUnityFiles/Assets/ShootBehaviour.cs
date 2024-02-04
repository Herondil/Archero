using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : StateMachineBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Transform bulletGroup;

    private void Awake()
    {
        bulletGroup = GameObject.Find("BulletsGroup").transform;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2[] directions = new Vector2[4]
        {
            Vector2.right,
            Vector2.left,
            Vector2.up,
            Vector2.down
        };

        for (int i = 0; i < 4; i++)
        {
            //cr�er le projectile
            //placer le projectile
            //addforce sur le projectile
            //changer le parent pour "trier" la hi�rarchie
            GameObject b = Object.Instantiate(bulletPrefab, animator.gameObject.transform);
            b.transform.localPosition = Vector2.zero;
            b.GetComponent<Rigidbody2D>().AddForce(directions[i] * bulletSpeed);
            b.transform.parent = bulletGroup; //facultative
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //invoquer le after shoot

        //ici c'est maintenant que l'�v�vement se produit

        GameObject.Find("RewardManager").GetComponent<RewardsEffects>().AfterAttack.Invoke();
    }
}
