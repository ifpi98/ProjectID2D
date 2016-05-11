using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Game : MonoBehaviour
{
    public int basicRemainTurn = 5;

    public int[] cardSlot;
    public string cardSlot0;
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
    int[] tempnumarray;
    //public Texture tex1;
    public int score;
    public int level;
    public int maxCombo;
    public List<int> slotCardList;
    public int combocount = 0;



    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(Screen.width* 16 / 9, Screen.width , false);
        //Screen.SetResolution(960, 720, false);
        Screen.SetResolution(1152, 648, false);
              
        

        DI = GameObject.Find("DataObj").GetComponent<DataIni>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();

        checkExp();

        score = DI.GetExp();
        level = DI.GetLV();
        if (DI.GetBasicRemainTurn() != 0)
        {
            basicRemainTurn = DI.GetBasicRemainTurn();
        }
            
        maxCombo = DI.GetMaxCombo();

        remainturncardslot = new int[5];
        maxCombo = 0;

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
                

    }



    public void checkExp()
    {
        for (int i = 1; i < mon.expLvcount; i++)
        {
            if (score < Convert.ToInt32(mon.expLvData2[i, 2]))
            {
                level = i-1;
                basicRemainTurn = Convert.ToInt32(mon.expLvData2[i - 1, 4]);
                //Debug.Log("Level = " +  mon.expLvData2[i - 1, 1]);
                //Debug.Log("bRT = " + mon.expLvData2[i - 1, 4]);
                if (firstcheck == true)
                {
                    DI.SetExpLvMC();
                }                
                break;
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
            }
            cardSlot[4] = tempnum;
            remainturncardslot[4] = basicRemainTurn + 1;
        }

        for (int i = 0; i < 5; i++)
        {
            remainturncardslot[i] = remainturncardslot[i] - 1;
            checkremainTurncardslot[i] = true;
        }



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

        for (int i = 0; i < mon.unitcount - 1; i++)
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
                Debug.Log(i + 1 + " : " + mon.unitData2[i+1,1]);
                madeSlotList.Add(i + 1);

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

        List<int> findMember = new List<int>();
        List<int> findMemberplace = new List<int>();
        bool[] checkMakeUnitMemberplace = new bool[5];
        //Debug.Log(decideUnit);

        for (int i = 0; i < 5; i++)
        {
            if (mon.unitData3[decideUnit, i] != 0)
            {
                findMember.Add(mon.unitData3[decideUnit-1, i]);
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

        //bool internalcheck = false;
        bool[] checkIsExisted = new bool[5];

        if (check0 == false)
        {
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
            }
            cardSlot[0] = tempnum;
            remainturncardslot[0] = basicRemainTurn;
        }

        if (check1 == false)
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
            }
            cardSlot[1] = tempnum;
            remainturncardslot[1] = basicRemainTurn;
        }

        if (check2 == false)
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
            }
            cardSlot[2] = tempnum;
            remainturncardslot[2] = basicRemainTurn;
        }

        if (check3 == false)
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
            }
            cardSlot[3] = tempnum;
            remainturncardslot[3] = basicRemainTurn;
        }

        if (check4 == false)
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
            }
            cardSlot[4] = tempnum;
            remainturncardslot[4] = basicRemainTurn;
        }
        checkExp();
    }

    

}