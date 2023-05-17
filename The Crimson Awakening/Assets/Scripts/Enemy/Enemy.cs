using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float health = 50;
    private float _maxHealth;
    public GameObject healthSlider;
    public GameObject healthCanvas;

    private Slider _health;
    private Canvas _canvas;
    
    // Start is called before the first frame update
    void Start() {
        _health = healthSlider.GetComponent<Slider>();
        _canvas = healthCanvas.GetComponent<Canvas>();
        
        _canvas.renderMode = RenderMode.WorldSpace;
        _canvas.worldCamera = Camera.main;
        _health.maxValue = _maxHealth;
        _health.direction = Slider.Direction.LeftToRight;
        _health.maxValue = health;
    }

    // Update is called once per frame
    void Update() {
        _health.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
