using UnityEngine;


public class DataArrayJson : MonoBehaviour {

    public JSONObject charDearDegreeObj = new JSONObject(JSONObject.Type.OBJECT);
    public JSONObject charDearDegreeArray = new JSONObject(JSONObject.Type.ARRAY);
    public JSONObject unitDebutHistoryObj = new JSONObject(JSONObject.Type.OBJECT);
    public JSONObject unitDebutHistoryArray = new JSONObject(JSONObject.Type.ARRAY);
    public JSONObject charCardRankObj = new JSONObject(JSONObject.Type.OBJECT);
    public JSONObject charCardRankArray = new JSONObject(JSONObject.Type.ARRAY);
    public string dearDegreeEncodedString1;
    public string debutHistoryEncodedString1;
    public string cardRankEncodedString1;
    Monster mon;
    Game game;
    bool latestartcheck;


    // Use this for initialization
    void Start () {

        latestartcheck = false;

    }
	
    // Update is called once per frame
	void Update () {

        if (latestartcheck == false)
        { 
            mon = GameObject.Find("GameObj").GetComponent<Monster>();
            game = GameObject.Find("GameObj").GetComponent<Game>();

            MakeObjCharDearDegree();
            MakeObjUnitDebutHistory();
            MakeObjCharCardRank();
            latestartcheck = true;
        }


    }

    public void MakeObjCharDearDegree()
    {
        //unitDearDegreeObj.AddField("field1", 0.5f);
        //unitDearDegreeObj.AddField("field2", "sampletext");
        if (!charDearDegreeObj.HasField("DearDegree"))
        {
            charDearDegreeObj.AddField("DearDegree", charDearDegreeArray);
        }

        charDearDegreeArray.Clear();
        
        //Debug.Log("character count :" + mon.charcount);
        for (int i = 0; i < mon.charcount; i++)
        {            
            charDearDegreeArray.Add(game.charDearDegree[i]);
            //Debug.Log(game.charDearDegree[i]);
        }

        dearDegreeEncodedString1 = charDearDegreeObj.Print();
        //Debug.Log(dearDegreeEncodedString1);

        //JSONObject sampleJson1 = new JSONObject(dearDegreeEncodedString1);
        //accessData(sampleJson1);
    }

    public void MakeObjUnitDebutHistory()
    {
        if (!unitDebutHistoryObj.HasField("DebutHistory"))
        {
            unitDebutHistoryObj.AddField("DebutHistory", unitDebutHistoryArray);
        }

        unitDebutHistoryArray.Clear();
        
        for (int i = 0; i < mon.unitcount; i++)
        {            
            unitDebutHistoryArray.Add(game.unitDebutHistory[i]);
        }

        debutHistoryEncodedString1 = unitDebutHistoryObj.Print();
        //Debug.Log(debutHistoryEncodedString1);

        //sampleJson1 = new JSONObject(debutHistoryEncodedString1);
        //accessData(sampleJson1);     
    }
    
    public void MakeObjCharCardRank()
    {
        if (!charCardRankObj.HasField("CharCardRank"))
        {
            charCardRankObj.AddField("CharCardRank", charCardRankArray);
        }

        charCardRankArray.Clear();

        for (int i = 0; i < mon.charcount; i++)
        {
            charCardRankArray.Add(game.charCardRank[i]);
        }

        cardRankEncodedString1 = charCardRankObj.Print();
        //Debug.Log(debutHistoryEncodedString1);

        //sampleJson1 = new JSONObject(debutHistoryEncodedString1);
        //accessData(sampleJson1);     
    }



    public void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string objectkey = (string)obj.keys[i];
                    JSONObject sampleJson1 = (JSONObject)obj.list[i];
                    //Debug.Log(key);
                    accessData(sampleJson1);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject sampleJson1 in obj.list)
                {
                    accessData(sampleJson1);
                }
                break;
            case JSONObject.Type.STRING:
                //Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                //Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                //Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                //Debug.Log("NULL");
                break;
        }
    }

}
