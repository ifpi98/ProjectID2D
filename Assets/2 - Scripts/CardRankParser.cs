using UnityEngine;
using System.IO;


public class CardRankParser : MonoBehaviour
{    
    public string[] _cardRankData;
    string[] sourceCardRank;
    string[] _tempCRD;
    public string[,] _tempCRD2 = new string[200, 15];

    void Start()
    {

        
        TextAsset _cardRankData0 = (TextAsset)Resources.Load("Datas/DataCardRank");
        StringReader sr = new StringReader(_cardRankData0.text);

        sourceCardRank = new string[200];
        
        for (int i = 0; i < 200; i++)
        {
            sourceCardRank[i] = sr.ReadLine();
            if (sourceCardRank[i] == null)
            {
                break;
            }
            //Debug.Log(source1[i]);
        }
        
        Parse();
         

    }

    public void Parse()
    {

        _cardRankData = new string[5];

  
        for (int i = 0; i < sourceCardRank.Length; i++)
        {
            if (sourceCardRank[i] == null)
            {
                break;
            }

            _cardRankData[i] = sourceCardRank[i];

            string source = sourceCardRank[i];
            _tempCRD = source.Split(',');
            //Debug.Log(_tempCD[0]);

            for (int y = 0; y < _tempCRD.Length; y++)
            {
                _tempCRD2[i, y] = _tempCRD[y];
            }

        }

    }
}