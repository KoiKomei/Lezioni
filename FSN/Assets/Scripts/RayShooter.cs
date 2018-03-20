using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _cam;
	// Use this for initialization
	void Start () {
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    void OnGUI()
    {
        int size = 12;
        float posX = _cam.pixelWidth / 2 - size / 4;
        float posY = _cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);
            Ray rag = _cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(rag, out hit)) {

                if (Physics.Raycast(rag, out hit)) {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        StartCoroutine(SphereIndicator(hit.point));
                        target.ReactToHit();

                    }
                    else {
                        StartCoroutine(SphereIndicator(hit.point));
                   }
                }
            }
        }
		
	}
    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        
        yield return new WaitForSeconds(1.0f);

        Destroy(sphere);
    }

}
