using UnityEngine;
using System.Collections;

public class projMovement2D : MonoBehaviour {

	public float hSpeed;

	// Update is called once per frame
	void Update () {
		gameObject.transform.position += gameObject.transform.right * hSpeed * Time.deltaTime;
	}
}