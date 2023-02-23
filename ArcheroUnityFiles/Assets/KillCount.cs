using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "KillCount", menuName = "ScriptableObjects/KillCount", order = 1)]
public class KillCount : ScriptableObject
{
    [SerializeField]
    private GameObject      killcountTextGameobjectInterface;
    [SerializeField]
    private TextMeshProUGUI killcountTextGUI;

    //test ref
    public GameObject PlayerRef;

    [SerializeField]
    AnimationCurve rewardsRate;

    public byte RewardsCounter;

    public bool RefFound;

    private int _killCount;
    public int killCount {
        get 
        {
            return _killCount;
        } 
        set
        {
            if (!RefFound){
                killcountTextGameobjectInterface = GameObject.Find("KillCountUI");
                killcountTextGUI = killcountTextGameobjectInterface.GetComponent<TextMeshProUGUI>();
                RefFound = true;
            }

            killcountTextGUI.text = value.ToString();
            _killCount = value;

            ///// pour les récompenses /////
            ///

            float nextRewardGoal = Mathf.Ceil(rewardsRate.Evaluate(RewardsCounter) / 2);

            Debug.Log("next reward : " + nextRewardGoal);

            if(_killCount == nextRewardGoal)
            {
                Time.timeScale = 0;
                RewardsCounter++;
                killCount = 0;
                GameObject.Find("UI").transform.Find("BonusPanel").gameObject.SetActive(true);
            }
        }
    }



    void OnEnable()
    {
        //initialization
        killCount = 0;
        RewardsCounter = 0;
        RefFound = false;

        /*
         * weird ? It's not working
         */
        //killcountTextGameobjectInterface = GameObject.Find("KillCountUI");
        //Debug.Log(killcountTextGameobjectInterface);
        //killcountTextGUI = killcountTextGameobjectInterface.GetComponent<TextMeshProUGUI>();

        PlayerRef = GameObject.Find("Player");
    }

    void Awake()
    {
        Debug.Log("Awake in KillCount");
    }
}