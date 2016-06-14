using UnityEngine;
using System.Collections;
using System.IO;

public class ExpLvParser : MonoBehaviour
{    
    public string[] _expLvData;
    string[] sourceExpLv;
    string[] _tempED;
    public string[,] _tempED2 = new string[200, 15];


    void Start()
    {

        TextAsset _expLvData0 = (TextAsset)Resources.Load("Datas/DataExpLv");
        StringReader sr = new StringReader(_expLvData0.text);

        sourceExpLv = new string[200];

        for (int i = 0; i < 200; i++)
        {
            sourceExpLv[i] = sr.ReadLine();
            if (sourceExpLv[i] == null)
            {
                break;
            }
            //Debug.Log(source1[i]);
        }

        Parse();

    }

    public void Parse()
    {
        _expLvData = new string[101];

        for (int i = 0; i < sourceExpLv.Length; i++)
        {
            if (sourceExpLv[i] == null)
            {
                break;
            }

            //_expLvData[i] = sourceExpLv[i];

            string source = sourceExpLv[i];
            _tempED = source.Split(',');
            //Debug.Log(_tempCD[0]);

            for (int y = 0; y < _tempED.Length; y++)
            {
                _tempED2[i, y] = _tempED[y];
            }

        }

    }



}