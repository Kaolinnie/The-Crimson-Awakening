using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    

    // Write down your variables here
    
    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // void Update() {
    //     _player.AdjustHealth(-5.0f);
    //     Debug.Log("decreasing health");
    // }

}
