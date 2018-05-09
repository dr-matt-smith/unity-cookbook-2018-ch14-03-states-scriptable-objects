using UnityEngine;
using UnityEngine.UI;


public class MyGameManager : MonoBehaviour 
{
    public Text textCurrentState;
    public Text textStarsCollected;
    public Text textSecondsLeft;

    public float secondsLeft = 10;
    public int totalStarsToBeCollected = 2;
    private int starsColleted = 0;

    // extra health feature
    public Text textHealth;
    private float health = 1;

	void Update()
	{
        // extra feature
        RandomlyChangeHealth();

        secondsLeft -= Time.deltaTime;
        UpdateDisplays();
	}

	public void DisplayCurrentState(State currentState)
    {
        textCurrentState.text = currentState.name;
    }

    public bool HasCollectedAllStars()
    {
        return (starsColleted == totalStarsToBeCollected);
    }

    public float GetTimeRemaining()
    {
        return secondsLeft;
    }

    public void BUTTON_ACTION_PickupOneStar()
    {
        starsColleted++;
    }

    private void UpdateDisplays()
    {
        textStarsCollected.text = "stars = " + starsColleted;
        textSecondsLeft.text = "time left = " + secondsLeft;

        // extra freature
        textHealth.text = "health = " + health;
    }

    // extra freature
    public float GetHealth()
    {
        return health;
    }

    // health can't go below 0 or above 1
    private void RandomlyChangeHealth()
    {
        float healthChange = Random.Range(-0.5f, 0.5f);
        health += healthChange;
        health = Mathf.Clamp(health, 0, 1);
    }

}
