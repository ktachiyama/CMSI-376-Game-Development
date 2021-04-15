using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite heartLife;
    public Image[] hearts;

    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
             if(i < GameManager.Instance.getNumLives())
            {
                hearts[i].sprite = heartLife;
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
        
    }
    
}
