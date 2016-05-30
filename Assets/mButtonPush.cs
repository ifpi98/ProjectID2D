using UnityEngine;
using System.Collections;

public class mButtonPush : MonoBehaviour {

    GameCanvasGui gameCanvasGui;
    Game game;

    // Use this for initialization
    void Start () {

        gameCanvasGui = this.transform.GetComponent<GameCanvasGui>();
        game = GameObject.Find("GameObj").GetComponent<Game>();

        if (game.remainturncardslot[0] == 0)
        {
            game.checkremainTurncardslot[0] = !game.checkremainTurncardslot[0];            
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
