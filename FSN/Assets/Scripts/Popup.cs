using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    [SerializeField] private Text nameLabel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open() {
        gameObject.SetActive(true);
        PauseGame();
    }

    public void Close() {
        gameObject.SetActive(false);
        StartGame();
    }

    public void onSubmitName(string name) {
        nameLabel.text = name;
    }

    public void onSpeedChange(float speed) {

    }

    public void PauseGame() {
        GameEvent.ispaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void StartGame() {
        GameEvent.ispaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void OnSpeedValue(float speed) {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
