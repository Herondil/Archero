using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOTest : MonoBehaviour
{
    SOLife test;

    void Start()
    {
        test = (SOLife)ScriptableObject.CreateInstance(typeof(SOLife));

        print(test.A);
        print(test.B(3));
        print(test.B(-3));
    }
}