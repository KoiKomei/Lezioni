using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

    private float health;
    private float healthpack;
    [SerializeField] private Slider healthbar;
    // Use this for initialization
    private AudioSource _sound;

	void Start () {
        health = Managers.Player.health;
        healthbar.maxValue = Managers.Player.maxHealth;
        healthpack = Managers.Player.healthPackValue;
        _sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H) && Managers.Inventory.GetItemCount("health") != 0)
        {
            health += healthpack;
            healthbar.value += healthpack;
            if (health > Managers.Player.health)
            {
                health = Managers.Player.health;
                healthbar.value = healthbar.maxValue;
            }
            Managers.Inventory.ConsumeItem("health");
        }
    }

    public void hurt(int damage) {
        health -= damage;
        healthbar.value = health;
        
    }

    public void Death() {
        //fillImg.enabled = false;
        //gameOver.enable = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        GameEvent.ispaused = true;
    }
}
