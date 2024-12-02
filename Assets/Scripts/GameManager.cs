using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool gameOver=false;
    public TMP_Text marcador;
    private int puntuacion=0;
    public GameObject panel;
    [SerializeField] AudioClip sonidoTocaSuelo;
    [SerializeField] AudioClip sonidoTocaJugador;
    private AudioSource audioSource;
    public int vidas;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        vidas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("GeneradorSierras").GetComponent<GeneradorSierras>().StopSpawning();
        marcador.text = "";
        panel.SetActive(true);
    }


    public void IncrementScore()
    {
        if (!gameOver) {
            puntuacion++;
            marcador.text = puntuacion.ToString();
        }
    }

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

    public void ReproducirSonidoTocaSuelo()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sonidoTocaSuelo);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
