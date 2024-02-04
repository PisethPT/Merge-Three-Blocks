using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransformPositions : MonoBehaviour
{
    public Transform portTransforms;
    public static int countObjectTransform = 0;
    public static List<string> getDiceNames = new List<string>();
    public static List<GameObject> diceTransform = new List<GameObject>();
    public GameObject[] dicesBroken;
    public Transform dicesBrokenParent;
    public Text score, level, highScore;

    public static void Clear(){
        countObjectTransform = 0;
        getDiceNames.Clear();
        diceTransform.Clear();
    }
}
