using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlController : MonoBehaviour
{
    [SerializeField] prefabManager prefabManager;
    int level = 0;

    [SerializeField] Text levelText;

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level=value;
            levelText.text = "LVL: "+Level.ToString();
            prefabManager.UpHard();
        }
    }
    private void Start()
    {
        levelText.text = "LVL: " + Level.ToString();
    }


}
