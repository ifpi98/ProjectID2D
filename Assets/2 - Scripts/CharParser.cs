using UnityEngine;
using System.IO;


public class CharParser : MonoBehaviour
{    
    public string[] _charData;
    string[] sourceChar;
    string[] _tempCD;
    public string[,] _tempCD2 = new string[200, 15];

    void Start()
    {

        
        TextAsset _charData0 = (TextAsset)Resources.Load("Datas/DataChar");
        StringReader sr = new StringReader(_charData0.text);

        sourceChar = new string[200];
        
        for (int i = 0; i < 200; i++)
        {
            sourceChar[i] = sr.ReadLine();
            if (sourceChar[i] == null)
            {
                break;
            }
            //Debug.Log(source1[i]);
        }
        
        Parse();
         

    }

    public void Parse()
    {
        
        _charData = new string[95];

  
        for (int i = 0; i < sourceChar.Length; i++)
        {
            if (sourceChar[i] == null)
            {
                break;
            }

            _charData[i] = sourceChar[i];

            string source = sourceChar[i];
            _tempCD = source.Split(',');
            //Debug.Log(_tempCD[0]);

            for (int y = 0; y < _tempCD.Length; y++)
            {
                _tempCD2[i, y] = _tempCD[y];
            }

        }

    }
}