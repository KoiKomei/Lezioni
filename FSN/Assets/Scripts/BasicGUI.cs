using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 20), "Testo casuale")) {
            Debug.Log("eww");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
