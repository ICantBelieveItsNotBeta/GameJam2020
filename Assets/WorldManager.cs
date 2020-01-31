using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager worldManager;
    public static LevelManager levelManager;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        worldManager = this;
        levelManager = GetComponent<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame()
    {
        Debug.Log("YOU WIN!");
        levelManager.LoadLevel(0);
    }
}
