using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenuManager : MonoBehaviour
{
    private int countTitle = 0;

    public GameObject LevelsMenu, Credits;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelsMenu.SetActive(false);
        Credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTitle()
    {
        countTitle += 1;
        if (countTitle >= 5)
        {
            SceneManager.LoadScene("RunnerScene", LoadSceneMode.Single);
        }
    }
    
    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOneScene", LoadSceneMode.Single);
    }
    
    public void LevelTwo()
    {
        SceneManager.LoadScene("LevelTwoScene", LoadSceneMode.Single);
    }
    
    public void LevelThree()
    {
        SceneManager.LoadScene("LevelThreeScene", LoadSceneMode.Single);
    }
}
