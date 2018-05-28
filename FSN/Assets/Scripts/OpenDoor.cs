using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {


    [SerializeField] private Vector3 dpos;
    private bool open;

    public void Operate()
    {
        if (enabled)
        {
            if (open)
            {
                Vector3 pos = transform.position - dpos;
                transform.position = pos;
            }
            else
            {
                Vector3 pos = transform.position + dpos;
                transform.position = pos;
            }
            open = !open;

        }
    }
    public void Activate()
    {
        if (!open)
        {
            Vector3 pos = transform.position + dpos;
            transform.position = pos;
            open = true;
        }
    }
    public void Deactivate()
    {
        if (open)
        {
            Vector3 pos = transform.position - dpos;
            transform.position = pos;
            open = false;
        }
    }
}
