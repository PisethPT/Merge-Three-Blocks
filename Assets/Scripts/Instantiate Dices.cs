using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDices : MonoBehaviour
{
    public GameObject dicePrefabs;
    public Transform transforms;
    public Transform rules;
    public static int count = 0, count1 = 0, count2 = 0, count3 = 0, count4 = 0;
    public static float time = .3f;
    public static bool isInstantiate = true, isInstantiate1 = true, isInstantiate2 = true, isInstantiate3 = true, isInstantiate4 = true;
    public Sprite[] dicesSprite;
    [System.Obsolete]
    private void Awake() {
        count = count1 = count2 = count3 = count4 = 0;
      TransformPositions.Clear();
      UpdateGame();
      FindObjectOfType<ScoresandLevels>().scores = PlayerPrefs.GetInt("score");
      FindObjectOfType<ScoresandLevels>().highScores = PlayerPrefs.GetInt("hight");
      FindObjectOfType<ScoresandLevels>().getLevel();
      FindAnyObjectByType<TransformPositions>().score.text = "SCORE: " + FindAnyObjectByType<ScoresandLevels>().scores.ToString();
      FindAnyObjectByType<TransformPositions>().highScore.text = "HIGH SCORE: " + FindAnyObjectByType<ScoresandLevels>().highScores.ToString();
      FindAnyObjectByType<TransformPositions>().level.text = "LEVEL: " + FindAnyObjectByType<ScoresandLevels>().levels.ToString();
    }
    void Update()
    {
        Inits(0, ref count, ref isInstantiate);
        Inits(1, ref count1, ref isInstantiate1);
        Inits(2, ref count2, ref isInstantiate2);
        Inits(3, ref count3, ref isInstantiate3);
        Inits(4, ref count4, ref isInstantiate4);
    }


    void Inits(int index, ref int counts, ref bool isInstantiates)
    {
        time -= Time.deltaTime;

        if (time <= 0 && isInstantiates)
        {
            if (counts < 5)
            {
                int r = Random.Range(0, dicesSprite.Length);
                var dice = Instantiate(dicePrefabs, Vector3.zero, Quaternion.identity);
                dice.GetComponent<SpriteRenderer>().sprite = dicesSprite[r];
                dice.name = dicesSprite[r].name;
                dice.transform.SetParent(rules.GetChild(index), true);
                dice.transform.localPosition = new Vector3(transforms.GetChild(index).position.x, transforms.GetChild(index).position.y, -1f);
                dice.transform.localScale = Vector3.one *118.2f;
                time = 0.3f;
                switch(index){
                    case 0:
                        dice.AddComponent<OnEnterMouseRuleOne>();
                    break;
                    case 1:
                        dice.AddComponent<OnEnterMouseRuleTwo>();
                    break;
                    case 2:
                        dice.AddComponent<OOnEnterMouseRuleThree>();
                    break;
                    case 3:
                        dice.AddComponent<OnEnterMouseRuleFour>();
                    break;
                    case 4:
                        dice.AddComponent<OnEnterMouseRuleFive>();
                    break;
                }
                counts++;
            }
            else
            {
                isInstantiates = false;
                time = 0;
            }
        }
    }
    [System.Obsolete]
    public static void UpdateGame(){
        count = count1 = count2 = count3 = count4 = 0;
        isInstantiate = isInstantiate1 = isInstantiate2 = isInstantiate3 = isInstantiate4 = true;
    }

}
