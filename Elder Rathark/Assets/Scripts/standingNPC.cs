using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingNPC : MonoBehaviour
{
    public Transform playerPos;
    [SerializeField] private dialogue dialogue;
    [SerializeField] private player player;
    bool inConvo = false;
    public string[] peepo;
    public TextAsset textFile;
    // Start is called before the first frame update




    void Start()
    {
        playerPos = player.transform;
        string text = textFile.text;
        string lines = text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!(player.inConvo) && Input.GetKeyDown(KeyCode.E) && (transform.position-playerPos.position).magnitude < new Vector3(2.0f,2.0f,0.0f).magnitude )
        {
            inConvo = true;
            dialogue.talking = true;
            dialogue.gameObject.SetActive(true);
            
            dialogue.setLine(peepo);
            
        }
        

    }
}
