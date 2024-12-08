using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script genera sierras en el escenario en tiempo real.
public class GeneradorSierras : MonoBehaviour
{
    // La sierra
    public GameObject obstaculo;

    // Velocidad en la que se crean las sierras en segundos, y el rango en el que se generan en el eje x.
    public float velCreacion = 2f;
    float min = -2f;
    float max = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawning(); // Comienza a generar sierras al iniciar el juego
    }

    // Método para generar una nueva sierra en el escenario.
    void Spawn()
    {
        float random = Random.Range(min, max); // Genera un valor aleatorio en el rango
        Vector2 spawnPos = new Vector2(random, transform.position.y); // Genera una posición aleatoria en el eje x
        Instantiate(obstaculo, spawnPos, Quaternion.identity); // Instancia la sierra

    }

    // Metodo para iniciar la generacion de sierras
    void StartSpawning() 
    {
        InvokeRepeating("Spawn", 1f, velCreacion); 
        
    }

    // Metodo para detener la generacion de sierras
    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }

}
