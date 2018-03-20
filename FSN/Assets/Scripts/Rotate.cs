using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float speed = 3.0f;
    private void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }
}
