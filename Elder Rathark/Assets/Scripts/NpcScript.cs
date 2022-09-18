using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcScript : MonoBehaviour
{

    [SerializeField] private detection detection;

    // pathfinding & patrol
    public Transform[] waypoints;
    private int waypointIndex;
    private float speed = 2f;
    public float waitTime = 1f;
    private float waitCounter = 0;
    private bool waiting = false;

    //sus meter
    public float maxSus;
    private float curSus = 0;
    public Slider slider;
    private bool playerDisguiseWorks = false;
    


    public SpriteRenderer big_cheese;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate sus
        if(detection.isHittingPlayer())  //hitting player
        {
            if (!playerDisguiseWorks)   //wrong disguise
            {
                curSus++;
                slider.value = curSus / maxSus;
                if (curSus >= maxSus)
                    print("i found you");   //*************** CHANGE ME TO END GAME ********************
            }
        }

        //set view position
        detection.SetOrigin(transform.position);

        //patrol to dynamic waypoints
            //chill for a second after reaching a waypoint
            if (waiting)
            {
                waitCounter += Time.deltaTime;
                if (waitCounter < waitTime)
                    return;    
                waiting = false;
            }
            Transform wp = waypoints[waypointIndex];  //set next waypoint
            //reached waypoint
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;
                waypointIndex = (waypointIndex + 1) % waypoints.Length; //set next waypoint
            }
            else  //move to waypoint
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
                transform.position = temp;
                Vector3 bingo = wp.position - transform.position;
                detection.SetAimDirection(new Vector3(-bingo.y, bingo.x, bingo.z));  // no, i dont know why x and y are flipped
            }



        //have sprite look at waypoint
            if (wp.position.x > transform.position.x)  //wp to right
            {
                big_cheese.flipX = true;
            }
            else
            {
                big_cheese.flipX = false;
            }


        

    }


}
