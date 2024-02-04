using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDetect : MonoBehaviour
{
    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("dice")){
            StartCoroutine(waitCheckDiceMatch());
            IEnumerator waitCheckDiceMatch(){
               // print(other.gameObject.name);
               FindAnyObjectByType<SoundControl>().sfxSources[1].Play();
                yield return new WaitForSeconds(.5f);
                CheckConditions.CheckCondition();
            }
        }
    }
}
