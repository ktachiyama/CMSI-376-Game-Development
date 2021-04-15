using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int currLevel = 2;
    private int numLives;
    private int numLevelsTotal;
    private List<Actor> actorsList = new List<Actor>();
    //private bool isPaused;

    public const int MAX_NUM_LIVES = 3;
    public const int DEATH_HEIGHT = -20;
    

    void Start()
    {
        //isPaused = false;
        numLives = MAX_NUM_LIVES;
        numLevelsTotal = SceneManager.sceneCountInBuildSettings;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        isPaused = !isPaused;
    //        Pause();
    //    }
    //}

    public void init()
    {
        Debug.Log("init");
        currLevel = SceneManager.GetActiveScene().buildIndex;
    }

    //public void PauseGame()
    //{

    //} 

    public void addActor(Actor a)
    {
        actorsList.Add(a);
        foreach(Actor act in actorsList)
        {
            Debug.Log("actor in list");
        }
    }

    public int getNumLives()
    {
        return numLives;
    }

    public int getCurrLevel()
    {
        return currLevel;
    }

    public void Ouch()
    {
        numLives--;
        Debug.Log("ouch, you now have " + numLives + " lives.");
        if (numLives <= 0)
        {
            Die();
        }
    }

    public void resetAllActorPositions()
    {  
        foreach (Actor actor in actorsList)
        {
            if (actor != null && actor.canRespawn == true)
            {
                actor.ResetPosition();
            }
        }

    }

    public void AhhhIFell()
    {
        numLives--;
        Debug.Log("ouch, you now have " + numLives + " lives.");
        if (numLives > 0)
        {
            //SceneManager.LoadScene(currLevel);
            resetAllActorPositions();
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        numLives = MAX_NUM_LIVES;
        SceneManager.LoadScene(0);
    }

    public void gainLife()
    {
        if(numLives < MAX_NUM_LIVES)
        {
            numLives++;
            Debug.Log("you gained a life and now have " + numLives + " lives");
            
        }
    }

    public void loadNextLevel()
    {
        currLevel++;
        if (currLevel < numLevelsTotal)
        {
            Debug.Log("total levels: " + numLevelsTotal);
            SceneManager.LoadScene(currLevel);
        }
        else
        {
           SceneManager.LoadScene("YouWin");
        }
    }

}
