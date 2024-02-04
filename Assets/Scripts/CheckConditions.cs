using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TransformPositions;

public class CheckConditions : MonoBehaviour
{
   private static CheckConditions instance;
   private static string diceName;
   [System.Obsolete]
   void Awake()
   {
      instance = this;
      Clear();
      InstantiateDices.UpdateGame();
   }
   [System.Obsolete]

    public static bool CheckCondition()
   {
      PlayerPrefs.SetInt("hight", FindObjectOfType<ScoresandLevels>().highScores);
      FindObjectOfType<ScoresandLevels>().saveLevel();
      if (getDiceNames.Count == 3)
      {
         if (getDiceNames[0] == getDiceNames[1] && getDiceNames[1] == getDiceNames[2])
         {
            diceName = getDiceNames[0];
            FindAnyObjectByType<SoundControl>().sfxSources[3].Play();
            Explosions(diceTransform, diceName, 0, 1, 2);
            DestroyObject(0, 2);
            return true;
         }
         else
         {
            return false;
         }
      }
      else if (getDiceNames.Count == 4)
      {
         diceName = getDiceNames[1];
         if (getDiceNames[1] == getDiceNames[2] && getDiceNames[2] == getDiceNames[3])
         {
            FindAnyObjectByType<SoundControl>().sfxSources[3].Play();
            Explosions(diceTransform, diceName, 1, 2, 3);
            DestroyObject(1, 3);
            return true;
         }
         else
         {
            return false;
         }
      }
      else if (getDiceNames.Count == 5)
      {
         FindAnyObjectByType<SoundControl>().sfxSources[3].Play();
         diceName = getDiceNames[2];
         if (getDiceNames[2] == getDiceNames[3] && getDiceNames[3] == getDiceNames[4])
         {
            Explosions(diceTransform, diceName, 2, 3, 4);
            DestroyObject(2, 4);
            return true;
         }
         else
         {
           // print("lose");
            //instance.StartCoroutine(UpdateGameAfterLose());
            InstantiateDices.UpdateGame();
            Clear();
            FindObjectOfType<ScoresandLevels>().saveLevel();
            SceneManager.LoadScene("Block");
            return false;
         }

      }
      else
         return false;

   }

    [System.Obsolete]
    static IEnumerator UpdateGameAfterLose()
   {
      yield return new WaitForSeconds(.5f);
      InstantiateDices.UpdateGame();
      Clear();
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   [System.Obsolete]
   static void DestroyObject(int first, int last)
   {
      for (int i = last; i >= first; i--)
      {
         Destroy(diceTransform[i]);
         diceTransform.RemoveAt(i);
         getDiceNames.RemoveAt(i);
      }
      countObjectTransform -= 3;
      FindObjectOfType<ScoresandLevels>().scores += 10;
      if (FindObjectOfType<ScoresandLevels>().scores >= FindObjectOfType<ScoresandLevels>().highScores)
      {
         FindObjectOfType<ScoresandLevels>().highScores = FindObjectOfType<ScoresandLevels>().scores;
      }
      FindAnyObjectByType<ScoresandLevels>().getLevels();
      FindAnyObjectByType<TransformPositions>().score.text = "SCORE: " + FindAnyObjectByType<ScoresandLevels>().scores.ToString();
      FindAnyObjectByType<TransformPositions>().highScore.text = "HIGH SCORE: " + FindAnyObjectByType<ScoresandLevels>().highScores.ToString();
      FindAnyObjectByType<TransformPositions>().level.text = "LEVEL: " + FindAnyObjectByType<ScoresandLevels>().levels.ToString();
   }
   
   private static void Explosions(List<GameObject> transformPositions, string diceName, params int[] indices)
   {
      int indexDice = 0;
      for (int i = 0; i < FindAnyObjectByType<TransformPositions>().dicesBroken.Length; i++)
      {
         if (string.Compare(diceName, FindAnyObjectByType<TransformPositions>().dicesBroken[i].name) == 0)
            indexDice = i;
      }
      foreach (int index in indices)
      {
         GameObject explosion = Instantiate(FindAnyObjectByType<TransformPositions>().dicesBroken[indexDice], transformPositions[index].transform.position, Quaternion.identity);
         explosion.transform.SetParent(FindAnyObjectByType<TransformPositions>().dicesBrokenParent, true);
         foreach (Transform child in explosion.transform)
         {
            Rigidbody2D rb2D = child.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
               Vector2 forceDirection = ((Vector2)transformPositions[index].transform.position - rb2D.position).normalized;
               rb2D.AddForce(forceDirection * -4f, ForceMode2D.Impulse);
            }
         }
      }

      for (int i = 0; i < FindAnyObjectByType<TransformPositions>().dicesBrokenParent.childCount; i++)
      {
         Destroy(FindAnyObjectByType<TransformPositions>().dicesBrokenParent.GetChild(i).gameObject, 1f);
      }


   }

}
