using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("dice")){
            FindAnyObjectByType<SoundControl>().sfxSources[0].Play();
        }
    }
}
