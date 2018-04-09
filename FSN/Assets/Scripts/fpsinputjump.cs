using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //dice che c'è
[AddComponentMenu("Control Scipt/fpsinput")]

public class fpsinputjump : MonoBehaviour {
    private CharacterController _char;
	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
		
	}
	private float speed = 6.0f;
    private float jump = 8.0f;
    private float gravity = -9.8f;
    private Vector3 move = Vector3.zero;
    bool flip = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire3"))
        {
            _char.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, w: 0));
        }
        float deltaX = Input.GetAxis("Horizontal") * (flip ? -1 : 1);
        deltaX = deltaX * speed;

        float deltaZ = Input.GetAxis("Vertical") * speed;
        if (_char.isGrounded)
        {
            move = new Vector3(deltaX, 0, deltaZ);
            move = Vector3.ClampMagnitude(move, speed);

            move = transform.TransformDirection(move);
            if (Input.GetButton("Jump"))
            {
                move.y = jump;
            }
        }
        move.y += gravity * Time.deltaTime;
        _char.Move(move * Time.deltaTime);
    }
}
