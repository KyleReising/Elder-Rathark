using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool talking;
    private int index;
    [SerializeField] private player player;


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
            talking = false;
            player.inConvo = true;
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

    public void setLine(string[] toAdd)
    {

        lines = toAdd;
    }

    public void clearLines()
    {
        player.inConvo = false;
        index = 0;
        textComponent.text = "";
        string[] temp = { "" };
        lines = temp;
    }

    //print characters slowly
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
            clearLines();
            
            talking = false;
            gameObject.SetActive(false);
            
        }
    }
}
