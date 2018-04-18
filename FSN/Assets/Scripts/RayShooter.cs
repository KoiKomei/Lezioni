using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour {
    private Camera _cam;
    public Texture mirino;
    public GameObject snipe;
    private bool sniping = false;
    private int count;
    public Text c;

	// Use this for initialization
	void Start () {
        count = 0;
        setText();
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        (snipe.GetComponent<Renderer>()).enabled = false;
	}

    void setText() {
        c.text = count.ToString();
    }

    void OnGUI()
    {
        if (!sniping)
        {
            int size = 36;
            float posX = _cam.pixelWidth / 2 - size / 2;
            float posY = _cam.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), mirino);
        }
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
                        count++;
                        setText();


                    }
                    else {
                        StartCoroutine(SphereIndicator(hit.point));
                   }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && !sniping) {
            _cam.fieldOfView = 10f;
            Mouselook senseVert = GetComponent<Mouselook>();
            senseVert.sensivityver = 1f;
            (snipe.GetComponent<Renderer>()).enabled = true;

            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            Mouselook senseHor = player.GetComponent<Mouselook>();
            senseHor.sensivityhor = 1f;
            sniping = true;
        }

        if (Input.GetMouseButtonUp(1) && sniping) {
            _cam.fieldOfView = 60f;
            Mouselook sensVert = GetComponent<Mouselook>();
            sensVert.sensivityhor = 9.0f;
            (snipe.GetComponent<Renderer>()).enabled = false;

            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            Mouselook senseHor = player.GetComponent<Mouselook>();
            senseHor.sensivityhor = 9.0f;
            sniping = false;
        
            
        }
		
	}
    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        
        yield return new WaitForSeconds(1.0f);

        Destroy(sphere);
    }

}
