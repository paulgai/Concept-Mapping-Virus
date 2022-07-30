using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GV : MonoBehaviour
{
    public enum Language { GR, EN };

    public Language language;
    public GameObject Congrats;
    public GameObject[] Propositions;
    public int[] CorrectsArray;
    public string[] TextsGR;
    public string[] TextsEN;
    public GameObject RestartBtn;
    private int correct;
    private int currentIndex = 0;
    public int Correct
    {
        get { return correct; }
        set
        {
            correct = value;
            //Debug.Log("correct: " + correct);
            if (correct == CorrectsArray[currentIndex]) 
            {
                if (language == Language.GR)
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = TextsGR[currentIndex];
                }
                else if (language == Language.EN)
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = TextsEN[currentIndex];
                }
                
                if (currentIndex < CorrectsArray.Length - 1)
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = Propositions[currentIndex];
                    currentIndex++; 
                }
                else 
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = RestartBtn;
                    Congrats.transform.GetChild(0).GetComponent<Content>().RestartButton.SetActive(true);
                }

                Congrats.SetActive(true);
            }
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
