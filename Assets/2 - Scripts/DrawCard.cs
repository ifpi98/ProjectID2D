using UnityEngine;
using System.Collections;

public class DrawCard : MonoBehaviour {

    Game game;
    Monster mon;
    GameCanvasGui gCanvas;

    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
