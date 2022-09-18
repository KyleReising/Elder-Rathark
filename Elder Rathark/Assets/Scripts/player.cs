using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public enum Disguise { TRENCH, SUIT };
    /// This will be sent to setAnimation() as a parameter
    /// In there, it'll flip the sprites and figure out which direction to face
    /// 



    public Rigidbody2D body;
    public float moveSpeed;
    public Camera cam;

    //Max's animation stuff?
    public Animator trenchcoat;
    public Animator suit;
    public SpriteRenderer SR;
    public SpriteRenderer OtherSR;
    public Disguise di;
    public List<Disguise> closet = new List<Disguise>();
    private int indexInCloset = 0;


    //talking stuff
    public bool inConvo;



    void Start()
    {
        
    }
    void setAnim(string command)
    {
        //dont u just love spaghetti
        if (di == Disguise.TRENCH)
        {
            trenchcoat.SetTrigger(command);
        }
        else if (di == Disguise.SUIT)
        {
            suit.SetTrigger(command);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Change Disguises...
        if(Input.GetKeyDown(KeyCode.Q))
        {
            indexInCloset++;
            indexInCloset = indexInCloset % closet.Count;
            di = closet[indexInCloset];
           
        }

        //Check disguise.  Yes, every frame.  Totally necessary.
        if(di == Disguise.TRENCH)
        {
            trenchcoat.gameObject.SetActive(true);
            suit.gameObject.SetActive(false);
        }
        if (di == Disguise.SUIT)
        {
            trenchcoat.gameObject.SetActive(false);
            suit.gameObject.SetActive(true);
        }

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        do_input(hAxis, vAxis);



        if(hAxis > 0.01)
        {
            SR.flipX = true;
            OtherSR.flipX = true;
            //let our animation know what to do... needs refacotring but on a deadline here
            setAnim("WALK");
        }
        else if (hAxis < -0.01)
        {
            SR.flipX = false;
            OtherSR.flipX = false;
            setAnim("WALK");
        }
        else if(vAxis != 0.0f)
        {
            setAnim("WALK");
        }
        else if(hAxis == 0.0f && vAxis == 0.0f)
        {
            setAnim("IDLE");
        }
    }

    void do_input(float horiz, float vert)
    {
        int speedMod = 1;
        Vector3 mousePos = Input.mousePosition;
        Vector3 aim = cam.ScreenToWorldPoint(mousePos);
        float actualSpeedx = horiz * moveSpeed * speedMod;
        float actualSpeedy = vert * moveSpeed * speedMod;
        body.velocity = new Vector3(actualSpeedx, actualSpeedy, 0);



    }
}
