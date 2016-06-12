using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoiPostTwit : MonoBehaviour {

    Button TwitterShareButton;
    EasyTween easyTweenPostTwitPopUp;
    MOITwitter moiTwitter;

    // Use this for initialization
    void Start () {

        TwitterShareButton = GameObject.Find("TwitterShareButton").GetComponent<Button>();
        easyTweenPostTwitPopUp = GameObject.Find("PopUpButtonAnim").GetComponent<EasyTween>();
        moiTwitter = GameObject.Find("TwitterObj").GetComponent<MOITwitter>();
    }

    public void shareTwit()
    {
        easyTweenPostTwitPopUp.OpenCloseObjectAnimation();
        moiTwitter.PostMadeTweet();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
