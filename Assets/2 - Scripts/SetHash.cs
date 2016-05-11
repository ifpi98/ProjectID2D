using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class SetHash : MonoBehaviour {

//    public string[,] charData2 = new string[200, 15];
//    public int charDataCount;
//    public string[,] unitData2 = new string[200, 15];
//    public int unitDataCount;
//    public string[,] localizationData2 = new string[400, 15];
//    public int locDataCount;
//    bool firstcheck = false;
       
//    void Start()
//    {
//        charDataCount = 69;
//        unitDataCount = 116;
//        locDataCount = 252;
//        SetUnitData();
//        SetCharData();
//        SetLocalizationData();
//    }

//    void Update()
//    {
//        if (firstcheck == false)
//        {
//            SetCharHash();
//            firstcheck = true;
//        }
        
//    }

//// No duplicate entries
//    void SetCharHash()
//    {
     
//        StringBuilder str = new StringBuilder();

//        //Debug.Log(charData2[2, 1]);
//        for (int i = 1; i < charDataCount; i++)
//        {
//            str.Append("charHash" + charData2[i, 0]);
//            //Debug.Log(str.ToString());
//            str = new StringBuilder();
//        }

//        ////CharHash charData2[2, 1] = new CharHash((int)charData2[2, 1], charData2[2, 2], charData2[2, 3], charData2[2, 4], charData2[2, 5]);

//        CharHash char1 = new CharHash(1, "A", "B", "C", "D");
//        CharHash char2 = new CharHash(2, "A", "B", "C", "E");
//        CharHash char3 = new CharHash(3, "A", "B", "D", "E");


//        HashSet<CharHash> char_list = new HashSet<CharHash>();
//        char_list.Add(char1);
//        char_list.Add(char2);
//        char_list.Add(char3);

//        bool contain = char_list.Contains(char1);
//        Debug.Log(contain.ToString());


//    }




//    public class CharHash
//    {
//        public int charID;
//        public string charName;
//        public string voiceActor;
//        public string resourceFile;
//        public string icon;
//        public CharHash(int _charID, string _charName, string _voiceActor, string _resourceFile, string _icon)
//        {
//            charID = _charID;
//            charName = _charName;
//            voiceActor = _voiceActor;
//            resourceFile = _resourceFile;
//            icon = _icon;
//        }
//    }

   
//    void SetCharData()
//    {
//        CharParser char1 = this.GetComponent<CharParser>();
//        charData2 = char1._tempCD2;
//        //Debug.Log(charDataCount);
//    }

//    void SetUnitData()
//    {
//        UnitParser unit1 = this.GetComponent<UnitParser>();
//        unitData2 = unit1._tempUD2;
//        //Debug.Log(unitData2[5, 12]);
//    }
//    void SetLocalizationData()
//    {
//        LocalizationParser localization1 = this.GetComponent<LocalizationParser>();
//        localizationData2 = localization1._tempLD2;
//        //Debug.Log(localizationData2[5,5]);
//    }




}


