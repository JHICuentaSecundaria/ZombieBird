using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [Header("Game Objects generados")]
    [SerializeField] Transform prefabTuberia;
    [Header("Tiempo de generacion")]
    [SerializeField] float ratioGeneracionTuberias = 1.3f;

    AudioSource sonidoEmpezarPartida;

	void Start () {
        sonidoEmpezarPartida = GetComponent<AudioSource>();
        sonidoEmpezarPartida.Play();
        InvokeRepeating ("GeneratePipe", 0, ratioGeneracionTuberias);
	}

    void GeneratePipe ()
    {
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
    }
}
