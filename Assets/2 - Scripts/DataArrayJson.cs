using UnityEngine;


public class DataArrayJson : MonoBehaviour {

    public JSONObject unitDearDegreeObj = new JSONObject(JSONObject.Type.OBJECT);
    public JSONObject unitDearDegreeArray = new JSONObject(JSONObject.Type.ARRAY);
    public string DearDegreeEncodedString1;



    // Use this for initialization
    void Start () {

        //unitDearDegreeObj.AddField("field1", 0.5f);
        //unitDearDegreeObj.AddField("field2", "sampletext");
        unitDearDegreeObj.AddField("field1", unitDearDegreeArray);

        unitDearDegreeArray.Add(1);
        unitDearDegreeArray.Add(2);
        unitDearDegreeArray.Add(3);

        DearDegreeEncodedString1 = unitDearDegreeObj.Print();
        //Debug.Log(DearDegreeEncodedString1);

        JSONObject sampleJson1 = new JSONObject(DearDegreeEncodedString1);
        accessData(sampleJson1);

    }
	
    // Update is called once per frame
	void Update () {
	
	}

    void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject sampleJson1 = (JSONObject)obj.list[i];
                    Debug.Log(key);
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
                Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;
        }
    }

}
