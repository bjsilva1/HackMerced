using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VRHUDController : MonoBehaviour
{
    public TMP_Text scoreText;
    public Slider healthSlider;
    public TMP_Text newWave;

    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void setHealth(int health)
    {
        healthSlider.value = health;
    }

    public void showNextWave(int wave)
    {
        StartCoroutine(displayWave(wave));
    }

    private IEnumerator displayWave(int wave)
    {
        if (wave == 1)
        {
            newWave.text = "GAME START!";
            yield return new WaitForSeconds(3f);
            newWave.text = "WAVE 1";
            yield return new WaitForSeconds(4f);
        }
        else
        {
            newWave.text = "WAVE " + wave;
            yield return new WaitForSeconds(4f);
        }
        newWave.text = "";
    }
}
