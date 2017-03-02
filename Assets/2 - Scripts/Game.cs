using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Game : MonoBehaviour
{
    bool firstcheck = false;
    public bool secondcheck = false;
    public bool thirdcheck = false;

    DataIni DI;
    Monster mon;
    MOITwitter moiTwitter;
    DataArrayJson dAJ;
    EasyTween easyTweenMadeSlotPopUp;
    EasyTween easyTweenLevelUpInfoPopUp;
    EasyTween easyTweenUnitMakeHintInfoPopUp;

    int tempnum;
    int maxSkillPoint;
    int sumDearDegree;
    int getExpWhenMadeSlot;
    int availableUnitNow = 0;
    bool skillcheck;
    bool levelUpCheck;
    string charDearDegreeEncodedString1;    
    string unitDebutHistoryEncodedString1;
    string charCardRankEncodedString1;
    float madeSlotScrollbarVerticalValue;
    GameObject madeSlotViewPort;
    Scrollbar madeSlotScrollbarVertical;
    


    public int basicRemainTurn = 5;
    public int score;
    public int level;
    public int maxCombo;
    public int totalTurn;
    public int combocount = 0;
    public int requireLevelup;
    public int madeSlotCount;
    //public int countCharThatHaveDegree;
    public int countForMakingCharDegreeList;
    public int pointCanDrawCard;
    public int countDrawCardwithoutSSR;
    public int availableChar;
    public int availableUnit;
    public int availableUnitNowCount = 0;
    public int countPassTurnWithoutMake;
    public float skillPoint;

    int[] tempnumarray;
    public int[] cardSlot;    
    public int[] remainturncardslot;
    public int[] makecounthistory;
    public int[] charDearDegree;
    public int[] charCardRank;    
    public bool[] checkremainTurncardslot;
    public bool[] skillOnCheck;
    public bool[] unitDebutHistory;
    int[,] unitArray;
    
    public List<int> madeSlotList = new List<int>();
    public List<int> slotCardList;
    public List<int> availableCharList;
    public List<int> availableUnitList;
    public List<int> unitCanDebutList;



    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(Screen.width* 16 / 9, Screen.width , false);
        //Screen.SetResolution(960, 720, false);
        //Screen.SetResolution(1152, 648, false);
        
        
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        dAJ = GameObject.Find("DataObj").GetComponent<DataArrayJson>();
        moiTwitter = GameObject.Find("TwitterObj").GetComponent<MOITwitter>();
        easyTweenMadeSlotPopUp = GameObject.Find("PopUpButtonAnim").GetComponent<EasyTween>();
        easyTweenLevelUpInfoPopUp = GameObject.Find("LevelUpInfoAnim").GetComponent<EasyTween>();
        easyTweenUnitMakeHintInfoPopUp = GameObject.Find("UnitMakeHintInfoAnim").GetComponent<EasyTween>();
        madeSlotViewPort = GameObject.Find("MadeSlotViewPort");
        madeSlotScrollbarVertical = GameObject.Find("MadeSlotScrollbarVertical").GetComponent<Scrollbar>();
        madeSlotScrollbarVerticalValue = madeSlotScrollbarVertical.value;

        checkExp();

        charDearDegree = new int[mon.charcount];
        charCardRank = new int[mon.charcount];
        unitDebutHistory = new bool[mon.unitcount];

        ReadInIData();        

        maxSkillPoint = level * 10 + 100;
        skillPoint = 0;
        skillOnCheck = new bool[5];

        WriteGameData();
        CheckMadeSlotCount();
        CheckCharDegreeList();

        PutCardInSlotAtFirst();
        AvailableChar();
        AvailableCharNow(level);

        levelUpCheck = false;
        secondcheck = true;
        SlotCardMaKe();                

    }


    void AvailableChar()
    {
        availableChar = 0;
        availableCharList = new List<int>();

        for (int i = 1; i < mon.charcount; i++)
        {
            if (Convert.ToInt32(mon.charData2[i, 2]) > 100)
            {
                // do nothing
            }
            else
            {
                availableChar = availableChar + 1;
                availableCharList.Add(i);
            }
        }

        //Debug.Log("available Character : " + availableChar);
        //Debug.Log("available Character : " + availableCharList[availableCharList.Count-1]);
        
                
        List<int> tempUnitList = new List<int>();
        
        for (int i = 0; i < mon.unitcount - 1; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (unitArray[i, y] == 0)
                {
                    break;
                }

                tempUnitList.Add(unitArray[i, y]);
            }
            
            bool isSubset = !tempUnitList.Except(availableCharList).Any();

            if (isSubset)
            {
                availableUnit = availableUnit + 1;            
            }
            else
            {
                //Debug.Log(i);
            }

            tempUnitList.Clear();                
                
        }

        //Debug.Log(availableUnit);


    }

    void AvailableCharNow(int producerLevel)
    {
        int availableCharNow = 0;
        availableUnitNowCount = 0;
        List<int> availableCharNowList = new List<int>();

        // 프로듀서 레벨보다 등장레벨이 늦은 아이돌이면 패스
        // 그게 아닐 경우 availableCharNow 에 1을 더하고, 리스트에 아이돌 캐릭터 번호를 추가한다.

        for (int i = 1; i < mon.charcount; i++)
        {
            if (Convert.ToInt32(mon.charData2[i, 2]) > producerLevel)
            {
                // do nothing
            }
            else
            {
                availableCharNow = availableCharNow + 1;
                availableCharNowList.Add(i);
                //Debug.Log("Char Number:" + i);
            }
        }

        //Debug.Log("available Character : " + availableChar);
        //Debug.Log("available Character : " + availableCharList[availableCharList.Count-1]);


        List<int> tempUnitList = new List<int>();
        List<int> tempUnitList2 = new List<int>();        

        // 유닛 정보를 하나씩 꺼낸다.
        // 유닛의 1번 멤버, 2번 멤버, 3번 멤버, 4번 멤버, 5번 멤버를 꺼내서 임시 리스트에 넣는다.
        // 0일 경우, 멤버가 없단 의미니까 멈추고 다음으로
        // 임시 리스트의 멤버로 구성된 집합이 availableCharNowList의 부분집합인지 확인한다.
        // 부분집합이라면 현재 조합이 가능하다는 의미니까 availableUnitNow에 1을 더한다. 그리고 tempUnitList2에 해당 유닛 번호를 넣는다.
        // 아니라면 현재 조합이 불가능하다.
        // 임시 리스트를 날려버리고, 등록된 유닛만큼 반복한다.


        for (int i = 0; i < mon.unitcount - 1; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (unitArray[i, y] == 0)
                {
                    break;
                }

                tempUnitList.Add(unitArray[i, y]);
            }

            bool isSubset = !tempUnitList.Except(availableCharNowList).Any();

            if (isSubset)
            {
                availableUnitNow = availableUnitNow + 1;
                tempUnitList2.Add(i);
                //Debug.Log("Unit Number:" + (i + 1));
            }
            else
            {
                //Debug.Log(i);
            }

            tempUnitList.Clear();

        }

        // tempUnitList2에는 현재 조합가능한 유닛의 유닛 번호가 들어 있다.
        // 그 유닛 번호를 하나씩 꺼내서 해당 유닛이 이전에 데뷔했는지 확인한다.
        // 데뷔한 적이 없다면 availableUnitNowCount에 1을 더한다. 
        // availableUnitNowCount은 현재 데뷔가능한 유닛 개수를 의미한다.
        // unitCanDebutList에는 과거의 정보가 있으므로 날려버린다.
        // unitCanDebutList에 데뷔가능한 유닛 번호를 더한다.
        // 만약 availableUnitNowCount과 unitCanDebutList.Count가 다르다면 에러를 낸다. => 그러면 안되니까

        unitCanDebutList.Clear();

        for (int i = 0; i < tempUnitList2.Count; i++)
        {
            if (!unitDebutHistory[tempUnitList2[i] + 1])
            {
                availableUnitNowCount = availableUnitNowCount + 1;
                unitCanDebutList.Add(tempUnitList2[i] + 1);
                // Debug.Log(tempUnitList2[i] + 1);   
                // 위 주석 처리된 부분은 이 부분에서 리스트에 들어가는 유닛들 번호를 로그로 찍는 명령
                if (availableUnitNowCount != unitCanDebutList.Count)
                {
                    Debug.Log("ERRRRRRROOOR!");
                }
            }
            else
            {
                //Debug.Log(tempUnitList2[i]);
            }
                 
        }

        //Debug.Log(unitCanDebutList[0]);

        //Debug.Log("Level: " + level + " availableUnitNow: " + availableUnitNow);
        //Debug.Log("Level: " + level + " availableUnitNowCount: " + availableUnitNowCount);

    }

    void CheckMadeSlotCount()
    {
        madeSlotCount = 0;

        for (int i = 0; i < mon.unitcount; i++)
        {
            if (unitDebutHistory[i] == true)
            {
                madeSlotCount = madeSlotCount + 1;
            }
        }
        
    }

    public void CheckCharDegreeList()
    {
        //countCharThatHaveDegree = 0;

        //for (int i = 0; i < mon.charcount; i++)
        //{
        //    if (charDearDegree[i] > 0)
        //    {
        //        countCharThatHaveDegree = countCharThatHaveDegree + 1;
        //    }
        //}

        countForMakingCharDegreeList = 0;

        for (int i = 0; i < mon.charcount; i++)
        {
            if (charCardRank[i] > 0 || charDearDegree[i] > 0)
            {
                countForMakingCharDegreeList = countForMakingCharDegreeList + 1;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (levelUpCheck == true)
        {
            LevelUpInfoData();
            levelUpCheck = false;
            easyTweenLevelUpInfoPopUp.OpenCloseObjectAnimation();
            AvailableCharNow(level);

        }
               
        if (secondcheck == false && thirdcheck == false)
        {
            PassTurnWithoutMake(checkremainTurncardslot[0], checkremainTurncardslot[1],checkremainTurncardslot[2],
                checkremainTurncardslot[3],checkremainTurncardslot[4]);
            SlotCardMaKe();
            checkExp();            
            secondcheck = true;
        }
                
        if (skillPoint <= maxSkillPoint)
        { 
            skillPoint = skillPoint + Time.deltaTime * 3;
        }
        if (skillPoint > maxSkillPoint)
        {
            skillPoint = maxSkillPoint;
        }

    }

    void LevelUpInfoData()
    {
        GameCanvasGui gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
        gCanvas.levelUpDPBgText.text = "Level " + level + " 달성";        

        gCanvas.levelUpInfoDPBgText.text = mon.expLvData2[level, 5];
    }


    void UnitMakeHintInfoData()
    {
        GameCanvasGui gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
        gCanvas.unitMakeHintBgText.text = "아직 데뷔하지 못한 유닛 힌트";        

        int unitNumberOfHint;
        unitNumberOfHint = unitCanDebutList[UnityEngine.Random.Range(0, availableUnitNowCount - 1)];

        //gCanvas.unitMakeHintInfoDPBgText.text = mon.expLvData2[level, 5];

        StringBuilder str = new StringBuilder();
        int unitcount = Convert.ToInt16(mon.unitData2[unitNumberOfHint, 14]);

        for (int i = 0; i < unitcount; i++)
        {
            str.Append(mon.charData2[Convert.ToInt16(mon.unitData2[unitNumberOfHint, i + 4]), 1]);

            if (i < unitcount - 1)
            {
                str.Append(", ");
            }
        }        
        str.Append("의 " + unitcount + "인 유닛으로 조합해 보시면 어떨까요?'");
        //Debug.Log(unitNumberOfHint);

        gCanvas.unitMakeHintInfoDPBgText.text = str.ToString();
    }
    


    public void checkExp()
    {
        int previousLevel;
        previousLevel = level;
        for (int i = 1; i < mon.expLvcount; i++)
        {
            if (score < Convert.ToInt32(mon.expLvData2[i, 2]))
            {
                level = i-1;                
                maxSkillPoint = level * 10 + 100;
                basicRemainTurn = Convert.ToInt32(mon.expLvData2[i - 1, 4]);
                //Debug.Log("Level = " +  mon.expLvData2[i - 1, 1]);
                //Debug.Log("bRT = " + mon.expLvData2[i - 1, 4]);
                requireLevelup = Convert.ToInt32(mon.expLvData2[level + 1, 2]) - score;
                if (firstcheck == true)
                {
                    DI.SetExpLvMC();
                    DI.SetCharCardRankString();
                    //DI.SetCharDearDegreeString();
                    //DI.SetUnitDebutHistoryString();
                }
                if (level > previousLevel)
                {
                    levelUpCheck = true;
                }
                break;
            }

        }
    }
    

    void SkillCheck2()
    {
        if (skillOnCheck[3] == true)
        {
            if (mon.charAge[tempnum] < 17)
            {
                // do nothing. it means OK!
            }
            else
            {
                skillcheck = false;                
            }
        }
        else if (skillOnCheck[4] == true)
        {
            if (mon.charAge[tempnum] > 16)
            {
                // do nothing. it means OK!
            }
            else
            {
                skillcheck = false;                
            }
        }
    }

    void SkillCheck()
    {
        skillcheck = true;

        SkillCheck2();

        if (skillcheck == false)
        {
            return;
        }        

        for (int i = 0; i < 3; i++)
        {            
            if (skillOnCheck[i] == true)
            { 
                switch (i)
                {
                    case 0:

                        if (mon.charData2[tempnum, 3] != "Cute")
                        {                        
                            skillcheck = false;        
                        }                                                
                        break;

                    case 1:

                        if (mon.charData2[tempnum, 3] != "Cool")
                        {
                            skillcheck = false;                        
                        }
                                                
                        break;

                    case 2:

                        if (mon.charData2[tempnum, 3] != "Passion")
                        {
                            skillcheck = false;                            
                        }
                                                
                        break;

                }
            }
        }
    }


    public void PassTurnWithoutMake(bool check0, bool check1, bool check2, bool check3, bool check4)
    {
        combocount = 0;

        //bool internalcheck = false;
        bool[] checkIsExisted = new bool[5];
        bool[] checknumber = new bool[] { check0, check1, check2, check3, check4 };

        for (int i = 0; i < 5; i++)
        {
            if (checknumber[i] == false || remainturncardslot[i] == 0)
            {
                //int tempchecknum = 0;
                checkIsExisted[i] = true;
                while (checkIsExisted[i] == true)
                {
                    tempnum = UnityEngine.Random.Range(1, mon.charcount);
                    for (int y = 0; y < 5; y++)
                    {
                        checkIsExisted[i] = false;

                        if (tempnum == cardSlot[y] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                        {
                            checkIsExisted[i] = true;
                            break;
                        }
                    }

                    if (checkIsExisted[i] == false)
                    {
                        SkillCheck();

                        if (skillcheck == false)
                        {
                            checkIsExisted[i] = true;
                            //Debug.Log("SKILL CHECK");
                        }
                    }
                }
                cardSlot[i] = tempnum;
                remainturncardslot[i] = basicRemainTurn + 1;
            }
        }


        for (int i = 0; i < 5; i++)
        {
            remainturncardslot[i] = remainturncardslot[i] - 1;
            checkremainTurncardslot[i] = true;
        }

        for (int i = 0; i < 5; i++)
        {
            skillOnCheck[i] = false;
        }

        totalTurn = totalTurn + 1;
        countPassTurnWithoutMake = countPassTurnWithoutMake + 1;

        if (countPassTurnWithoutMake > 4 && availableUnitNowCount > 5)
        {
            //Debug.Log("countPassTurnWithoutMake is over 5!");            
            countPassTurnWithoutMake = 0;
            UnitMakeHintInfoData();
            easyTweenUnitMakeHintInfoPopUp.OpenCloseObjectAnimation();
        }

    }

    void SlotCardMaKe()
    {
        GameCanvasGui gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
        slotCardList = new List<int>();
        List<int> tempUnitList = new List<int>();
        //Debug.Log("initialize");

        //slotCardList.Clear();

        for (int i = 0; i < 5; i++)
        {
            slotCardList.Add(cardSlot[i]);
            //Debug.Log(slotCardList[i]);
        }

        for (int i = 0; i < mon.unitcount-1; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (unitArray[i, y] == 0)
                {
                    break;
                }
                tempUnitList.Add(unitArray[i, y]);
                //Debug.Log(unitArray[i, y]);
            }

            bool isSubset = !tempUnitList.Except(slotCardList).Any();

            if (isSubset)
            {
                //secondcheck = true;
                //Debug.Log(isSubset);
                //Debug.Log(i + 1 + " : " + mon.unitData2[i+1,1]);
                madeSlotList.Add(i + 1);
                //Debug.Log(madeSlotList[0]);

            }

            tempUnitList.Clear();
            madeSlotViewPort.transform.position = new Vector2(madeSlotViewPort.transform.position.x, -285);
            madeSlotScrollbarVertical.value = madeSlotScrollbarVerticalValue;

            //Debug.Log("END");


        }
        
    }

    void UnitDebut(int decideUnit2)
    {
        GameCanvasGui gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
        pointCanDrawCard = pointCanDrawCard + 1;
        DI.SetDrawCardPoint();

        StringBuilder str = new StringBuilder();
        int unitcount = Convert.ToInt16(mon.unitData2[decideUnit2, 14]);

        for (int i = 0; i < unitcount; i++)
        {
            str.Append(mon.charData2[Convert.ToInt16(mon.unitData2[decideUnit2, i + 4]), 8]);

            if (i < unitcount - 1)
            {
                str.Append(", ");
            }
        }
        str.Append("의 " + unitcount + "인 유닛 '" + mon.unitData2[decideUnit2, 1] + "'");
        str.Append("의 데뷔를 축하해 주세요. ");
        str.Append("\nMaster Of Idol, 신데렐라 멤버들을 모아 유닛으로 데뷔시키는 것은 프로듀서, 바로 당신! \n#MOIDEBUT");

        // 멤버 A, 멤버 B, 멤버 C, (멤버 D), (멤버 E)가 유닛 ‘XXXXXXXXXXXXXXX’로 데뷔(컴백)하였습니다. 

        unitDebutHistory[decideUnit2] = true;
        DI.SetUnitDebutHistoryString();
        CheckMadeSlotCount();
        CheckCharDegreeList();
        //gCanvas.madeSlotCountText.text = Convert.ToString(madeSlotCount);            
        moiTwitter.stringForTwit = str.ToString();
        gCanvas.popUpButtonMadeText.text = moiTwitter.stringForTwit;

        //StringBuilder str2 = new StringBuilder();
        //str2.Append("Score 획득: ");
        //str2.Append(sumDearDegree + getExpWhenMadeSlot);

        //gCanvas.madeSlotGetExpDPText.text = str2.ToString();

        //StringBuilder str3 = new StringBuilder();
        //str3.Append("Sp 획득: ");
        //str3.Append(unitcount * 10);

        //gCanvas.madeSlotGetSpDPText.text = str3.ToString();
                
        easyTweenMadeSlotPopUp.OpenCloseObjectAnimation();
        Debug.Log("You just made them DO DEBUT : " + mon.unitData2[decideUnit2, 1] + " Unit Number : " + decideUnit2);
    }


    public void PassTurnWithMake(int decideUnit)
    {
        combocount = combocount + 1;

        if (combocount > maxCombo)
        {
            maxCombo = combocount;
        }

        //Debug.Log("YOU MADE : " + mon.unitData2[decideUnit, 1] + " Unit Number : " + decideUnit);
        
        List<int> findMember = new List<int>();
        List<int> findMemberplace = new List<int>();
        bool[] checkMakeUnitMemberplace = new bool[5];
        //Debug.Log(decideUnit);

        for (int i = 0; i < 5; i++)
        {
            if (mon.unitData3[decideUnit-1, i] != 0)
            {
                findMember.Add(mon.unitData3[decideUnit-1, i]);
                int tempa = mon.unitData3[decideUnit - 1, i];
                if (charDearDegree[(mon.unitData3[decideUnit - 1, i])] < Convert.ToInt32(mon.cardRankData2[charCardRank[tempa] + 1, 2]))
                {
                    //Debug.Log(mon.cardRankData2[charCardRank[tempa] + 1, 2]);
                    charDearDegree[(mon.unitData3[decideUnit - 1, i])] = charDearDegree[(mon.unitData3[decideUnit - 1, i])] + 1;
                }
                else
                {
                    charDearDegree[(mon.unitData3[decideUnit - 1, i])] = Convert.ToInt32(mon.cardRankData2[charCardRank[tempa] + 1, 2]);
                }
                //Debug.Log(findMember[i]);                
            }
            else
            {
                //Debug.Log(findMember.Count);
                break;
            }
        }

        for (int i = 0; i < findMember.Count; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                //Debug.Log(slotCardList[y]);
                if (findMember[i] == slotCardList[y])
                {
                    findMemberplace.Add(y);
                    //Debug.Log("check : " + findMemberplace[i]);
                }
            }            
        }
        //Debug.Log(findMemberplace.Count);

        sumDearDegree = 0;
        getExpWhenMadeSlot = 0;

        switch (findMemberplace.Count)
        {           

            case 2:                
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]];
                getExpWhenMadeSlot = Convert.ToInt32(50 * (1 + 0.1f * (combocount - 1)));                
                if (availableUnitNowCount == 0)
                {
                    score = score + (getExpWhenMadeSlot + sumDearDegree) * 2;                    
                }
                else
                {
                    score = score + getExpWhenMadeSlot + sumDearDegree;
                }
                makecounthistory[2] = makecounthistory[2] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;                
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
            case 3:                
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]];
                getExpWhenMadeSlot = Convert.ToInt32(200 * (1 + 0.1f * (combocount - 1)));
                if (availableUnitNowCount == 0)
                {
                    score = score + (getExpWhenMadeSlot + sumDearDegree) * 2;
                }
                else
                {
                    score = score + getExpWhenMadeSlot + sumDearDegree;
                }
                makecounthistory[3] = makecounthistory[3] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                pointCanDrawCard = pointCanDrawCard + 1;
                DI.SetDrawCardPoint();
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
            case 4:                
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]] + charDearDegree[findMember[3]];
                getExpWhenMadeSlot = Convert.ToInt32(900 * (1 + 0.1f * (combocount - 1)));
                if (availableUnitNowCount == 0)
                {
                    score = score + (getExpWhenMadeSlot + sumDearDegree) * 2;
                }
                else
                {
                    score = score + getExpWhenMadeSlot + sumDearDegree;
                }
                makecounthistory[4] = makecounthistory[4] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                pointCanDrawCard = pointCanDrawCard + 2;
                DI.SetDrawCardPoint();
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                Debug.LogWarning("wow!" + decideUnit);
                break;
            case 5:                
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]] + charDearDegree[findMember[3]] + charDearDegree[findMember[4]];
                getExpWhenMadeSlot = Convert.ToInt32(1600 * (1 + 0.1f * (combocount - 1)));
                if (availableUnitNowCount == 0)
                {
                    score = score + (getExpWhenMadeSlot + sumDearDegree) * 2;
                }
                else
                {
                    score = score + getExpWhenMadeSlot + sumDearDegree;
                }
                makecounthistory[5] = makecounthistory[5] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                pointCanDrawCard = pointCanDrawCard + 4;
                DI.SetDrawCardPoint();
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                Debug.LogWarning("wow!" + decideUnit);
                break;
        }

        if (unitDebutHistory[decideUnit] == false)
        {
            UnitDebut(decideUnit);
            AvailableCharNow(level);
        }


        for (int i = 0; i < 5; i++)
        {
            checkMakeUnitMemberplace[i] = true;        
            if (findMemberplace.Contains(i))
            {
                checkMakeUnitMemberplace[i] = false;
            }
        }
        
        PassTurnWithMakeCardChange(checkMakeUnitMemberplace[0], checkMakeUnitMemberplace[1], 
            checkMakeUnitMemberplace[2], checkMakeUnitMemberplace[3], checkMakeUnitMemberplace[4]);

        countPassTurnWithoutMake = 0;
        madeSlotList.Clear();
        SlotCardMaKe();        
        
    }

    void PassTurnWithMakeCardChange(bool check0, bool check1, bool check2, bool check3, bool check4)
    {
                
        bool[] checkIsExisted = new bool[5];        
        bool[] checknumber = new bool[] { check0, check1, check2, check3, check4 };

        // 무작위로 카드를 뽑습니다. (1과 캐릭터 수 사이의 숫자만큼)
        // 단 선택된 카드는 이미 슬롯에 있는 카드여선 안되고, 해당 카드의 등장 레벨 숫자가 현재의 레벨보다 커선 안됩니다.

        for (int i = 0; i < 5; i++)
        {
            if (checknumber[i]== false)
            {
                checkIsExisted[i] = true;
                while (checkIsExisted[i] == true)
                {
                    tempnum = UnityEngine.Random.Range(1, mon.charcount);
                    for (int y = 0; y < 5; y++)
                    {
                        checkIsExisted[i] = false;

                        if (tempnum == cardSlot[y] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                        {
                            checkIsExisted[i] = true;
                            break;
                        }
                    }

                    // 체크값이 실패라면, 스킬이 켜져 있는 지를 확인합니다. 
                    // 스킬 체크에서 실패한다면 다시 while로 돌아가서 이 과정을 반복합니다.

                    if (checkIsExisted[i] == false)
                    {
                        SkillCheck();

                        if (skillcheck == false)
                        {
                            checkIsExisted[i] = true;
                            //Debug.Log("SKILL CHECK");
                        }
                    }
                }
                cardSlot[i] = tempnum;
                remainturncardslot[i] = basicRemainTurn;
            }
        }
               

        // 체크해놨던 슬롯을 모두 해제하고, 경험치 체크를 한번 돌립니다.

        for (int i = 0; i < 5; i++)
        {
            checkremainTurncardslot[i] = true;
        }
        
        checkExp();
    }


    void PutCardInSlotAtFirst()
    {
        tempnumarray = new int[5];

        while (firstcheck == false)
        {
            for (int i = 0; i < 5; i++)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                tempnumarray[i] = tempnum;
            }

            firstcheck = true;

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (i != y)
                    {
                        if (tempnumarray[i] == tempnumarray[y] || Convert.ToInt32(mon.charData2[tempnumarray[i], 2]) > level)
                        {
                            firstcheck = false;
                            //Debug.Log("CHECKING");
                            break;
                        }

                    }
                }
            }

        }

        for (int i = 0; i < 5; i++)
        {
            cardSlot[i] = tempnumarray[i];
        }
    }


    void WriteGameData()
    {
        for (int i = 0; i < 5; i++)
        {
            remainturncardslot[i] = basicRemainTurn;
        }
        cardSlot = new int[5];
                
        unitArray = new int[mon.charcount, 5];
        unitArray = mon.unitData3;

        checkremainTurncardslot = new bool[5];

        for (int i = 0; i < 5; i++)
        {
            checkremainTurncardslot[i] = true;
        }
    }


    void ReadInIData()
    {
        charDearDegreeEncodedString1 = DI.GetCharDearDegreeString();

        if (charDearDegreeEncodedString1 != "")
        {
            JSONObject charDearJson = new JSONObject(charDearDegreeEncodedString1);
            //Debug.Log("CharDear : " + charDearDegreeEncodedString1);        
            dAJ.accessData(charDearJson);
            JSONObject arr1 = charDearJson["DearDegree"];
            //Debug.Log(arr1[1].n);

            for (int i = 1; i < mon.charcount; i++)
            {
                try
                {
                    charDearDegree[i] = Convert.ToInt32(arr1[i].n);
                }
                catch
                {
                    Debug.Log("nullException?? Character!!");
                }
            }
        }

        unitDebutHistoryEncodedString1 = DI.GetUnitDebutHistoryString();

        if (unitDebutHistoryEncodedString1 != "")
        {
            //Debug.Log("UnitDebut : " + unitDebutHistoryEncodedString1);

            JSONObject unitDebutJson = new JSONObject(unitDebutHistoryEncodedString1);
            dAJ.accessData(unitDebutJson);
            JSONObject arr2 = unitDebutJson["DebutHistory"];
            //Debug.Log(arr2[1].n);

            for (int i = 1; i < mon.unitcount; i++)
            {
                try
                {
                    unitDebutHistory[i] = arr2[i].b;
                }
                catch
                {
                    Debug.Log("nullException?? Unit!!");
                }

            }
        }

        charCardRankEncodedString1 = DI.GetCharCardRankString();

        if (charCardRankEncodedString1 != "")
        {
            //Debug.Log("UnitDebut : " + unitDebutHistoryEncodedString1);

            JSONObject cardRankJson = new JSONObject(charCardRankEncodedString1);
            dAJ.accessData(cardRankJson);
            JSONObject arr3 = cardRankJson["CharCardRank"];
            //Debug.Log(arr2[1].n);

            for (int i = 1; i < mon.charcount; i++)
            {
                try
                {
                    charCardRank[i] = Convert.ToInt32(arr3[i].n);
                }
                catch
                {
                    Debug.Log("nullException?? CharCardRank");
                }

            }
        }
        

        score = DI.GetExp();
        level = DI.GetLV();
        countDrawCardwithoutSSR = DI.GetCountDrawCardwithoutSSR();
        pointCanDrawCard = DI.GetPointCanDrawCard();

        if (level == 0)
        {
            level = 1;
        }
        totalTurn = DI.GetTotalTurn();
        if (DI.GetBasicRemainTurn() != 0)
        {
            basicRemainTurn = DI.GetBasicRemainTurn();
        }

        maxCombo = 0;
        maxCombo = DI.GetMaxCombo();

        remainturncardslot = new int[5];
        makecounthistory = new int[6];

        makecounthistory[2] = DI.GetMakeCountHistory2();
        makecounthistory[3] = DI.GetMakeCountHistory3();
        makecounthistory[4] = DI.GetMakeCountHistory4();
        makecounthistory[5] = DI.GetMakeCountHistory5();
    }



}