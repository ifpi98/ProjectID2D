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
    public GameObject ssrEffect;

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

    public Button unitMakeHintDPBg;
    public Text unitMakeHintBgText;
    public Button unitMakeHintInfoDPBg;
    public Text unitMakeHintInfoDPBgText;

    public Button madeSlotHistoryPopUp;
    public Text madeSlotCountText;
    public Button madeSlotInfoPopUp_CheckButtAfter;
    public CreateAnimImage createMadeSlotHistoryList;
    public Button madeSlotAvailableUnit;
    public Text madeSlotAvailableUnitText;
    

    public Button charDegreeInfoPopUp;
    public Button charDegreeInfoPopUp_CheckButtAfter;
    public CreateAnimImage createCharDegreeList;
    public Button charDegreeAvailableChar;
    public Text charDegreeAvailableCharText;
    

    public Button drawCardPopUp;
    public Button drawCardPopUp_CheckButtAfter;
    Button drawCardResultDP2Bg;
    Button drawCardResultDP2Bg10;
    Text drawCardResultDP2BgText;
    Text drawCardResultDP2Bg10Text;

    Button descriptionBg;
    Button description2Bg;
    Text descriptionBgText;
    Text description2BgText;

    public Button settingPopUp_CheckButt;    

    EasyTween easyTweenDrawCardResultPopUp;
    EasyTween easyTweenDrawCardResultPopUp10;
    EasyTween easyTweenNotifyNoCreditPopUp;
    EasyTween easyTweenDescriptionPopUp;

    //private CreateAnimImage createAnimImage0;
    //private CreateAnimImage createAnimImage1;

    // Use this for initialization
    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();

        madeSlot = new GameObject[8];

        madeSlot[0] = GameObject.Find("Made Slot Button 0");
        madeSlot[1] = GameObject.Find("Made Slot Button 1");
        madeSlot[2] = GameObject.Find("Made Slot Button 2");
        madeSlot[3] = GameObject.Find("Made Slot Button 3");
        madeSlot[4] = GameObject.Find("Made Slot Button 4");
        madeSlot[5] = GameObject.Find("Made Slot Button 5");
        madeSlot[6] = GameObject.Find("Made Slot Button 6");
        madeSlot[7] = GameObject.Find("Made Slot Button 7");

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

        madeSlotButton = new Button[8];
        madeSlotButtonText = new Text[8];

        for (int i = 0; i < 8; i++)
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

        unitMakeHintDPBg = GameObject.Find("UnitMakeHintDPBg").GetComponent<Button>();
        unitMakeHintBgText = unitMakeHintDPBg.GetComponentInChildren<Text>();
        unitMakeHintInfoDPBg = GameObject.Find("UnitMakeHintInfoDPBg").GetComponent<Button>();
        unitMakeHintInfoDPBgText = unitMakeHintInfoDPBg.GetComponentInChildren<Text>();

        madeSlotHistoryPopUp = GameObject.Find("MadeSlotInfoPopUp_CheckButt").GetComponent<Button>();
        madeSlotCountText = madeSlotHistoryPopUp.GetComponentInChildren<Text>();
        madeSlotInfoPopUp_CheckButtAfter = GameObject.Find("MadeSlotInfoPopUp_CheckButtAfter").GetComponent<Button>();
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(false);
        madeSlotAvailableUnit = GameObject.Find("MadeSlotAvailableUnit").GetComponent<Button>();
        madeSlotAvailableUnitText = madeSlotAvailableUnit.GetComponentInChildren<Text>();        

        createMadeSlotHistoryList = GameObject.Find("HistroyListCreateAnimImage").GetComponent<CreateAnimImage>();

        //historyDisplay = GameObject.Find("Make History Text").GetComponent<Text>();

        charDegreeInfoPopUp = GameObject.Find("CharDegreeInfoPopUp_CheckButt").GetComponent<Button>();
        charDegreeInfoPopUp_CheckButtAfter = GameObject.Find("CharDegreeInfoPopUp_CheckButtAfter").GetComponent<Button>();
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(false);
        charDegreeAvailableChar = GameObject.Find("CharDegreeAvailableChar").GetComponent<Button>();
        charDegreeAvailableCharText = charDegreeAvailableChar.GetComponentInChildren<Text>();

        createCharDegreeList = GameObject.Find("CharDegreeListCreateAnimImage").GetComponent<CreateAnimImage>();

        drawCardPopUp = GameObject.Find("DrawCardPopUp_CheckButt").GetComponent<Button>();
        drawCardResultDP2Bg = GameObject.Find("DrawCardResultDP2Bg").GetComponent<Button>();
        drawCardResultDP2Bg10 = GameObject.Find("DrawCardResultDP2Bg10").GetComponent<Button>();
        drawCardResultDP2BgText = drawCardResultDP2Bg.GetComponentInChildren<Text>();
        drawCardResultDP2Bg10Text = drawCardResultDP2Bg10.GetComponentInChildren<Text>();

        settingPopUp_CheckButt = GameObject.Find("SettingPopUp_CheckButt").GetComponent<Button>();

        descriptionBg = GameObject.Find("DescriptionBg").GetComponent<Button>();
        description2Bg = GameObject.Find("Description2Bg").GetComponent<Button>();
        descriptionBgText = descriptionBg.GetComponentInChildren<Text>();
        description2BgText = description2Bg.GetComponentInChildren<Text>();
        easyTweenDescriptionPopUp = GameObject.Find("DescriptionPopUpAnim").GetComponent<EasyTween>();

        //drawCardPopUp_CheckButtAfter = GameObject.Find("DrawCardPopUp_CheckButtAfter").GetComponent<Button>();
        //drawCardPopUp_CheckButtAfter.gameObject.SetActive(false);

        easyTweenDrawCardResultPopUp = GameObject.Find("DrawCardResultPopUpAnim").GetComponent<EasyTween>();
        easyTweenDrawCardResultPopUp10 = GameObject.Find("DrawCardResultPopUp10Anim").GetComponent<EasyTween>();
        easyTweenNotifyNoCreditPopUp = GameObject.Find("NotifyNoCreditPopUpAnim").GetComponent<EasyTween>();

        //createAnimImage0 = FindObjectOfType<CreateAnimImage>();
        //createAnimImage1 = FindObjectOfType<CreateAnimImage>();
    }
    
    void WriteMadeSlot()
    {
        string[] strArr = new string[game.madeSlotCount];
        int[] intArr = new int[game.madeSlotCount];

        for (int i = 0; i < game.madeSlotCount; i++)
        {
            //string slotname = "MadeSlotList" + i;
            //GameObject writeGO;
            //writeGO = GameObject.Find(slotname);            

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

            strArr[i] = str.ToString();
            intArr[i] = Convert.ToInt16(mon.unitData2[madeSlotNumber[i], 0]);

            //writeGO.GetComponentInChildren<Text>().text = str.ToString();

            //DestroyImmediate(writeGO);
        }

        createMadeSlotHistoryList.Set(strArr,intArr);
        madeSlotAvailableUnitText.text = game.madeSlotCount + " / " + game.availableUnit;

    }

    void WriteCharDegreeList()
    {
        string[] strArr = new string[game.countForMakingCharDegreeList];
        int[] intArr = new int[game.countForMakingCharDegreeList];

        for (int i = 0; i < game.countForMakingCharDegreeList; i++)
        {
            //string slotname = "CharDegreeList" + i;
            //GameObject writeGO;
            //writeGO = GameObject.Find(slotname);

            StringBuilder str = new StringBuilder();
            //int unitcount = Convert.ToInt16(mon.unitData2[madeSlotNumber[i], 14]);

            int tempCardRank = game.charCardRank[charDegreeNumber[i]];

            str.Append("이름 : " + mon.charData2[charDegreeNumber[i], 1]);
            str.Append("\n친애도 : " + game.charDearDegree[charDegreeNumber[i]]);

            if (Convert.ToInt16(mon.charData2[charDegreeNumber[i], 2]) == 0)
            {
                str.Append("                            오디션 출현 레벨 : 1");
            }
            else
            {
                str.Append("                            오디션 출현 레벨 : " + mon.charData2[charDegreeNumber[i], 2]);
            }
            

            if (tempCardRank == 0)
            {
                str.Append("\n카드 정보 : [ " + mon.charData2[charDegreeNumber[i], 1]);
            }
            else
            {
                str.Append("\n카드 정보 : [ " + mon.charData2[charDegreeNumber[i], 8 + tempCardRank]);
            }
            
            str.Append(" (" + mon.cardRankData2[tempCardRank + 1, 1] + ") ]");        
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

            strArr[i] = str.ToString();
            intArr[i] = Convert.ToInt16(mon.charData2[charDegreeNumber[i], 0]);
            //writeGO.GetComponentInChildren<Text>().text = str.ToString();
            //charDegreeAvailableCharText.text = game.countForMakingCharDegreeList + " / " + game.availableChar; 
            //DestroyImmediate(writeGO);
        }

        createCharDegreeList.Set2(strArr, intArr);
        charDegreeAvailableCharText.text = game.countForMakingCharDegreeList + " / " + game.availableChar;
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
        charDegreeNumber = new int[game.countForMakingCharDegreeList];

        while (confirmCount < game.countForMakingCharDegreeList)
        {
            for (int i = 0; i < mon.charcount; i++)
            {
                if (game.charDearDegree[i] > 0 || game.charCardRank[i] > 0)
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
        settingPopUp_CheckButt.gameObject.SetActive(false);
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(true);
    }


    public void ButtonChanger2()
    {
        madeSlotHistoryPopUp.gameObject.SetActive(true);
        charDegreeInfoPopUp.gameObject.SetActive(true);
        settingPopUp_CheckButt.gameObject.SetActive(true);
        madeSlotInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        //for (int i = 0; i < game.madeSlotCount; i++)
        //{
        //    string slotname = "MadeSlotList" + i;
        //    GameObject destoryGO;
        //    destoryGO = GameObject.Find(slotname);
        //    DestroyImmediate(destoryGO);
        //}
    }

    public void ButtonChanger3()
    {
        createCharDegreeList.HowManyButtons2 = game.countForMakingCharDegreeList;
        createCharDegreeList.CreateButtons2();
        MakeListCharDegree();
        WriteCharDegreeList();
        charDegreeInfoPopUp.gameObject.SetActive(false);
        madeSlotHistoryPopUp.gameObject.SetActive(false);
        settingPopUp_CheckButt.gameObject.SetActive(false);
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(true);
    }


    public void ButtonChanger4()
    {
        charDegreeInfoPopUp.gameObject.SetActive(true);
        madeSlotHistoryPopUp.gameObject.SetActive(true);
        settingPopUp_CheckButt.gameObject.SetActive(true);
        charDegreeInfoPopUp_CheckButtAfter.gameObject.SetActive(false);

        //for (int i = 0; i < game.countForMakingCharDegreeList; i++)
        //{
        //    string slotname = "CharDegreeList" + i;
        //    GameObject destoryGO;
        //    destoryGO = GameObject.Find(slotname);
        //    DestroyImmediate(destoryGO);
        //}
    }

    public void CharDescription(int instanceCharID)
    {
        StringBuilder strTitle = new StringBuilder();

        strTitle.Append(mon.charData2[instanceCharID, 1]);        

        StringBuilder strDesc = new StringBuilder();

        strDesc.Append(mon.charData2[instanceCharID, 12]);
        strDesc.Append("\n");
        strDesc.Append("\n");

        if (mon.charData2[instanceCharID, 5] == "")
        {
            // do nothing!
        }
        else
        {
            strDesc.Append("성우: " + mon.charData2[instanceCharID, 5]);
            strDesc.Append("\n");
        }
                
        strDesc.Append("출처: 나무위키, 문서의 표현을 일부 수정하였음");

        descriptionBgText.text = strTitle.ToString(); 
        description2BgText.text = strDesc.ToString();
        easyTweenDescriptionPopUp.OpenCloseObjectAnimation();
    }

    public void UnitDescription(int instanceUnitID)
    {
        StringBuilder strTitle = new StringBuilder();

        strTitle.Append(mon.unitData2[instanceUnitID, 1]);

        StringBuilder strDesc = new StringBuilder();

        strDesc.Append(mon.unitData2[instanceUnitID, 15]);

        descriptionBgText.text = strTitle.ToString();
        description2BgText.text = strDesc.ToString();
        easyTweenDescriptionPopUp.OpenCloseObjectAnimation();
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

        pointDisplay.text = "Score : " + game.score + " (" + game.requireLevelup + ") " + "\n Level : " + game.level + "\n 데뷰 가능 유닛수 :" + game.availableUnitNowCount + "\n CardCredit : " + game.pointCanDrawCard;
        skillPointText.text = "Skill Point : " + Convert.ToInt32(game.skillPoint);

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

    public void CheckCardCredit()
    {
        if (game.pointCanDrawCard == 0)
        {
            easyTweenNotifyNoCreditPopUp.OpenCloseObjectAnimation();
        }
        else
        {
            DrawCard();
            easyTweenDrawCardResultPopUp.OpenCloseObjectAnimation();            
        }
                
    }

    public void CheckCardCredit10()
    {
        if (game.pointCanDrawCard < 10)
        {
            easyTweenNotifyNoCreditPopUp.OpenCloseObjectAnimation();
        }
        else
        {
            DrawCard10();
            easyTweenDrawCardResultPopUp10.OpenCloseObjectAnimation();
        }
    }

    void DrawCard10()
    {
        int[] drawCardArray = new int[10];
        int[] drawCardRankArray = new int[10];

        for (int i = 0; i < 10; i++)
        {
            drawCardArray[i] = DrawCardJust();
            //Debug.Log(drawCardArray[i]);
            drawCardRankArray[i] = DecideCardRank();
            //Debug.Log(drawCardRankArray[i]);
        }

        bool isThereSCARD = false;

        for (int i = 0; i < 10; i++)
        {            

            if (drawCardRankArray[i] > 1)
            {
                isThereSCARD = true;
                break;
            }            
        }

        if (isThereSCARD != true)
        {
            int tempnum;
            tempnum = UnityEngine.Random.Range(0, 10);
            drawCardRankArray[tempnum] = 2;
            Debug.Log(tempnum + "There is no SCard!!!!");
        }

        StringBuilder str = new StringBuilder();
                
        str.Append("축하합니다.\n");
        str.Append("신데렐라 소녀들의 아티스트 샷을 촬영하였습니다.\n");

        for (int i = 0; i < 10; i++)
        {
            int y = i + 1;
            if (i < 9)
            {
                str.Append("\n사진 정보" + y + "   : [ " + mon.charData2[drawCardArray[i], 1] + " - " + mon.charData2[drawCardArray[i], 8 + drawCardRankArray[i]]);
                str.Append(" (" + mon.cardRankData2[drawCardRankArray[i] + 1, 1] + ") ]");
            }
            else
            {
                str.Append("\n사진 정보" + y + " : [ " + mon.charData2[drawCardArray[i], 1] + " - " + mon.charData2[drawCardArray[i], 8 + drawCardRankArray[i]]);
                str.Append(" (" + mon.cardRankData2[drawCardRankArray[i] + 1, 1] + ") ]");
            }

        }
  
        drawCardResultDP2Bg10Text.text = Convert.ToString(str);


        for (int i = 0; i < 10; i++)
        {
            int tempCharDrawCardRank = game.charCardRank[drawCardArray[i]];

            if (tempCharDrawCardRank < drawCardRankArray[i])
            {
                game.charCardRank[drawCardArray[i]] = drawCardRankArray[i];
                DI.SetCharCardRankString();
            }
            else if (tempCharDrawCardRank > 0)
            {
                if (game.charDearDegree[drawCardArray[i]] + 10 < Convert.ToInt16(mon.cardRankData2[tempCharDrawCardRank + 1, 2]))
                {
                    game.charDearDegree[drawCardArray[i]] = game.charDearDegree[drawCardArray[i]] + 10;
                }
                else
                {
                    game.charDearDegree[drawCardArray[i]] = Convert.ToInt16(mon.cardRankData2[tempCharDrawCardRank + 1, 2]);
                }
            }
            else
            {
                //do nothing!
            }
        }        

        game.pointCanDrawCard = game.pointCanDrawCard - 10;
        game.CheckCharDegreeList();
        DI.SetCharDearDegreeString();
        DI.SetDrawCardPoint();


    }

    int DrawCardJust()
    {
        int randomNumber = 0;
        bool level101Check = true;

        while (level101Check)
        {
            randomNumber = UnityEngine.Random.Range(1, mon.charcount);
            if (Convert.ToInt16(mon.charData2[randomNumber, 2]) > 100)
            {
                //do nothing!
            }
            else
            {
                level101Check = false;
            }
            //Debug.Log(mon.charData2[randomNumber, 2]);
        }

        return randomNumber;
    }
    
    
    void DrawCard()
    {
        int randomNumber = 0;
        int tempCardRank = 1;
        bool level101Check = true;

        while (level101Check)
        {
            randomNumber = UnityEngine.Random.Range(1, mon.charcount);
            if (Convert.ToInt16(mon.charData2[randomNumber, 2]) > 100)
            {
                //do nothing!
            }
            else
            {
                level101Check = false;
            }
            //Debug.Log(mon.charData2[randomNumber, 2]);
        }

        tempCardRank = DecideCardRank();        

        StringBuilder str = new StringBuilder();

        str.Append("축하합니다.\n");        
        str.Append(mon.charData2[randomNumber, 1]);
        str.Append("의 아티스트 샷을 촬영하였습니다.\n");        
        str.Append("\n사진 정보 : [ " + mon.charData2[randomNumber, 8 + tempCardRank]);
        str.Append(" (" + mon.cardRankData2[tempCardRank+1,1] + ") ]");

        //Debug.Log(randomNumber);
        drawCardResultDP2BgText.text = Convert.ToString(str);

        int tempCharDrawCardRank = game.charCardRank[randomNumber];

        if (tempCharDrawCardRank < tempCardRank)
        {
            game.charCardRank[randomNumber] = tempCardRank;
            DI.SetCharCardRankString();
        }
        else if (tempCharDrawCardRank > 0)
        {
            if (game.charDearDegree[randomNumber] + 10 < Convert.ToInt16(mon.cardRankData2[tempCharDrawCardRank + 1, 2]))
            {
                game.charDearDegree[randomNumber] = game.charDearDegree[randomNumber] + 10;
            }
            else
            {
                game.charDearDegree[randomNumber] = Convert.ToInt16(mon.cardRankData2[tempCharDrawCardRank + 1, 2]);
            }
        }
        else
        {
            //do nothing!
        }            

        game.pointCanDrawCard = game.pointCanDrawCard - 1;
        game.CheckCharDegreeList();
        DI.SetCharDearDegreeString();
        DI.SetDrawCardPoint();
        

    }

    int DecideCardRank()
    {
        int cardRank = 1;

        if (game.countDrawCardwithoutSSR == 99)
        {
            cardRank = 3;
            game.countDrawCardwithoutSSR = 0;

            GameObject tempGO1;
            GameObject tempGO2;
            GameObject tempGO3;
            GameObject tempGO4;
            GameObject tempGO5;
            GameObject tempGO6;

            tempGO1 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-1000, -300), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
            tempGO2 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-300, 400), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
            tempGO3 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(400, 1000), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
            tempGO4 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-1000, -300), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;
            tempGO5 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-300, 400), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;
            tempGO6 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(400, 1000), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;

            Destroy(tempGO1, 5);
            Destroy(tempGO2, 5);
            Destroy(tempGO3, 5);
            Destroy(tempGO4, 5);
            Destroy(tempGO5, 5);
            Destroy(tempGO6, 5);

            Debug.Log("You got SSR Card...");      
        }
        else
        {
            int randNumber = UnityEngine.Random.Range(0, 100);

            if (randNumber == 0)
            {
                cardRank = 3;
                game.countDrawCardwithoutSSR = 0;
                GameObject tempGO1;
                GameObject tempGO2;
                GameObject tempGO3;
                GameObject tempGO4;
                GameObject tempGO5;
                GameObject tempGO6;

                tempGO1 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-1000, -300), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
                tempGO2 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-300, 400), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
                tempGO3 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(400, 1000), UnityEngine.Random.Range(-1000, 0), 0), Quaternion.identity) as GameObject;
                tempGO4 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-1000, -300), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;
                tempGO5 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(-300, 400), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;
                tempGO6 = Instantiate(ssrEffect, new Vector3(UnityEngine.Random.Range(400, 1000), UnityEngine.Random.Range(0, 1000), 0), Quaternion.identity) as GameObject;

                Destroy(tempGO1, 5);
                Destroy(tempGO2, 5);
                Destroy(tempGO3, 5);
                Destroy(tempGO4, 5);
                Destroy(tempGO5, 5);
                Destroy(tempGO6, 5);
                Debug.Log("You got SSR Card. Wow. Lucky!");
            }
            else if (randNumber < 10)
            {
                cardRank = 2;
                game.countDrawCardwithoutSSR = game.countDrawCardwithoutSSR + 1;
            }
            else
            {
                cardRank = 1;
                game.countDrawCardwithoutSSR = game.countDrawCardwithoutSSR + 1;
            }

            if (randNumber == 100)
            {
                Debug.Log("why 100?");
            }
        }

        return cardRank;
        
    }

}



