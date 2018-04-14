using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsblock : MonoBehaviour {

    private int capAt = 60;
	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = capAt;
	}
	
}
