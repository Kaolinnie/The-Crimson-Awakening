using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    private GameObject _player;
    
    public float health;
    private Slider _healthBar;
    private float _maxPlayerHealth = 200;
    private Animator animator;
    public bool isDead;

    private static readonly int IsDead = Animator.StringToHash("Die");


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        health = MaxPlayerHealth;
        _player = GameObject.FindGameObjectWithTag("Player");
        animator = _player.GetComponent<Animator>();
        _healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        _healthBar.maxValue = MaxPlayerHealth;
        _healthBar.direction = Slider.Direction.LeftToRight;
        isDead = false;
    }

    public float Health {
        get { return health; }
    }

    public float MaxPlayerHealth {
        get { return _maxPlayerHealth; }
        set { _maxPlayerHealth = value; }
    }

    public float AdjustHealth(float value) {
        health += value * Time.deltaTime;
        if (health <= 0) {
            health = 0;
            isDead = true;
            animator.SetTrigger(IsDead);
        }
        return health;
    }

    private void Update() {
        _healthBar.value = health;
        AdjustHealth(-20.0f);
    }
}
