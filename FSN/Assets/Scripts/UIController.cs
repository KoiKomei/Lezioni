using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Popup popup;
	void Start () {
        popup.Close();
	}
	
	// Update is called once per frame
	void Update () {
       // scorelabel.text = Time.realtimeSinceStartup.ToString();
		
	}

    public void OpenSettings() {
        Debug.Log("Open Settings");
        popup.Open();
    }
}
