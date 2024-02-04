using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class RewardsEffects : MonoBehaviour
{

    /*******/

    public UnityEvent AfterEnnemyDeath;
    public UnityEvent AfterAttack;


    /*******/


    //information de la bullet bonus
    public Vector3 bonusBulletPos;

    //[Header("Double Attack")]
    //information de la double attack
    public GameObject bulletPrefab;
    public Transform playerTranform;
    public Transform bulletGroup;
    public float bulletSpeed;

    public GameObject OptionPanel;

    //public AnimationCurve RewardsSteps;

    //pointeur des m�thodes "Add"
    //public delegate void AddListener();
    //Array des m�thodes
    //public UnityAction[] Adders;


    //Singleton pattern
    private RewardsEffects() { }

    //"auto-r�f�rence" vers l'unique instance, null de base
    //static car au niveau de la classe enti�re
    private static RewardsEffects _instance = null;

    //Singleton comme Property, avec set
    public static RewardsEffects instance
    {
        get
        {
            //deux cas possible, soit l'instance existe, soit non
            if (_instance == null)
            {
                _instance = new RewardsEffects();
                Debug.Log("Instanciation du reward Manager");
            }
            return _instance;
        }
    }

    //m�thode pour le bouton de gauche
    public void AddBonusBulletWhenEnnemyDies()
    {
        AfterEnnemyDeath.AddListener(CreateBonusBullet);
        //AfterEnnemyDeath += CreateBonusBullet;


        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }

    //m�thode pour le bouton de droite
    public void AddExtraAttack()
    {
        AfterAttack.AddListener(DoubleAttack);
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }


    //M�thode pour cr�er le tir � la mort d'un ennemi
    void CreateBonusBullet()
    {
        //instanciation d'une bullet
        GameObject b = Instantiate(bulletPrefab);
        b.transform.position = bonusBulletPos;
        b.transform.parent = bulletGroup;
        b.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized * bulletSpeed);
        //direction al�atoire
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
