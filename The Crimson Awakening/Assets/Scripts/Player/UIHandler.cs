using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    private Player _player;
    public GameObject 
        monText, 
        healthSlider,
        damageText;

    private Slider _health;
    private TextMeshProUGUI _mon, _damage;
    
    // Start is called before the first frame update
    void Start() {
        _player = Player.Instance;

        _mon = monText.GetComponent<TextMeshProUGUI>();
        _damage = damageText.GetComponent<TextMeshProUGUI>();
        
        _health = healthSlider.GetComponent<Slider>();
        _health.maxValue = _player.MaxPlayerHealth;
        _health.direction = Slider.Direction.LeftToRight;
    }

    // Update is called once per frame
    void Update() {
        _mon.text = $"{_player.mon}";
        _damage.text = $"{_player.damage}";
        _health.maxValue = _player.MaxPlayerHealth;
        _health.value = _player.health;
    }
}
