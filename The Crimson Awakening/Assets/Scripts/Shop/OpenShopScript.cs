using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopScript : MonoBehaviour
{
    private GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.Find("ShopPanel");
        shop.SetActive(false);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            // print("Press B to View Shop");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            shop.SetActive(true);

            // if (Input.GetButtonDown("B")) {
            //     shop.SetActive(true);
            // }
        }
    }

    private void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            shop.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
