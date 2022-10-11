using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardsEffects : MonoBehaviour
{
    public UnityEvent AfterEnnemyDeath;
    public UnityEvent AfterAttack;

    //information de la bullet bonus
    public Vector3 bonusBulletPos;

    //[Header("Double Attack")]
    //information de la double attack
    public GameObject bulletPrefab;
    public Transform playerTranform;
    public Transform bulletGroup;
    public float bulletSpeed;

    public GameObject OptionPanel;

    public void AddBonusBulletWhenEnnemyDies()
    {
        AfterEnnemyDeath.AddListener(CreateBonusBullet);
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }

    public void AddExtraAttack()
    {
        AfterAttack.AddListener(DoubleAttack);
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }

    void CreateBonusBullet()
    {
        //instanciation d'une bullet
        GameObject b = Instantiate(bulletPrefab);
        b.transform.position = bonusBulletPos;
        b.transform.parent = bulletGroup;
        b.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized * bulletSpeed);
        //direction aléatoire
        Debug.Log("Bonus Bullet");
    }

    void DoubleAttack()
    {
        //random 50%
        Debug.Log("Double Attack");

        if(Random.Range(0,2) == 1)
        {
            Vector2[] directions = new Vector2[4]
            {
                new Vector2(1,1).normalized,
                new Vector2(1,-1).normalized,
                new Vector2(-1,1).normalized,
                new Vector2(-1,-1).normalized
            };

            for (int i = 0; i < 4; i++)
            {
                GameObject b = Object.Instantiate(bulletPrefab, playerTranform);
                b.transform.localPosition = Vector2.zero;
                b.GetComponent<Rigidbody2D>().AddForce(directions[i] * bulletSpeed);
                b.transform.parent = bulletGroup;
            }
        }
    }
}
