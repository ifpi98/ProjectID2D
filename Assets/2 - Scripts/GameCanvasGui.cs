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

    string[] cardSlot;
    string finishWord;
    int requireLevelup;    

    public Button mButton0;
    public Button mButton1;
    public Button mButton2;
    public Button mButton3;
    public Button mButton4;
    public Button nTurnButton;

    public Text mButText0;
    public Text mButText1;
    public Text mButText2;
    public Text mButText3;
    public Text mButText4;
    public Text nTurnButText;
    public Text pointDisplay;
    public Text maxCombo;

    public Text RemainTurnButton0;
    public Text RemainTurnButton1;
    public Text RemainTurnButton2;
    public Text RemainTurnButton3;
    public Text RemainTurnButton4;



    //Canvas gameCanvas;


    // Use this for initialization
    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();

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

        nTurnButton = GameObject.Find("Next Turn Button").GetComponent<Button>();
        nTurnButText = nTurnButton.GetComponentInChildren<Text>();

        pointDisplay = GameObject.Find("Point Text").GetComponent<Text>();
        requireLevelup = Convert.ToInt32(mon.expLvData2[game.level + 1, 2]) - game.score;
        maxCombo = GameObject.Find("Combo Text").GetComponent<Text>();

        RemainTurnButton0 = GameObject.Find("Remain Turn Button 0").GetComponent<Text>();
        RemainTurnButton1 = GameObject.Find("Remain Turn Button 1").GetComponent<Text>();
        RemainTurnButton2 = GameObject.Find("Remain Turn Button 2").GetComponent<Text>();
        RemainTurnButton3 = GameObject.Find("Remain Turn Button 3").GetComponent<Text>();
        RemainTurnButton4 = GameObject.Find("Remain Turn Button 4").GetComponent<Text>();
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
            RemainTurnButton0.text = "남은 턴 : " + game.remainturncardslot[0];
        }
        else
        {
            RemainTurnButton0.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[1] == true && game.remainturncardslot[1] != 0)
        {
            RemainTurnButton1.text = "남은 턴 : " + game.remainturncardslot[1];
        }
        else
        {
            RemainTurnButton1.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[2] == true && game.remainturncardslot[2] != 0)
        {
            RemainTurnButton2.text = "남은 턴 : " + game.remainturncardslot[2];
        }
        else
        {
            RemainTurnButton2.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[3] == true && game.remainturncardslot[3] != 0)
        {
            RemainTurnButton3.text = "남은 턴 : " + game.remainturncardslot[3];
        }
        else
        {
            RemainTurnButton3.text = "다음 턴 교체 예정";
        }
        if (game.checkremainTurncardslot[4] == true && game.remainturncardslot[4] != 0)
        {
            RemainTurnButton4.text = "남은 턴 : " + game.remainturncardslot[4];
        }
        else
        {
            RemainTurnButton4.text = "다음 턴 교체 예정";
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



