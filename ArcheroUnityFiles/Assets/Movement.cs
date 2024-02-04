using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed; //modification autorisée ?
    public Vector2 direction; //probablement à mettre en private

    private Rigidbody2D rgbd;


    public SOLife test;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rgbd);


        test = (SOLife)ScriptableObject.CreateInstance(typeof(SOLife));

        print(test.A);
        print(test.B(3));
        print(test.B(-3));
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
 
    private void FixedUpdate()
    {
        rgbd.velocity = direction * speed;
    }
}
