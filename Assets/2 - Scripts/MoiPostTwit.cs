using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoiPostTwit : MonoBehaviour {

    //Button TwitterShareButton;
    EasyTween easyTweenPostTwitPopUp;
    EasyTween easyTweenTwitterAuthPopUp;
    Text pinNumber;
    MOITwitter moiTwitter;

    // Use this for initialization
    void Start () {

        //TwitterShareButton = GameObject.Find("TwitterShareButton").GetComponent<Button>();
        easyTweenPostTwitPopUp = GameObject.Find("PopUpButtonAnim").GetComponent<EasyTween>();
        easyTweenTwitterAuthPopUp = GameObject.Find("TwitterAuthAnim").GetComponent<EasyTween>();
        pinNumber = GameObject.Find("PinNumber").GetComponent<Text>();
        moiTwitter = GameObject.Find("TwitterObj").GetComponent<MOITwitter>();
    }

    public void shareTwit()
    {
        if (string.IsNullOrEmpty(moiTwitter.twitterUserIdForCheck))
        {
            easyTweenPostTwitPopUp.OpenCloseObjectAnimation();
            easyTweenTwitterAuthPopUp.OpenCloseObjectAnimation();
            moiTwitter.AuthTwitterFirst();
        }
        else
        {
            easyTweenPostTwitPopUp.OpenCloseObjectAnimation();
            moiTwitter.PostMadeTweet();
        }        
    }

    public void enterPinNumber()
    {
        moiTwitter.AuthTwitterPinEnter(pinNumber.text);        
    }


	
	// Update is called once per frame
	void Update () {
	
	}
}
