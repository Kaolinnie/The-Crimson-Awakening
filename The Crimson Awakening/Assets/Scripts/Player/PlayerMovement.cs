using UnityEngine;
// link to video that helped me with this script
// https://www.youtube.com/watch?v=T9IIIKdsV4Y
public class PlayerMovement : MonoBehaviour {
    private GameObject player;
    private CharacterController controller;
    private Animator animator;
    private Camera camera;
    
    private float gravity = -9.81f;
    private int runSpeed = 8;
    private int walkSpeed = 5;
    private static readonly int CharacterSpeed = Animator.StringToHash("CharacterSpeed");
    private float turnSpeed = 15f;

    private Vector3 targetDirection;
    private Quaternion freeRotation;
    private Vector3 moveDirection;

    private int charSpeed;
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    
    private Player _player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");
        controller = player.gameObject.GetComponent<CharacterController>();
        animator = player.gameObject.GetComponent<Animator>();
        camera = Camera.main;
        
        _player = Player.Instance;
    }

    // Update is called once per frame
    void Update() {
        if (_player.isDead) return;
        
        if(Input.GetButtonDown("Fire1")) Attack();
        
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float move = Mathf.Abs(hMove) + Mathf.Abs(vMove);

        var forward = player.transform.TransformDirection(Vector3.forward);
        
        moveDirection = forward * move;
        
        moveDirection.Normalize();

        charSpeed = moveDirection.magnitude > 0 ? GetMovementSpeed() : 0;
        animator.SetInteger(CharacterSpeed, charSpeed);

        moveDirection *= charSpeed;
        
        moveDirection.y = controller.isGrounded ? 0 : gravity;

        UpdateTargetDirection(hMove,vMove);

        if (new Vector2(hMove,vMove) != Vector2.zero && targetDirection.magnitude > 0.1f) { 
            Vector3 lookDir = targetDirection.normalized; 
            var freeRot = Quaternion.LookRotation(lookDir, player.transform.up);
            var differenceRot = freeRot.eulerAngles.y - player.transform.eulerAngles.y;
            var eulerY = player.transform.eulerAngles.y;

            if (differenceRot < 0 || differenceRot > 0) eulerY = freeRot.eulerAngles.y;            

            var euler = new Vector3(0, eulerY, 0);
            
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(euler), turnSpeed * Time.deltaTime);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void UpdateTargetDirection(float hMove, float vMove) {
        var forward = camera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        
        var right = camera.transform.TransformDirection(Vector3.right);
        targetDirection = hMove * right + vMove * forward;
    }

    private void Attack() {
        animator.SetTrigger(Attack1);
    }
    private int GetMovementSpeed() => Input.GetButton("Fire3") ? runSpeed : walkSpeed;
}
