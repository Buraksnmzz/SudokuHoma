using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates selectable numbers on the bottom
/// </summary>
public class NumberGenerator : MonoBehaviour
{
    private int numberCount = 9;
    public GameObject numberObjectPrefab;
    void Start()
    {
        StartCoroutine(GenerateNumberAnimation());
    }
    IEnumerator GenerateNumberAnimation()
    {
        for (int numberIndex = 0; numberIndex < numberCount; numberIndex++)
        {
            GameObject instantiatedNumber = Instantiate(numberObjectPrefab, transform);
            instantiatedNumber.GetComponent<NumberButton>().SetNumberInButton((numberIndex + 1));
            yield return new WaitForSeconds(0.04f);
        }
    }
}
