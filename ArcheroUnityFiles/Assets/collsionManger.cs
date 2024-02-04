using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collsionManger : MonoBehaviour
{
    private Animator _anim;
    public KillCount _kc;

    private void Awake()
    {
        TryGetComponent<Animator>(out _anim);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //on peut aussi utiliser "CompareTag"
        switch (collision.gameObject.tag)
        {
            case "Player":
            {
                Debug.Log("Game Over, hit FIRE1 to reload");
                Time.timeScale = 0;
                break;
            }
            case "Bullets":
            {
                Destroy(collision.collider.gameObject);
                _anim.SetTrigger("death");
                break;
            }
        }
    }

    private void Update()
    {
        //Relancer le jeu
        if (Input.GetButton("Fire1"))
        {
            Time.timeScale  = 1;
            _kc.killCount   = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
