using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance { get; private set; }
    public int _level = 2;
    public bool _inLobby;
    
    private void Awake()
    {
        Instance = this;
        _inLobby = SceneManager.GetActiveScene().name=="Scenes/Lobby";
        Debug.Log(SceneManager.GetActiveScene().name=="Scenes/Lobby");
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            if (_inLobby) {
                _inLobby = false;
                SceneManager.LoadScene(_level++);
            }
            else {
                _inLobby = true;
                SceneManager.LoadScene("Scenes/Lobby");
            }
        }
    }
}
