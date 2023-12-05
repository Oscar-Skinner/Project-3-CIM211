using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // Adjust the scroll speed as needed
    public GameObject bottomObj;
    public GameObject TopObj;
    private bool scrollBool = true;
    
    void Start()
    {
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        while (scrollBool) // Use true for continuous scrolling
        {
            float newY = transform.position.y + scrollSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            if (bottomObj.transform.position.y >= TopObj.transform.position.y)
            {
                scrollBool = false;
            }
            
            yield return null; // Wait for the next frame
        }

        if (scrollBool == false)
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
