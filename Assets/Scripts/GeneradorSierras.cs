using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorSierras : MonoBehaviour
{
    public GameObject obstaculo;
    public float velCreacion = 2f;
    float min = -2f;
    float max = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float random = Random.Range(min, max);
        Vector2 spawnPos = new Vector2(random, transform.position.y);
        Instantiate(obstaculo, spawnPos, Quaternion.identity);

    }

    void StartSpawning() 
    {
        InvokeRepeating("Spawn", 1f, velCreacion);
        
    }

    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }

}
