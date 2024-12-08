using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script para manejar el menu del juego
public class MenuController : MonoBehaviour
{
    // Carga la escena del juego
    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    // Sale del juego
    public void Salir()
    {
        Application.Quit();
    }
}
