using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiple : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] _enemies;
    private int count;

	// Use this for initialization
	void Start () {
        count = 5;
        _enemies = new GameObject[count];
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] == null)
            {
                float nearbyX = Random.Range(-15, 15);
                float nearbyZ = Random.Range(-15, 15);
                _enemies[i] = Instantiate(enemyPrefab) as GameObject; //instatiate lo fa generico e devi dargli un tipo preciso
                _enemies[i].transform.position = new Vector3(nearbyX, 1, nearbyZ);
                float angle = Random.Range(0, 360f);
                _enemies[i].transform.Rotate(0, angle, 0);

            }

        }
    }
}
