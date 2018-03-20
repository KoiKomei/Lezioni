using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //dice che c'è
[AddComponentMenu("Control Scipt/fpsinput")]

public class fpsinput : MonoBehaviour {
    private CharacterController _char;
	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
		
	}
	public float speed = 6.0f;
    public float gravity = -9.8f;
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _char.Move(movement);
	}
}
