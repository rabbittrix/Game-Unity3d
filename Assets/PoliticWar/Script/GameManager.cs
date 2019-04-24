using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public bool gameOver = true;
    public GameObject player;
    private UIManager _uiManager;
    public Text scoreText;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();       

    }

    void Update()
    {
        if(gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
            }
        }
    }
}
