using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levels;

    public List<string> scenes;

    private void Awake()
    {
        levels = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(scenes[levelIndex]);
    }
}
