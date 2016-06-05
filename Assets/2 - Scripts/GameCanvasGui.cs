using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameCanvasGui : MonoBehaviour
{
    Monster mon;
    Game game;
    DataIni DI;
    
    public GameObject[] madeSlot;
    public GameObject[] skillButtonObject;
    
    string[] cardSlot;
    string finishWord;
    int requireLevelup;

    public Button[] mButton;
    public Text[] mButText;
    public Text[] RemainTurnText;

    public Button[] madeSlotButton;
    public Text[] madeSlotButtonText;

    public Button[] skillButton;
    public Text[] skillButtonText;

    public Button nTurnButton;
    public Text nTurnButText;

    public Text pointDisplay;
    public Text maxCombo;
    public Text historyDisplay;
        

    // Use this for initialization
    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();

        madeSlot = new GameObject[6]; 
                        
        madeSlot[0] = GameObject.Find("Made Slot Button 0");
        madeSlot[1] = GameObject.Find("Made Slot Button 1");
        madeSlot[2] = GameObject.Find("Made Slot Button 2");
        madeSlot[3] = GameObject.Find("Made Slot Button 3");
        madeSlot[4] = GameObject.Find("Made Slot Button 4");
        madeSlot[5] = GameObject.Find("Made Slot Button 5");

        skillButtonObject = new GameObject[5];

        skillButtonObject[0] = GameObject.Find("Skill Button 0");
        skillButtonObject[1] = GameObject.Find("Skill Button 1");
        skillButtonObject[2] = GameObject.Find("Skill Button 2");
        skillButtonObject[3] = GameObject.Find("Skill Button 3");
        skillButtonObject[4] = GameObject.Find("Skill Button 4");

        finishWord = "";
        cardSlot = new string[5];

        mButton = new Button[5];
        mButText = new Text[5];

        mButton[0] = GameObject.Find("Member Button 0").GetComponent<Button>();        
        mButton[1] = GameObject.Find("Member Button 1").GetComponent<Button>();        
        mButton[2] = GameObject.Find("Member Button 2").GetComponent<Button>();        
        mButton[3] = GameObject.Find("Member Button 3").GetComponent<Button>();        
        mButton[4] = GameObject.Find("Member Button 4").GetComponent<Button>();        

        for (int i = 0; i < 5; i++)
        {
            mButText[i] = mButton[i].GetComponentInChildren<Text>();
        }

        madeSlotButton = new Button[6];
        madeSlotButtonText = new Text[6];

        for (int i = 0; i < 6; i++)
        {
            madeSlotButton[i] = madeSlot[i].GetComponent<Button>();
            madeSlotButtonText[i] = madeSlotButton[i].GetComponentInChildren<Text>();
        }

        skillButton = new Button[5];
        skillButtonText = new Text[5];

        for (int i = 0; i < 5; i++)
        {
            skillButton[i] = skillButtonObject[i].GetComponent<Button>();
            skillButtonText[i] = skillButton[i].GetComponentInChildren<Text>();
        }
        
        nTurnButton = GameObject.Find("Next Turn Button").GetComponent<Button>();
        nTurnButText = nTurnButton.GetComponentInChildren<Text>();

        pointDisplay = GameObject.Find("Point Text").GetComponent<Text>();
        requireLevelup = Convert.ToInt32(mon.expLvData2[game.level + 1, 2]) - game.score;
        maxCombo = GameObject.Find("Combo Text").GetComponent<Text>();

        RemainTurnText = new Text[5];
        
        RemainTurnText[0] = GameObject.Find("Remain Turn Text 0").GetComponent<Text>();
        RemainTurnText[1] = GameObject.Find("Remain Turn Text 1").GetComponent<Text>();
        RemainTurnText[2] = GameObject.Find("Remain Turn Text 2").GetComponent<Text>();
        RemainTurnText[3] = GameObject.Find("Remain Turn Text 3").GetComponent<Text>();
        RemainTurnText[4] = GameObject.Find("Remain Turn Text 4").GetComponent<Text>();

        //historyDisplay = GameObject.Find("Make History Text").GetComponent<Text>();
        
    }

    void Update()
    {

        TextRefresh();      
        
    }

    void TextRefresh()
    {

        for (int i = 0; i < 5; i++)
        {
            cardSlot[i] = mon.charData2[game.cardSlot[i], 1] + "\n(" + mon.charData2[game.cardSlot[i], 3] + ")";
            mButText[i].text = cardSlot[i];
        }

        pointDisplay.text = "SP : " + Convert.ToInt32(game.skillPoint) + "\n Score : " + game.score + " (" + requireLevelup + ") " + "\n Level : " + game.level + "\n MaxCombo : " + game.maxCombo + "\n TotalTurn : " + game.totalTurn;

        for (int i = 0; i < 5; i++)
        {
            if (game.checkremainTurncardslot[i] == true && game.remainturncardslot[i] != 0)
            {
                RemainTurnText[i].text = "남은 턴 : " + game.remainturncardslot[i];
            }
            else
            {
                RemainTurnText[i].text = "다음 턴 교체 예정";
            }
        }
        

        if (game.combocount != 0)
        {
            maxCombo.text = "ComboCount : " + game.combocount + " " + finishWord;
        }
        else
        {
            maxCombo.text = "";
        }
                
        if (game.madeSlotList.Count == 0)
        {
            finishWord = "Done!";
        }
        else
        {
            finishWord = "";
        }

        //historyDisplay.text = "Duo : " + game.makecounthistory[2] + "\nTrio : " + game.makecounthistory[3] +"\nQuartet : " + game.makecounthistory[4] + "\nQuintet : " + game.makecounthistory[5];

    }


    

}



