using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    private float health;
	// Use this for initialization
	void Start () {
        health = 5;
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void hurt(int damage) {
        health -= damage;
        Debug.Log("Health: " + health);
    }
}
