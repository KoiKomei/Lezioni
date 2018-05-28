using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedDoor : MonoBehaviour {

    [SerializeField] private Vector3 dpos;

    private Vector3 closepos;
    private Vector3 openpos;

    private bool open;
    private bool moving;
	// Use this for initialization
	void Start () {
        closepos = transform.position;
        openpos = closepos + dpos;
	}

    public void Operate()
    {
        if (!open)
        {
            if (!moving)
            {
                moving = true;
            }
            else
            {
                open = true;
            }
        }
        else
        {
            if (!moving)
            {
                moving = true;
            }
            else
            {
                open = false;
            }
        }
    }

    public void Activate()
    {
        if (!open)
        {
            moving = true;
        }
        else if (moving)
        {
            open = false;
        }
    }
    public void Deactivate()
    {
        if (open)
        {
            moving = true;
        }
        else if (moving)
        {
            open = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (moving)
        {
            doorAnimation();
        }
		
	}
    void doorAnimation()
    {
        if (!open)
        {
            if (transform.position != openpos)
            {
                transform.position = Vector3.Lerp(transform.position, openpos, 3f * Time.deltaTime);
            }
            else
            {
                moving = false;
                open = true;
            }
        }
        else
        {
            if (transform.position != closepos)
            {
                transform.position = Vector3.Lerp(transform.position, closepos, 3f * Time.deltaTime);
            }
            else
            {
                moving = false;
                open = false;
            }
        }
    }
}
