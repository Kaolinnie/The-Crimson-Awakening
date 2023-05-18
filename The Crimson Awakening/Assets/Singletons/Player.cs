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
    public int mon;
    private float _maxPlayerHealth = 200;
    private Animator animator;
    public bool isDead;
    public bool canRotate;
    
    
    private CharacterController _cc;

    public float damage = 20.0f;

    private static readonly int IsDead = Animator.StringToHash("Die");


    // Start is called before the first frame update
    void Start()
    {
        mon = 1000;
        animator = gameObject.GetComponent<Animator>();
        health = MaxPlayerHealth;
        _player = GameObject.FindGameObjectWithTag("Player");
        _cc = _player.GetComponent<CharacterController>();
        animator = _player.GetComponent<Animator>();
        _healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        _healthBar.maxValue = MaxPlayerHealth;
        _healthBar.direction = Slider.Direction.LeftToRight;
        isDead = false;
        canRotate = true;
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
            // var center = _cc.center;
            // center = new Vector3(center.x,center.y+1,center.z);
            // _cc.center = center;
            animator.SetTrigger(IsDead);
        }
        return health;
    }

    public float HeathItem(float value) {
        health += value;
        if (health <= 0) {
            health = 0;
            isDead = true;
            // var center = _cc.center;
            // center = new Vector3(center.x,center.y+1,center.z);
            // _cc.center = center;
            animator.SetTrigger(IsDead);
        }
        return health;
    }

    public float DamageItem(float value) {
        damage += value;
        if (damage <= 0) {
            damage = 0;
        }
        return damage;
    }

    public int AdjustMon(int value){
        if(mon + value < 0){
            return mon;
        }
        mon += value;
        return mon;
    }

    private void Update() {
        _healthBar.value = health;
    }
}
