using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject LevelSelectMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        WorldManager.levelManager.LoadLevel(1);
    }

    public void LevelSelectButton()
    {
        LevelSelectMenu.SetActive(true);
    }

    public void CloseLevelSelectButton()
    {
        LevelSelectMenu.SetActive(false);
    }

    public void SelectLevelButton(int levelIndex)
    {
        WorldManager.levelManager.LoadLevel(levelIndex);
    }

}
