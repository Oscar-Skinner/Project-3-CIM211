using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed;
    public string textToType;
    public TextMeshProUGUI displayText;

    void OnEnable()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in textToType)
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
