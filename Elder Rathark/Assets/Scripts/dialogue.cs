using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    bool talking;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        // Sets to unactive, and sets the string to be empty,
        // must be set to active before using
        
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
        talking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (talking && gameObject.activeSelf)
        {
            StartDialogue();
        }
        // Mouse down will either cycle through to the next dialogue, or skip through dialogue
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            talking = false;
            gameObject.SetActive(false);
        }
    }
}
