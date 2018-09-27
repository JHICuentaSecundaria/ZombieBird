using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField] int speed = 3;
    [SerializeField] float limiteInferior = -1.75f;
    [SerializeField] float limiteSuperior = 1.55f;
    [SerializeField] float distanciaDestruccion = -8.5f;

    void Start () {
        float factorPosicion = Random.Range(limiteInferior, limiteSuperior);
        transform.position = new Vector3 (transform.position.x, transform.position.y - factorPosicion, transform.position.z);
    }
	
	void Update () {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x <= -distanciaDestruccion)
            {
                Destroy(gameObject, 0);
            }
        }
    }
}
