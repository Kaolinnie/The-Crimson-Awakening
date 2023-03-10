using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;
    private Transform player;
    
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        float hRot = Input.GetAxis("Mouse X");
        float vRot = Input.GetAxis("Mouse Y") * -1;
        Vector3 v = new Vector3(vRot * xSensitivity, hRot * ySensitivity, 0);

        transform.eulerAngles += v;

        var position = player.position;
        position.y += 2;
        transform.position = position;
    }
}
