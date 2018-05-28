using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    private Texture2D _webImage;
    public void Startup() {
        Debug.Log("images starting...");
        _network = new NetworkService();
        status = ManagerStatus.Started;
        
    }

    public void GetWebImage(Action<Texture2D> callback) {
        if (_webImage == null)
        {
            StartCoroutine(_network.DownloadImage(callback));
            StartCoroutine(_network.DownloadImage((Texture2D image) => {
                _webImage = image;
                callback(_webImage);
            }));
        }
        else {
            callback(_webImage);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
