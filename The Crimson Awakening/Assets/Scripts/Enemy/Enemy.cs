using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public Enemy(float health = 50) {
        this.health = health;
        _maxHealth = health;
    }

    public float health;
    private float _maxHealth;
    public Slider _healthSlider;
    public Canvas _healthCanvas;
    
    // Start is called before the first frame update
    void Start() {
        _healthCanvas.renderMode = RenderMode.WorldSpace;
        _healthCanvas.worldCamera = Camera.main;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.direction = Slider.Direction.LeftToRight;
        _healthSlider.maxValue = health;
    }

    // Update is called once per frame
    void Update() {
        _healthSlider.value = health;
        if (health <= 0) {
            Destroy(this);
        }
    }
}
