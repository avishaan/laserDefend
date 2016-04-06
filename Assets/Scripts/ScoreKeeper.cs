using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int score = 0;
    private Text myText;

    void Start()
    {
		// get text from current game object
        myText = GetComponent<Text>();
    }

    public void Score(int points)
    {
        score += points;
        myText.text = score.ToString();
    }

    public void Reset()
	{
        score = 0;
        myText.text = score.ToString();
    }
}
