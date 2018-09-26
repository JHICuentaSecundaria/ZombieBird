using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] Transform prefabTuberia;

	void Start () {
        InvokeRepeating ("GeneratePipe", 0, 1.3f);
	}

    void GeneratePipe ()
    {
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
    }
}
