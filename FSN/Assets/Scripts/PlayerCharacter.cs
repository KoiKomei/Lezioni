using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

    private float health;
    [SerializeField] private Slider healthbar;
	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void hurt(int damage) {
        health -= damage;
        healthbar.value = health;
        
    }

    public void Death() {
        fillImg.enabled = false;
        gameOver.enable = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        GameEvent.ispaused = true;
    }
}
