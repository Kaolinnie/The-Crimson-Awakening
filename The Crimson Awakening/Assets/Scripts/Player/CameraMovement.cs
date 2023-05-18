using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;
    private Transform player;

    private Player _player;
    
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        _player = Player.Instance;
    }

    // Update is called once per frame
    void Update() {
        var position = player.position;
        position.y += 2;
        transform.position = position;
        
        if (!_player.canRotate) return;
        
        float hRot = Input.GetAxis("Mouse X");
        float vRot = Input.GetAxis("Mouse Y") * -1;
        Vector3 v = new Vector3(vRot * xSensitivity, hRot * ySensitivity, 0);

        transform.eulerAngles += v;


    }
}
