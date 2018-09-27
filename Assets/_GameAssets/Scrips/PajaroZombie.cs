using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PajaroZombie : MonoBehaviour {

    [SerializeField] float fuerza = 30.0f;
    [SerializeField] Text puntuacion;
    [SerializeField] ParticleSystem prefabExplosion;
    [SerializeField] AudioSource sonidoExplosion;

    AudioSource sumarPuntos;
    Rigidbody rb;
    int puntos = 0;

	void Start ()
    {
        sumarPuntos = GetComponent<AudioSource>();
        GameConfig.ArrancaJuego();
        rb = GetComponent<Rigidbody>();
        ActualizarPuntuacion();
    }

    private void ActualizarPuntuacion()
    {
        puntuacion.text = "Puntuación: " + puntos.ToString();
    }

    void Update () {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        sonidoExplosion.Play();
        GameConfig.ParaJuego();
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Invoke("FinalizarPartida", 3.0f);
    }

    private void FinalizarPartida()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        sumarPuntos.Play();
        puntos++;
        ActualizarPuntuacion();
    }
}
