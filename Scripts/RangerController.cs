using UnityEngine;
using System.Collections;

public class RangerController : MonoBehaviour {

    public GameObject trap = null;
    public int speed = 10;
    public int range = 0;

    private Vector3 targetpos;
    private GameObject target;
    private float distance;
    private double timer;

    private enum State { IDLE, MOVING, CHASING, ATTACKING, TRAP }
    private State currentState;

	// Use this for initialization
	void Start () {
        currentState = State.IDLE;
        distance = 0;
        timer = 0.75;
        animation["attack2"].speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {


        switch (currentState)
        {
            case State.IDLE:
                if (!animation.IsPlaying("combat_idle"))
                    animation.Play("combat_idle");

                break;

            case State.MOVING:
                if (!animation.IsPlaying("walk"))
                    animation.Play("walk");

                if (transform.position != targetpos)
                    transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
                else
                    currentState = State.IDLE;

                break;

            case State.CHASING:
                if (!animation.IsPlaying("walk"))
                    animation.Play("walk");

                distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance > range)
                {
                    transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    currentState = State.ATTACKING;
                }

                break;

            case State.ATTACKING:
                distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance > range)
                {
                    currentState = State.CHASING;
                }
                else
                {
                    transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    
                    if (!animation.IsPlaying("attack2"))
                        animation.Play("attack2");
                    
                    /*
                    animation.PlayQueued("weapons_get", QueueMode.PlayNow);
                    animation.PlayQueued("attack3", QueueMode.CompleteOthers);
                    */
                    Debug.Log("Hiiiiyaaaaa");
                }

                break;

            case State.TRAP:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    GameObject t = Instantiate(trap, new Vector3(transform.position.x, transform.position.y - 75, transform.position.z + 100), Quaternion.identity) as GameObject;
                    animation.Stop("remove_weapons");
                    currentState = State.IDLE;
                    timer = 0.75;
                }

                break;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentState = State.TRAP;
            animation.Play("remove_weapons");
        }

	}

    //Metodo de recibo de mensajes
    void GoToPosition(GameObject go)
    {
        move(go.transform.position);
        if (go.tag != "Trap")
        {
            currentState = State.CHASING;
            target = go;
        }
        else
        {
            currentState = State.MOVING;
        }
        
    }

    void GoToPosition(Vector3 pos)
    {
        move(pos);
        currentState = State.MOVING;
    }

    //Movimiento
    void move(Vector3 pos)
    {
        pos += new Vector3(0, 26, 0);
        transform.LookAt(new Vector3(pos.x, transform.position.y, pos.z));
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        targetpos = pos;
    }
}
