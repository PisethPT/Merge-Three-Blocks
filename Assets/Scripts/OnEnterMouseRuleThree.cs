using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOnEnterMouseRuleThree : MonoBehaviour
{
    public int transformIndex;
    void OnMouseDown()
    {
        if (TransformPositions.countObjectTransform < 5)
        {
            TransformPositions.countObjectTransform++;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            TransformPositions.getDiceNames.Add(transform.gameObject.name);
            TransformPositions.diceTransform.Add(transform.gameObject);

            InstantiateDices.count2--;
            InstantiateDices.isInstantiate2 = true;
            InstantiateDices.time = .3f;
            StartCoroutine(MovementObject());
            StartCoroutine(DestroyObject());
            IEnumerator DestroyObject()
            {
                yield return new WaitForSeconds(.1f);
                Destroy(transform.GetComponent<OOnEnterMouseRuleThree>());
            }
        }
    }

    IEnumerator MovementObject()
    {
        while (transform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(FindAnyObjectByType<TransformPositions>().portTransforms.GetChild(TransformPositions.countObjectTransform - 1).transform.position.x, FindAnyObjectByType<TransformPositions>().portTransforms.GetChild(TransformPositions.countObjectTransform - 1).transform.position.y, -1f), 900 * Time.deltaTime);
            yield return null;
        }

    }
}
