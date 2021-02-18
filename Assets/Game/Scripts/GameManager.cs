using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;

    public GameObject player;

    private UIManager _uiManager;

    private GameObject _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(player, Vector3.zero, quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
            }
        }
    }
}
