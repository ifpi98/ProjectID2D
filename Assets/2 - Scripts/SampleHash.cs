using UnityEngine;
using System.Collections;
using System.Text;
//using System.Collections.Generic;
//using UnityEngine.UI;

public class SampleHash : MonoBehaviour {

    //public Text textResult;

    void Start()
    {
        //SampleHashTable();
    }

    public void SampleHashTable()
    {
        Hashtable sampleHash = new Hashtable();
        sampleHash.Add("abc", 3);
        sampleHash.Add("bcd", 4);
        sampleHash.Add("cde", 5);

        StringBuilder str = new StringBuilder();

        foreach (DictionaryEntry item in sampleHash)
        {
            str.Append("Key: " + item.Key + " / Value : " + item.Value + "\n");
        }

        //Debug.Log(str.ToString());
        //textResult.text = str.ToString();
        
    }
    
}












    //"1", "abc", "bcd", "cdf", "def", "fef"
    //namespace ConsoleApplication36
    //{
    //  class Program
    // {
    //   static void Main(string[] args)
    //  {
    //    Hashtable table = new Hashtable();

    //table.Add("사과", "apple");
    //table.Add("토마토", "tomato");
    //table["감자"] = "potato";

    // foreach (object obj in table.Keys)
    //   Console.WriteLine("{0}: {1}", obj, table[obj]);
    // }
    // }



    //    HashMap hashmap = new HashMap();
    //  hashmap.put("jakarta", "project");
    // hashmap.put("apache", "tomcat");

    //    Set set = hashmap.entrySet();
    //  Iterator keys = set.iterator();

    // while (keys.hasNext())
    //{
    //   key = (String)keys.next();
    //  debug.log

    //  (hashmap.get(key));
    // }

