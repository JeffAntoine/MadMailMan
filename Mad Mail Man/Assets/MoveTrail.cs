using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = -1;

	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed/3);
        Destroy(gameObject, 1);
	}
}
