using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collsionManger : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        TryGetComponent<Animator>(out _anim);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("click");
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
