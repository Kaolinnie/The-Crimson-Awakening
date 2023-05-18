using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopScript : MonoBehaviour {
    public GameObject canvas;

    private Canvas _shopUI;
    private Player _player;

    private void Start() {
        _shopUI = canvas.GetComponent<Canvas>();
        _player = Player.Instance;
    }

    private void OnTriggerEnter(Collider col) {
        if (!col.gameObject.CompareTag("Player")) return;
        // print("Press B to View Shop");

        _player.canRotate = false;
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _shopUI.gameObject.SetActive(true);

        // if (Input.GetButtonDown("B")) {
        //     shop.SetActive(true);
        // }
    }

    private void OnTriggerExit(Collider col) {
        if (!col.gameObject.CompareTag("Player")) return;
        _player.canRotate = true;
        _shopUI.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
