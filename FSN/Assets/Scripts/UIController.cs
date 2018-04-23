using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private int _score;
    [SerializeField] private Text scorelabel;
    [SerializeField] private Popup popup;
	void Start () {
        popup.Close();
        _score = 0;
        scorelabel.text = _score.ToString();
	}

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Update is called once per frame
    void Update () {
        // scorelabel.text = Time.realtimeSinceStartup.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            popup.Open();
        }
		
	}
    private void OnEnemyHit() {
        _score++;
        scorelabel.text = _score.ToString();
    }

    public void OpenSettings() {
        Debug.Log("Open Settings");
        popup.Open();
    }
}
