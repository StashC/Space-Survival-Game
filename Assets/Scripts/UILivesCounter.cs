using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
public class UILivesCounter : MonoBehaviour {

    private Text livesText;

    private void Awake()
    {
        livesText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        livesText.text = "Lives: " + GameMaster.remainingLives.ToString();
	}
}
