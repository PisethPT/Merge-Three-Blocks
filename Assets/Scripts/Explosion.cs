using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float addfoce = 300f;
    float radius = 2f;
    void Start()
    {
        
    }

    void Explosions(){
        Rigidbody rd = transform.AddComponent<Rigidbody>();
    }
}
