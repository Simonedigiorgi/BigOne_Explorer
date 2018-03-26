using UnityEngine;

public class RotateEquip : MonoBehaviour {

	void Update () {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
	}
}
