using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    enum animState { RUN, FIRE, MELEE, HURT, GRAP }
    /// This will be sent to setAnimation() as a parameter
    /// In there, it'll flip the sprites and figure out which direction to face
    /// 



    public Rigidbody2D body;
    public float moveSpeed;
    public Camera cam;

    //talking stuff
    public bool inConvo;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        do_input(hAxis, vAxis);
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
