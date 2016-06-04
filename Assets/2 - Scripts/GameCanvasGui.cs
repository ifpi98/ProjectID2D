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

    public GameObject madeSlot0;
    public GameObject madeSlot1;
    public GameObject madeSlot2;
    public GameObject madeSlot3;
    public GameObject madeSlot4;
    public GameObject madeSlot5;
    
    string[] cardSlot;
    string finishWord;
    int requireLevelup;    

    public Button mButton0;
    public Button mButton1;
    public Button mButton2;
    public Button mButton3;
    public Button mButton4;
    public Button nTurnButton;

    public Button madeSlotButton0;
    public Button madeSlotButton1;
    public Button madeSlotButton2;
    public Button madeSlotButton3;
    public Button madeSlotButton4;
    public Button madeSlotButton5;

    public Text mButText0;
    public Text mButText1;
    public Text mButText2;
    public Text mButText3;
    public Text mButText4;
    public Text nTurnButText;
    public Text pointDisplay;
    public Text maxCombo;

    public Text RemainTurnText0;
    public Text RemainTurnText1;
    public Text RemainTurnText2;
    public Text RemainTurnText3;
    public Text RemainTurnText4;

    public Text madeSlotButtonText0;
    public Text madeSlotButtonText1;
    public Text madeSlotButtonText2;
    public Text madeSlotButtonText3;
    public Text madeSlotButtonText4;
    public Text madeSlotButtonText5;
    public Text madeSlotButtonText6;
    

    //Canvas gameCanvas;


    // Use this for initialization
    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();

        madeSlot0 = GameObject.Find("Made Slot Button 0");
        madeSlot1 = GameObject.Find("Made Slot Button 1");
        madeSlot2 = GameObject.Find("Made Slot Button 2");
        madeSlot3 = GameObject.Find("Made Slot Button 3");
        madeSlot4 = GameObject.Find("Made Slot Button 4");
        madeSlot5 = GameObject.Find("Made Slot Button 5");
        
        finishWord = "";
        cardSlot = new string[5];

        mButton0 = GameObject.Find("Member Button 0").GetComponent<Button>();
        mButText0 = mButton0.GetComponentInChildren<Text>();
        mButton1 = GameObject.Find("Member Button 1").GetComponent<Button>();
        mButText1 = mButton1.GetComponentInChildren<Text>();
        mButton2 = GameObject.Find("Member Button 2").GetComponent<Button>();
        mButText2 = mButton2.GetComponentInChildren<Text>();
        mButton3 = GameObject.Find("Member Button 3").GetComponent<Button>();
        mButText3 = mButton3.GetComponentInChildren<Text>();
        mButton4 = GameObject.Find("Member Button 4").GetComponent<Button>();
        mButText4 = mButton4.GetComponentInChildren<Text>();

        madeSlotButton0 = madeSlot0.GetComponent<Button>();
        madeSlotButtonText0 = madeSlotButton0.GetComponentInChildren<Text>();
        madeSlotButton1 = madeSlot1.GetComponent<Button>();
        madeSlotButtonText1 = madeSlotButton1.GetComponentInChildren<Text>();
        madeSlotButton2 = madeSlot2.GetComponent<Button>();
        madeSlotButtonText2 = madeSlotButton2.GetComponentInChildren<Text>();
        madeSlotButton3 = madeSlot3.GetComponent<Button>();
        madeSlotButtonText3 = madeSlotButton3.GetComponentInChildren<Text>();
        madeSlotButton4 = madeSlot4.GetComponent<Button>();
        madeSlotButtonText4 = madeSlotButton4.GetComponentInChildren<Text>();
        madeSlotButton5 = madeSlot5.GetComponent<Button>();
        madeSlotButtonText5 = madeSlotButton5.GetComponentInChildren<Text>();
        
        nTurnButton = GameObject.Find("Next Turn Button").GetComponent<Button>();
        nTurnButText = nTurnButton.GetComponentInChildren<Text>();

        pointDisplay = GameObject.Find("Point Text").GetComponent<Text>();
        requireLevelup = Convert.ToInt32(mon.expLvData2[game.level + 1, 2]) - game.score;
        maxCombo = GameObject.Find("Combo Text").GetComponent<Text>();

        RemainTurnText0 = GameObject.Find("Remain Turn Text 0").GetComponent<Text>();
        RemainTurnText1 = GameObject.Find("Remain Turn Text 1").GetComponent<Text>();
        RemainTurnText2 = GameObject.Find("Remain Turn Text 2").GetComponent<Text>();
        RemainTurnText3 = GameObject.Find("Remain Turn Text 3").GetComponent<Text>();
        RemainTurnText4 = GameObject.Find("Remain Turn Text 4").GetComponent<Text>();

        
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
        }

        mButText0.text = cardSlot[0];
        mButText1.text = cardSlot[1];
        mButText2.text = cardSlot[2];
        mButText3.text = cardSlot[3];
        mButText4.text = cardSlot[4];

        pointDisplay.text = "SP : " + Convert.ToInt32(game.skillPoint) + "\n Score : " + game.score + " (" + requireLevelup + ") " + "\n Level : " + game.level + "\n MaxCombo : " + game.maxCombo + "\n TotalTurn : " + game.totalTurn;


        if (game.checkremainTurncardslot[0] == true && game.remainturncardslot[0] != 0)
        {
            RemainTurnText0.text = "남은 턴 : " + game.remainturncardslot[0];
        }
        else
        {
            RemainTurnText0.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[1] == true && game.remainturncardslot[1] != 0)
        {
            RemainTurnText1.text = "남은 턴 : " + game.remainturncardslot[1];
        }
        else
        {
            RemainTurnText1.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[2] == true && game.remainturncardslot[2] != 0)
        {
            RemainTurnText2.text = "남은 턴 : " + game.remainturncardslot[2];
        }
        else
        {
            RemainTurnText2.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[3] == true && game.remainturncardslot[3] != 0)
        {
            RemainTurnText3.text = "남은 턴 : " + game.remainturncardslot[3];
        }
        else
        {
            RemainTurnText3.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[4] == true && game.remainturncardslot[4] != 0)
        {
            RemainTurnText4.text = "남은 턴 : " + game.remainturncardslot[4];
        }
        else
        {
            RemainTurnText4.text = "다음 턴 교체 예정";
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

    }


    

}



