using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("Lobby");
    }

    public void ExitGame(){
        Application.Quit(); 
    }
}
