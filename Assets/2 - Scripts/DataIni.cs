using UnityEngine;
using System.Collections;

public class DataIni : MonoBehaviour {

    IniFile pIDIni;
    //Monster mon;
    Game game;
    DataArrayJson dAJ;
    bool latestartcheck;

    // Use this for initialization
    void Start () {

        latestartcheck = false;
        pIDIni = new IniFile("ProjectID"); // ini extension appends to file name here
        

    }
	
	// Update is called once per frame
	void Update () {

        if (latestartcheck == false)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            game = GameObject.Find("GameObj").GetComponent<Game>();
            dAJ = GameObject.Find("DataObj").GetComponent<DataArrayJson>();
            //Debug.Log(game.score);
            latestartcheck = true;
        }
	
	}
        

    public void SetExpLvMC()
    {
        pIDIni.SetInt("Exp", game.score);
        pIDIni.SetInt("Level", game.level);
        pIDIni.SetInt("MaxCombo", game.maxCombo);
        pIDIni.SetInt("BasicRemainTurn", game.basicRemainTurn);
        pIDIni.SetInt("TotalTurn", game.totalTurn);

        pIDIni.Save("ProjectID");
    }

    public void SetDrawCardPoint()
    {
        pIDIni.SetInt("CountDrawCardwithoutSSR", game.countDrawCardwithoutSSR);
        pIDIni.SetInt("PointCanDrawCard", game.pointCanDrawCard);

        pIDIni.Save("ProjectID");
    }

    public void DataReset()
    {
        //pIDIni.SetInt("Exp", 0);
        //pIDIni.SetInt("Level", 1);
        //pIDIni.SetInt("MaxCombo", 0);
        //pIDIni.SetInt("BasicRemainTurn", 5);
        //pIDIni.SetInt("TotalTurn", 0);
        //pIDIni.SetInt("MakeCountHistory2", 0);
        //pIDIni.SetInt("MakeCountHistory3", 0);
        //pIDIni.SetInt("MakeCountHistory4", 0);
        //pIDIni.SetInt("MakeCountHistory5", 0);

        pIDIni.Clear();
        pIDIni.Save("ProjectID");
        
    }

    public void SetMakeCountHistory()
    {
        pIDIni.SetInt("MakeCountHistory2", game.makecounthistory[2]);
        pIDIni.SetInt("MakeCountHistory3", game.makecounthistory[3]);
        pIDIni.SetInt("MakeCountHistory4", game.makecounthistory[4]);
        pIDIni.SetInt("MakeCountHistory5", game.makecounthistory[5]);        

        pIDIni.Save("ProjectID");
    }

    public void SetCharDearDegreeString()
    {
        dAJ.MakeObjCharDearDegree();
        pIDIni.SetString("CharDearDegreeString", dAJ.dearDegreeEncodedString1);     
        //Debug.Log("SETTING");

        pIDIni.Save("ProjectID");
    }

    public void SetUnitDebutHistoryString()
    {
        dAJ.MakeObjUnitDebutHistory();
        pIDIni.SetString("UnitDebutHistoryString", dAJ.debutHistoryEncodedString1);
        //Debug.Log("SETTING");

        pIDIni.Save("ProjectID");
    }

    public void SetCharCardRankString()
    {
        dAJ.MakeObjCharCardRank();
        pIDIni.SetString("CharCardRankString", dAJ.cardRankEncodedString1);
        //Debug.Log("SETTING");

        pIDIni.Save("ProjectID");
    }

    public string GetCharCardRankString()
    {
        string CharCardRankString = pIDIni.GetString("CharCardRankString");
        return CharCardRankString;
    }
    

    public string GetCharDearDegreeString()
    {
        string charDearDegreeString = pIDIni.GetString("CharDearDegreeString");
        return charDearDegreeString;
    }

    public int GetCountDrawCardwithoutSSR()
    {
        int privatecountDrawCardwithoutSSR = pIDIni.GetInt("CountDrawCardwithoutSSR");
        return privatecountDrawCardwithoutSSR;
    }

    public int GetPointCanDrawCard()
    {
        int privatecountPointCanDrawCard = pIDIni.GetInt("PointCanDrawCard");
        return privatecountPointCanDrawCard;
    }
    
    public string GetUnitDebutHistoryString()
    {
        string unitDebutHistoryString = pIDIni.GetString("UnitDebutHistoryString");
        return unitDebutHistoryString;
    }

    public int GetExp()
    {
        int exp = pIDIni.GetInt("Exp");        
        return exp;

    }

    public int GetTotalTurn()
    {
        int totalTurn = pIDIni.GetInt("TotalTurn");
        return totalTurn;

    }

    public int GetMaxCombo()
    {
        int maxCombo = pIDIni.GetInt("MaxCombo");
        return maxCombo;

    }

    public int GetLV()
    {
        int level = pIDIni.GetInt("Level");
        return level;
    }

    public int GetBasicRemainTurn()
    {
        int basicRemainTurn = pIDIni.GetInt("BasicRemainTurn");
        return basicRemainTurn;

    }

    public int GetMakeCountHistory2()
    {
        int makeCountHistory2 = pIDIni.GetInt("MakeCountHistory2");
        return makeCountHistory2;
    }

    public int GetMakeCountHistory3()
    {
        int makeCountHistory3 = pIDIni.GetInt("MakeCountHistory3");
        return makeCountHistory3;
    }

    public int GetMakeCountHistory4()
    {
        int makeCountHistory4 = pIDIni.GetInt("MakeCountHistory4");
        return makeCountHistory4;
    }

    public int GetMakeCountHistory5()
    {
        int makeCountHistory5 = pIDIni.GetInt("MakeCountHistory5");
        return makeCountHistory5;
    }



}
