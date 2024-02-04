using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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

    //properties (voir la doc)
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

            float nextRewardGoal = Mathf.Round(rewardsRate.Evaluate(RewardsCounter));

            Debug.Log(rewardsRate.Evaluate(RewardsCounter));
            Debug.Log("next reward : " + nextRewardGoal);



            if(_killCount == nextRewardGoal)
            {
                //pause le jeu
                Time.timeScale = 0;

                //nouveau palier de récompense
                RewardsCounter++;

                //remettre à zéro le compteur affiché à l'écran
                killCount = 0;

                //afficher l'interface de la récompense
                //transform.Find pour trouver l'enfant
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