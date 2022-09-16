using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    


    public SpriteRenderer big_cheese;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //patrol to dynamic waypoints

        //chill for a second after reaching a waypoint
        if (waiting)
            {
                waitCounter += Time.deltaTime;
                if (waitCounter < waitTime)
                    return;
                waiting = false;
            }
            Transform wp = waypoints[waypointIndex];
            //reached waypoint
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                
            }
            else  //move to waypoint
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
                transform.position = temp;
                
                detection.SetOrigin(transform.position);
            }
            //look at waypoint
            if (wp.position.x > transform.position.x)  //wp to right
            {
                detection.SetAimDirection(new Vector3(0.0f, 1.0f, 0f));
                big_cheese.flipX = true;
            }
            else
            {
                detection.SetAimDirection(new Vector3(0.0f, -1.0f, 0f));
                big_cheese.flipX = false;
            }


        

    }


}
