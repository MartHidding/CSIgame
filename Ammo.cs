using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

    public float timeLeft = 50;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Kill();
        }
    }

    void Kill() {
        Destroy(gameObject);
    }
	

}
