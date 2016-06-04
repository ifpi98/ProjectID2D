using UnityEngine;
using System.Collections;
using System.IO;

public class LocalizationParser : MonoBehaviour
{
    //string path;
    public string[] _localizationData;
    string[] sourceLocalization;
    string[] _tempLD;
    public string[,] _tempLD2 = new string[400, 15];

    void Start()
    {

        TextAsset _locData0 = (TextAsset)Resources.Load("Datas/DataLocalization");
        StringReader sr = new StringReader(_locData0.text);

        sourceLocalization = new string[400];

        for (int i = 0; i < 400; i++)
        {
            sourceLocalization[i] = sr.ReadLine();
            if (sourceLocalization[i] == null)
            {
                break;
            }
            //Debug.Log(source1[i]);
        }

        Parse();


    }

    public void Parse()
    {
        _localizationData = new string[252];


        for (int i = 0; i < sourceLocalization.Length; i++)
        {
            if (sourceLocalization[i] == null)
            {
                break;
            }

            _localizationData[i] = sourceLocalization[i];

            string source = sourceLocalization[i];
            _tempLD = source.Split(',');
            //Debug.Log(_tempCD[0]);

            for (int y = 0; y < _tempLD.Length; y++)
            {
                _tempLD2[i, y] = _tempLD[y];
            }

        }

    }


}







