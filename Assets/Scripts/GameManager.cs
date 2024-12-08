using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase que maneja todas las funcionalidades del juego, va asociada a un objeto vacío ya que este no se destruye en la ejecución del juego.
public class GameManager : MonoBehaviour
{
    // Instancia de la clase
    public static GameManager Instance;

    // Determina si se ha terminado el juego
    bool gameOver=false;

    // Texto que muestra el marcador del juego
    public TMP_Text marcador;

    // Puntuación del juego actual
    private int puntuacion=0;

    // Panel
    public GameObject panel;

    // Sonidos
    [SerializeField] AudioClip sonidoTocaSuelo;
    [SerializeField] AudioClip sonidoTocaJugador;
    private AudioSource audioSource;

    // Vidas
    public int vidas;

    // Inicializa variables antes de que el juego inicie
    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        vidas = 3; // Número de vidas, en este caso 3
    }

    // Función que se llama cuando se termina el juego, activa el panel y detiene la generación de sierras
    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("GeneradorSierras").GetComponent<GeneradorSierras>().StopSpawning();
        marcador.text = "";
        panel.SetActive(true);
    }


    // Función que incrementa la puntuación
    public void IncrementScore()
    {
        if (!gameOver) {
            puntuacion++;
            marcador.text = puntuacion.ToString();
        }
    }

    // Funcion que reproduce el sonido de explosion cuando una sierra toca al jugador. Si pierde la ultima vida acaba el juego.
    public void ReproducirSonidoTocaJugador(Collider2D collision)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sonidoTocaJugador);

        vidas--;
        if (vidas <= 0)
        {
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    // Funcion que reproduce el sonido de puntuacion cuando el jugador esquiva la sierra y toca el suelo
    public void ReproducirSonidoTocaSuelo()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sonidoTocaSuelo);
    }

    // Funcion que reinicia el juego al pulsar el boton de reiniciar
    public void Restart()
    {
        SceneManager.LoadScene("Juego");
    }

    // Funcion que vuelve al menu al pulsar el boton de menu
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
