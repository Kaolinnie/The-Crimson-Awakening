using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float health = 50;
    private float _maxHealth;
    public Slider healthSlider;
    public Canvas healthCanvas;
    
    // Start is called before the first frame update
    void Start() {
        healthCanvas.renderMode = RenderMode.WorldSpace;
        healthCanvas.worldCamera = Camera.main;
        healthSlider.maxValue = _maxHealth;
        healthSlider.direction = Slider.Direction.LeftToRight;
        healthSlider.maxValue = health;
    }

    // Update is called once per frame
    void Update() {
        healthSlider.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
