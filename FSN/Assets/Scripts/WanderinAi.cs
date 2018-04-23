using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderinAi : MonoBehaviour {
    public const float basespeed = 3.0f;
    public float speed = 6.0f;
    private float obstaclerange = 5.0f;
    private bool _alive;
    [SerializeField] private GameObject fireballprefab;
    private GameObject _fireball;

	// Use this for initialization
	void Start () {
        _alive = true;
	}

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChange);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChange);
    }
    private void OnSpeedChange(float value) {
        speed = basespeed * value;
    }
    // Update is called once per frame
    void Update () {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>()) {
                    if (_fireball == null) {
                        _fireball = Instantiate(fireballprefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstaclerange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}

    public void SetAlive(bool alive) {
        _alive = alive;
    }

}
