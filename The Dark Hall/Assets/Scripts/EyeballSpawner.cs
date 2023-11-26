using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballSpawner : MonoBehaviour
{

    public GameObject eyeballPrefab;
    public Transform player;
    [SerializeField] public float spawnRate = 20.0f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            SpawnEyeball();
            timer = 0;
        }
    }

    private void SpawnEyeball()
    {
        GameObject eyeballInstance = Instantiate(eyeballPrefab, transform.position, Quaternion.identity);
        eyeballInstance.GetComponent<Eyeball>().player = player;
    }
}
