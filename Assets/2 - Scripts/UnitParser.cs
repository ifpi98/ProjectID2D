using UnityEngine;
using System.Collections;
using System.IO;

public class UnitParser : MonoBehaviour
{
    string path;
    public string[] _unitData;
    string[] sourceUnit;
    string[] _tempUD;
    public string[,] _tempUD2 = new string[400, 20];


    void Start()
    {

        TextAsset _unitData0 = (TextAsset)Resources.Load("Datas/DataUnit");
        StringReader sr = new StringReader(_unitData0.text);

        sourceUnit = new string[400];

        for (int i = 0; i < 400; i++)
        {
            sourceUnit[i] = sr.ReadLine();
            if (sourceUnit[i] == null)
            {
                break;
            }
            //Debug.Log(source1[i]);
        }

        Parse();
        
    }

    public void Parse()
    {
        _unitData = new string[349];



        for (int i = 0; i < sourceUnit.Length; i++)
        {
            if (sourceUnit[i] == null)
            {
                break;
            }

            _unitData[i] = sourceUnit[i];

            string source = sourceUnit[i];
            _tempUD = source.Split(',');
            //Debug.Log(_tempCD[0]);

            for (int y = 0; y < _tempUD.Length; y++)
            {
                _tempUD2[i, y] = _tempUD[y];
            }

        }

    }



}