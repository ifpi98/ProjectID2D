using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Game : MonoBehaviour
{
    public int basicRemainTurn = 5;

    public int[] cardSlot;
    //public string cardSlot0;
    string cardSlot1;
    string cardSlot2;
    string cardSlot3;
    string cardSlot4;
    public int[] remainturncardslot;
    public bool[] checkremainTurncardslot;
    bool firstcheck = false;
    public bool secondcheck = false;
    public bool thirdcheck = false;
    DataIni DI;
    Monster mon;
    int[,] unitArray;
    public List<int> madeSlotList = new List<int>();
    int tempnum;
    int maxSkillPoint;
    bool skillcheck;
    public float skillPoint;
    public bool[] skillOnCheck;
    int[] tempnumarray;
    //public Texture tex1;
    public int[] makecounthistory;
    public int score;
    public int level;
    public int maxCombo;
    public int totalTurn;
    public List<int> slotCardList;
    public int combocount = 0;
    public int[] charDearDegree;
    string charDearDegreeEncodedString1;
    public bool[] unitDebutHistory;
    string unitDebutHistoryEncodedString1;
    DataArrayJson dAJ;


    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(Screen.width* 16 / 9, Screen.width , false);
        //Screen.SetResolution(960, 720, false);
        Screen.SetResolution(1152, 648, false);
              
        

        DI = GameObject.Find("DataObj").GetComponent<DataIni>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        dAJ = GameObject.Find("DataObj").GetComponent<DataArrayJson>();

        checkExp();

        charDearDegree = new int[mon.charcount];        
        unitDebutHistory = new bool[mon.unitcount];

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
                    Debug.Log("nullException??");                    
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
                    Debug.Log("nullException??");
                }
                
            }
        }               
        
        score = DI.GetExp();
        level = DI.GetLV();
        maxSkillPoint = level * 10 + 100;
        skillPoint = 0;
        skillOnCheck = new bool[3];

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

        secondcheck = true;
        SlotCardMaKe();
                

    }

 


    // Update is called once per frame
    void Update()
    {
                
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



    public void checkExp()
    {
        for (int i = 1; i < mon.expLvcount; i++)
        {
            if (score < Convert.ToInt32(mon.expLvData2[i, 2]))
            {
                level = i-1;
                maxSkillPoint = level * 10 + 100;
                basicRemainTurn = Convert.ToInt32(mon.expLvData2[i - 1, 4]);
                //Debug.Log("Level = " +  mon.expLvData2[i - 1, 1]);
                //Debug.Log("bRT = " + mon.expLvData2[i - 1, 4]);
                if (firstcheck == true)
                {
                    DI.SetExpLvMC();
                    //DI.SetCharDearDegreeString();
                    //DI.SetUnitDebutHistoryString();
                }                
                break;
            }

        }
    }

    void SkillCheck()
    {
        skillcheck = true;
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

        if (check0 == false || remainturncardslot[0] == 0)
        {
            int tempchecknum = 0;
            checkIsExisted[0] = true;
            while (checkIsExisted[0] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[0] = false;

                    if (tempnum == cardSlot[i] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                    {
                        checkIsExisted[0] = true;
                        break;
                    }
                }

                if (checkIsExisted[0] == false)
                { 
                    SkillCheck();

                    if (skillcheck == false)
                    {
                        checkIsExisted[0] = true;
                        //Debug.Log("SKILL CHECK");
                    }
                }
            }
            cardSlot[0] = tempnum;
            remainturncardslot[0] = basicRemainTurn + 1;
        }

        if (check1 == false || remainturncardslot[1] == 0)
        {
            checkIsExisted[1] = true;
            while (checkIsExisted[1] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[1] = false;

                    if (tempnum == cardSlot[i] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                    {
                        checkIsExisted[1] = true;
                        break;
                    }
                }

                if (checkIsExisted[1] == false)
                {
                    SkillCheck();

                    if (skillcheck == false)
                    {
                        checkIsExisted[1] = true;
                        //Debug.Log("SKILL CHECK");
                    }
                }
            }
            cardSlot[1] = tempnum;
            remainturncardslot[1] = basicRemainTurn + 1;
        }

        if (check2 == false || remainturncardslot[2] == 0)
        {
            checkIsExisted[2] = true;
            while (checkIsExisted[2] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[2] = false;

                    if (tempnum == cardSlot[i] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                    {
                        checkIsExisted[2] = true;
                        break;
                    }
                }

                if (checkIsExisted[2] == false)
                {
                    SkillCheck();

                    if (skillcheck == false)
                    {
                        checkIsExisted[2] = true;
                        //Debug.Log("SKILL CHECK");
                    }
                }
            }
            cardSlot[2] = tempnum;
            remainturncardslot[2] = basicRemainTurn + 1;
        }

        if (check3 == false || remainturncardslot[3] == 0)
        {
            checkIsExisted[3] = true;
            while (checkIsExisted[3] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[3] = false;

                    if (tempnum == cardSlot[i] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                    {
                        checkIsExisted[3] = true;
                        break;
                    }
                }

                if (checkIsExisted[3] == false)
                {
                    SkillCheck();

                    if (skillcheck == false)
                    {
                        checkIsExisted[3] = true;
                        //Debug.Log("SKILL CHECK");
                    }
                }
            }
            cardSlot[3] = tempnum;
            remainturncardslot[3] = basicRemainTurn + 1;
        }

        if (check4 == false || remainturncardslot[4] == 0)
        {
            checkIsExisted[4] = true;
            while (checkIsExisted[4] == true)
            {
                tempnum = UnityEngine.Random.Range(1, mon.charcount);
                for (int i = 0; i < 5; i++)
                {
                    checkIsExisted[4] = false;

                    if (tempnum == cardSlot[i] || Convert.ToInt32(mon.charData2[tempnum, 2]) > level)
                    {
                        checkIsExisted[4] = true;
                        break;
                    }
                }

                if (checkIsExisted[4] == false)
                {
                    SkillCheck();

                    if (skillcheck == false)
                    {
                        checkIsExisted[4] = true;
                        //Debug.Log("SKILL CHECK");
                    }
                }
            }
            cardSlot[4] = tempnum;
            remainturncardslot[4] = basicRemainTurn + 1;
        }

        for (int i = 0; i < 5; i++)
        {
            remainturncardslot[i] = remainturncardslot[i] - 1;
            checkremainTurncardslot[i] = true;
        }

        for (int i = 0; i < 3; i++)
        {
            skillOnCheck[i] = false;
        }


        totalTurn = totalTurn + 1;

    }

    void SlotCardMaKe()
    {
        
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

            //Debug.Log("END");


        }
        
    }


    public void PassTurnWithMake(int decideUnit)
    {
        combocount = combocount + 1;

        if (combocount > maxCombo)
        {
            maxCombo = combocount;
        }

        Debug.Log("YOU MADE : " + mon.unitData2[decideUnit, 1] + " Unit Number : " + decideUnit);

        if (unitDebutHistory[decideUnit] == false)
        {
            unitDebutHistory[decideUnit] = true;
            Debug.Log("You just made them DO DEBUT : " + mon.unitData2[decideUnit, 1] + " Unit Number : " + decideUnit);            
        }
        DI.SetUnitDebutHistoryString();

        List<int> findMember = new List<int>();
        List<int> findMemberplace = new List<int>();
        bool[] checkMakeUnitMemberplace = new bool[5];
        //Debug.Log(decideUnit);

        for (int i = 0; i < 5; i++)
        {
            if (mon.unitData3[decideUnit-1, i] != 0)
            {
                findMember.Add(mon.unitData3[decideUnit-1, i]);
                if (charDearDegree[(mon.unitData3[decideUnit - 1, i])] <= 600)
                {
                    charDearDegree[(mon.unitData3[decideUnit - 1, i])] = charDearDegree[(mon.unitData3[decideUnit - 1, i])] + 1;
                }
                else
                {
                    charDearDegree[(mon.unitData3[decideUnit - 1, i])] = 600;
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

        switch (findMemberplace.Count)
        {            
            case 2:
                int sumDearDegree = 0;
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]];
                score = Convert.ToInt32(score + 50 * (1 + 0.1f * (combocount - 1)) + sumDearDegree);
                makecounthistory[2] = makecounthistory[2] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;                
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
            case 3:
                sumDearDegree = 0;
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]];
                score = Convert.ToInt32(score + 200 * (1 + 0.1f * (combocount - 1)) + sumDearDegree);
                makecounthistory[3] = makecounthistory[3] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
            case 4:
                sumDearDegree = 0;
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]] + charDearDegree[findMember[3]];
                score = Convert.ToInt32(score + 900 * (1 + 0.1f * (combocount - 1)) + sumDearDegree);
                makecounthistory[4] = makecounthistory[4] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
            case 5:
                sumDearDegree = 0;
                sumDearDegree = charDearDegree[findMember[0]] + charDearDegree[findMember[1]] + charDearDegree[findMember[2]] + charDearDegree[findMember[3]] + charDearDegree[findMember[4]];
                score = Convert.ToInt32(score + 1600 * (1 + 0.1f * (combocount - 1)) + sumDearDegree);
                makecounthistory[5] = makecounthistory[5] + 1;
                skillPoint = skillPoint + findMemberplace.Count * 10;
                DI.SetMakeCountHistory();
                DI.SetCharDearDegreeString();
                break;
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

    

}