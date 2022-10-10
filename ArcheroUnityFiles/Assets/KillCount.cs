using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "KillCount", menuName = "ScriptableObjects/KillCount", order = 1)]
public class KillCount : ScriptableObject
{
    public GameObject      killcountTextGameobjectInterface;
    public TextMeshProUGUI killcountTextGUI;

    private int _killCount;
    public int killCount {
        get 
        {
            return _killCount;
        } 
        set
        {
            killcountTextGameobjectInterface = GameObject.Find("KillCountUI");
            killcountTextGUI = killcountTextGameobjectInterface.GetComponent<TextMeshProUGUI>();
            killcountTextGUI.text = value.ToString();
            _killCount = value;
        }
    }

    private void OnEnable()
    {
        //initialization
        killCount = 0;
    }
}
