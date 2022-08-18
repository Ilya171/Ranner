using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField] lvlController lvlController;
    [SerializeField] prefabManager prefabManager;
    [SerializeField] boSScript boSScript;


    public void SaveProgress()
    {
        PlayerPrefs.SetInt("Levels", lvlController.Level);
        PlayerPrefs.SetFloat("ChanceObstracles", prefabManager.chanceObsracle);
        PlayerPrefs.SetFloat("ChanceEnemy", prefabManager.chanceEnemy);
        PlayerPrefs.SetFloat("UpDistances", prefabManager.upDistance);
        PlayerPrefs.SetInt("Xp", boSScript.Xp);

    }
    public void LoadProgress()
    {
        lvlController.Level = PlayerPrefs.GetInt("Levels");
        prefabManager.chanceObsracle = PlayerPrefs.GetFloat("ChanceObstracles");
        prefabManager.chanceEnemy = PlayerPrefs.GetFloat("ChanceEnemy");
        prefabManager.upDistance = PlayerPrefs.GetFloat("UpDistances");
        boSScript.Xp = PlayerPrefs.GetInt("Xp");
    }
    private void Awake()
    {
        //SaveProgress();
       LoadProgress();
        
    }
}
