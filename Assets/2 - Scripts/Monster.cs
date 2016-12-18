using UnityEngine;
using System;

public class Monster : MonoBehaviour
{

    //public string[] unitData;
    public string[,] unitData2 = new string[400,15];
    public string[,] charData2 = new string[200,15];
    public string[,] expLvData2 = new string[200, 15];
    public string[,] locData2 = new string[400, 15];
    public string[,] cardRankData2 = new string[200, 15];
    public int[,] unitData3 = new int[400, 5];
    public int[] charAge;
    public int charcount;
    public int unitcount;
    public int expLvcount;
    public int loccount;
    public int cardRankcount;
    
    // Use this for initialization
    void Start()
    {

        charAge = new int[200];
        SetCharData();
        SetUnitData();
        SetExpLvData();
        SetLocData();
        SetCardRankData();

    }


    void SetCharData()
    {
        CharParser Char1 = GameObject.Find("DataObj").GetComponent<CharParser>();
        charData2 = Char1._tempCD2;
        charcount = Char1._charData.Length;

        for (int i = 1; i < charcount; i++)
        {
            charAge[i] = Convert.ToInt32(charData2[i, 4]);
            //Debug.Log(charData2[i, 4]);
        }
        
        //Debug.Log(charData2[1, 1]);
        //Debug.Log(charcount);
    }

    void SetCardRankData()
    {
        CardRankParser CardRank1 = GameObject.Find("DataObj").GetComponent<CardRankParser>();
        cardRankData2 = CardRank1._tempCRD2;
        cardRankcount = CardRank1._cardRankData.Length;
        //Debug.Log("CRD1by1 : " + cardRankData2[1, 1]);
        //Debug.Log("CRCOUNT : " + cardRankcount);

    }

    void SetUnitData()
    {
        UnitParser Unit1 = GameObject.Find("DataObj").GetComponent<UnitParser>();
        unitData2 = Unit1._tempUD2;
        unitcount = Unit1._unitData.Length;

        for (int i = 1; i < unitcount; i++)
        {
            for (int y = 4; y < 9; y++)
            {
                if (unitData2[i, y] != "")
                { 
                    unitData3[i - 1, y - 4] = Convert.ToInt32(unitData2[i, y]);
                }
                //Debug.Log(unitData3[i - 1, y - 4]);
            }
        }
        
        //Debug.Log(unitData2[1,1]);
        //Debug.Log(unitcount);
    }

    void SetExpLvData()
    {
        ExpLvParser ExpLv1 = GameObject.Find("DataObj").GetComponent<ExpLvParser>();
        expLvData2 = ExpLv1._tempED2;
        expLvcount = ExpLv1._expLvData.Length;
        //Debug.Log(charData2[1, 1]);
        //Debug.Log(charcount);
    }

    void SetLocData()
    {
        LocalizationParser Loc1 = GameObject.Find("DataObj").GetComponent<LocalizationParser>();
        locData2 = Loc1._tempLD2;
        loccount = Loc1._localizationData.Length;
        //Debug.Log(locData2[1, 1]);
        //Debug.Log(loccount);
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    

}