using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassedLevel : MonoBehaviour
{
    public void NextLevel()
    {
        GameManager.Instance.loadNextLevel();

    }

    public void Repay()
    {
        SceneManager.LoadScene(GameManager.Instance.getCurrLevel());
        //GameManager.Instance.resetAllActorPositions();
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
  