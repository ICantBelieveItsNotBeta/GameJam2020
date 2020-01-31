using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<string> scenes;

    int currentLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Restart")) RestartLevel();
    }

    public void LoadLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        SceneManager.LoadScene(scenes[levelIndex]);
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevel);
    }

    public void WinLevel()
    {
        int newLevelIndex = currentLevel + 1;

        if (scenes.Count > newLevelIndex)
        {
            LoadLevel(newLevelIndex);
        }
        else WorldManager.worldManager.WinGame();        
    }
}
