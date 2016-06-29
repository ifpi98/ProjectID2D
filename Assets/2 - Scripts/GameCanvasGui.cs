using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class GameCanvasGui : MonoBehaviour
{
    Monster mon;
    Game game;
    DataIni DI;

    public GameObject[] madeSlot;
    public GameObject[] skillButtonObject;

    bool checkButtonAppear;
    string[] cardSlot;
    string finishWord;
    int[] madeSlotNumber;
    int[] charDegreeNumber;


    public Button[] mButton;
    public Text[] mButText;
    public Text[] RemainTurnText;

    public Button[] madeSlotButton;
    public Text[] madeSlotButtonText;

    public Button[] skillButton;
    public Text[] skillButtonText;
    public Text skillPointText;

    public Button nTurnButton;
    public Text nTurnButText;

    public Text pointDisplay;
    public Text maxCombo;
    public Text historyDisplay;

    public Text popUpButtonMadeText;
    //public Button madeSlotGetExpDPWriteBg;
    //public Text madeSlotGetExpDPText;
    //public Button madeSlotGetSpDPWriteBg;
    //public Text madeSlotGetSpDPText;

    public Button levelUpDPBg;
    public Text levelUpDPBgText;
    public Button levelUpInfoDPBg;
    public Text levelUpInfoDPBgText;

    public Button madeSlotHistoryPopUp;
    public Text madeSlotCountText;
    public Button madeSlotInfoPopUp_CheckButtAfter;
    public CreateAnimImage createMadeSlotHistoryList;

    public Button charDegreeInfoPopUp;
    public Button charDegreeInfoPopUp_CheckButtAfter;
    public CreateAnimImage createCharDegreeList;

    public Button drawCardPopUp;



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

        skillPointText = GameObject.Find("SkillPointText").GetComponent<Text>();

        nTurnButton = GameObject.Find("Next Turn Button").GetComponent<Button>();
        nTurnButText = nTurnButton.GetComponentInChildren<Text>();

        pointDisplay = GameObject.Find("Point Text").GetComponent<Text>();
        maxCombo = GameObject.Find("Combo Text").GetComponent<Text>();

        RemainTurnText = new Text[5];

        RemainTurnText[0] = GameObject.Find("Remain Turn Text 0").GetComponent<Text>();
        RemainTurnText[1] = GameObject.Find("Remain Turn Text 1").GetComponent<Text>();
        RemainTurnText[2] = GameObject.Find("Remain Turn Text 2").GetComponent<Text>();
        RemainTurnText[3] = GameObject.Find("Remain Turn Text 3").GetComponent<Text>();
        RemainTurnText[4] = GameObject.Find("Remain Turn Text 4").GetComponent<Text>();

        popUpButtonMadeText = GameObject.Find("PopUpButtonMadeText").GetComponent<Text>();
        //madeSlotGetExpDPWriteBg = GameObject.Find("MadeSlotGetExpDPWriteBg").GetComponent<Button>();
        //madeSlotGetExpDPText = madeSlotGetExpDPWriteBg.GetComponentInChildren<Text>();
        //madeSlotGetSpDPWriteBg = GameObject.Find("MadeSlotGetSpDPWriteBg").GetComponent<Button>();
        //madeSlotGetSpDPText = madeSlotGetSpDPWriteBg.GetComponentInChildren<Text>();

        levelUpDPBg = GameObject.Find("LevelUpDPBg").GetComponent<Button>();
        levelUpDPBgText = levelUpDPBg.GetComponentInChildren<Text>();
        levelUpInfoDPBg = GameObject.Find("LevelUpInfoDPBg").GetComponent<Button>();
        levelUpInfoDPBgText = levelUpInfoDPBg.GetComponentInChildren<Text>();

        madeSlotHistoryPopUp = GameObject.Find("MadeSlotInfoPopUp_CheckButt").GetComponent<Button>();
        madeSlotCountText = madeSlotHistoryPopUp.GetComponentInChildren<Text>();
        madeSlotInfoPopUp_CheckButtAfter = GameObject.Find("MadeSlotInfoPopUp_CheckButtAfter").GetComponent<Button>();
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        createMadeSlotHistoryList = GameObject.Find("HistroyListCreateAnimImage").GetComponent<CreateAnimImage>();

        //historyDisplay = GameObject.Find("Make History Text").GetComponent<Text>();

        charDegreeInfoPopUp = GameObject.Find("CharDegreeInfoPopUp_CheckButt").GetComponent<Button>();
        charDegreeInfoPopUp_CheckButtAfter = GameObject.Find("CharDegreeInfoPopUp_CheckButtAfter").GetComponent<Button>();
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        createCharDegreeList = GameObject.Find("CharDegreeListCreateAnimImage").GetComponent<CreateAnimImage>();

        drawCardPopUp = GameObject.Find("DrawCardPopUp_CheckButt").GetComponent<Button>(); 

    }
    
    void WriteMadeSlot()
    {
        for (int i = 0; i < game.madeSlotCount; i++)
        {
            string slotname = "MadeSlotList" + i;
            GameObject writeGO;
            writeGO = GameObject.Find(slotname);            

            StringBuilder str = new StringBuilder();            
            int unitcount = Convert.ToInt16(mon.unitData2[madeSlotNumber[i], 14]);

            str.Append("유닛명 : '" + mon.unitData2[madeSlotNumber[i], 1] + "' (" + madeSlotNumber[i] + ")"  );
            str.Append("\n멤버 : ");

            for (int y = 0; y < unitcount; y++)
            {
                str.Append(mon.charData2[Convert.ToInt16(mon.unitData2[madeSlotNumber[i], y + 4]), 1]);

                if (y < unitcount - 1)
                {
                    str.Append(", ");
                }
            }            

            writeGO.GetComponentInChildren<Text>().text = str.ToString();
            //DestroyImmediate(writeGO);
        }

    }

    void WriteCharDegreeList()
    {
        for (int i = 0; i < game.countCharThatHaveDegree; i++)
        {
            string slotname = "CharDegreeList" + i;
            GameObject writeGO;
            writeGO = GameObject.Find(slotname);

            StringBuilder str = new StringBuilder();
            //int unitcount = Convert.ToInt16(mon.unitData2[madeSlotNumber[i], 14]);

            str.Append("이름 : " + mon.charData2[charDegreeNumber[i], 1]);
            str.Append("\n친애도 : " + game.charDearDegree[charDegreeNumber[i]]);                
            str.Append("\n카드 등급 : " + mon.cardRankData2[game.charCardRank[charDegreeNumber[i]] + 1, 1]);
            str.Append(" (최대 친애도 : " + mon.cardRankData2[game.charCardRank[charDegreeNumber[i]] + 1, 2] + ")");
            //str.Append("\n멤버 : ");

            //for (int y = 0; y < unitcount; y++)
            //{
            //    str.Append(mon.charData2[Convert.ToInt16(mon.unitData2[madeSlotNumber[i], y + 4]), 1]);

            //    if (y < unitcount - 1)
            //    {
            //        str.Append(", ");
            //    }
            //}

            writeGO.GetComponentInChildren<Text>().text = str.ToString();
            //DestroyImmediate(writeGO);
        }

    }

    void MakeListMadeSlot()
    {
        int confirmCount = 0;        
        madeSlotNumber = new int[game.madeSlotCount];

        while (confirmCount < game.madeSlotCount)
        {
            for (int i = 0; i < mon.unitcount; i++)
            {
                if (game.unitDebutHistory[i] == true)
                {
                    madeSlotNumber[confirmCount] = i;
                    confirmCount = confirmCount + 1;
                    //Debug.Log(i);
                } 
            }
        }
    }

    void MakeListCharDegree()
    {
        int confirmCount = 0;
        charDegreeNumber = new int[game.countCharThatHaveDegree];

        while (confirmCount < game.countCharThatHaveDegree)
        {
            for (int i = 0; i < mon.charcount; i++)
            {
                if (game.charDearDegree[i] > 0)
                {
                    charDegreeNumber[confirmCount] = i;
                    confirmCount = confirmCount + 1;
                    //Debug.Log(i);
                }
            }
        }
    }

    public void ButtonChanger()
    {
        createMadeSlotHistoryList.HowManyButtons = game.madeSlotCount;
        createMadeSlotHistoryList.CreateButtons();
        MakeListMadeSlot();
        WriteMadeSlot();
        madeSlotHistoryPopUp.gameObject.SetActive(false);
        charDegreeInfoPopUp.gameObject.SetActive(false);
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(true);
    }


    public void ButtonChanger2()
    {
        madeSlotHistoryPopUp.gameObject.SetActive(true);
        charDegreeInfoPopUp.gameObject.SetActive(true);
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        for (int i = 0; i < game.madeSlotCount; i++)
        {
            string slotname = "MadeSlotList" + i;
            GameObject destoryGO;
            destoryGO = GameObject.Find(slotname);
            DestroyImmediate(destoryGO);
        }
    }

    public void ButtonChanger3()
    {
        createCharDegreeList.HowManyButtons = game.countCharThatHaveDegree;
        createCharDegreeList.CreateButtons2();
        MakeListCharDegree();
        WriteCharDegreeList();
        charDegreeInfoPopUp.gameObject.SetActive(false);
        madeSlotHistoryPopUp.gameObject.SetActive(false);
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(true);
    }


    public void ButtonChanger4()
    {
        charDegreeInfoPopUp.gameObject.SetActive(true);
        madeSlotHistoryPopUp.gameObject.SetActive(true);
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        for (int i = 0; i < game.countCharThatHaveDegree; i++)
        {
            string slotname = "CharDegreeList" + i;
            GameObject destoryGO;
            destoryGO = GameObject.Find(slotname);
            DestroyImmediate(destoryGO);
        }
    }



    void Update()
    {

        TextRefresh();

        if (game.madeSlotCount == 0)
        {
            madeSlotHistoryPopUp.gameObject.SetActive(false);
            charDegreeInfoPopUp.gameObject.SetActive(false);
        }
        else if (checkButtonAppear == false)
        {
            madeSlotHistoryPopUp.gameObject.SetActive(true);
            charDegreeInfoPopUp.gameObject.SetActive(true);
            checkButtonAppear = true;
        }
        else
        {
            // do nothing!
        }

        if (game.pointCanDrawCard == 0)
        {
            drawCardPopUp.gameObject.SetActive(false);
        }
        else
        {
            drawCardPopUp.gameObject.SetActive(true);
        }

    }

    void TextRefresh()
    {

        for (int i = 0; i < 5; i++)
        {
            cardSlot[i] = mon.charData2[game.cardSlot[i], 1] + "\n(" + mon.charData2[game.cardSlot[i], 3] + ")";
            mButText[i].text = cardSlot[i];
        }

        pointDisplay.text = "Score : " + game.score + " (" + game.requireLevelup + ") " + "\n Level : " + game.level + "\n CardCredit : " + game.pointCanDrawCard;
        skillPointText.text = "SP : " + Convert.ToInt32(game.skillPoint);

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

        if (game.level < 5)
        {
            for (int i = 0; i < 5; i++)
            {
                skillButton[i].gameObject.SetActive(false);
                skillPointText.gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                skillButton[i].gameObject.SetActive(true);
                skillPointText.gameObject.SetActive(true);
            }
        }



        //historyDisplay.text = "Duo : " + game.makecounthistory[2] + "\nTrio : " + game.makecounthistory[3] +"\nQuartet : " + game.makecounthistory[4] + "\nQuintet : " + game.makecounthistory[5];

    }


    

}



