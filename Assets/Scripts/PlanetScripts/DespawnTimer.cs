using UnityEngine;
using System.Collections;

public class DespawnTimer : MonoBehaviour {
  /*
  * Despawns object it is attached too after despawnTime seconds.
  */
    private float DespawnTime = 500;
    private float currentTime;

    // Use this for initialization
    void Start () {
        currentTime = Time.time;
    }

	// Update is called once per frame
	void Update () {
		if(Time.time > currentTime + DespawnTime){
			gameObject.SetActive(false);
		}
	}
}
