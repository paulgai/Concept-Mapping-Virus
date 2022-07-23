using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GV : MonoBehaviour
{
    public GameObject Congrats;
    public GameObject[] Propositions;
    public int[] CorrectsArray;
    public string[] Texts;
    //public GameObject Proposition2;
    //public GameObject Proposition3;
    public GameObject RestartBtn;
    private int correct;
    private int currentIndex = 0;
    public int Correct
    {
        get { return correct; }
        set
        {
            correct = value;
            Debug.Log("correct: " + correct);
            if (correct == CorrectsArray[currentIndex]) 
            {
                if (currentIndex < CorrectsArray.Length - 1)
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = Propositions[currentIndex];
                    Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = Texts[currentIndex];
                    currentIndex++;
                    Congrats.SetActive(true);
                }
                else 
                {
                    Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = RestartBtn;
                    Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = Texts[currentIndex];
                    Congrats.transform.GetChild(0).GetComponent<Content>().RestartButton.SetActive(true);
                    Congrats.SetActive(true);
                }
               
            }

            /*if (correct == 2)
            {
                Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = Proposition2;
                Congrats.SetActive(true);
                //Proposition2.SetActive(true);
            }
            else if (correct == 4)
            {
                Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = Proposition3;
                Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = "Συνέχισε στην τελευταία πρόταση";
                Congrats.SetActive(true);
            }
            else if (correct == 6)
            {
                Congrats.transform.GetChild(0).GetComponent<Content>().NextProposition = RestartBtn;
                Congrats.transform.GetChild(0).GetComponent<Content>().ButtonText.GetComponent<TextMeshProUGUI>().text = "Δες τις προτάσεις";
                Congrats.transform.GetChild(0).GetComponent<Content>().RestartButton.SetActive(true);
                Congrats.SetActive(true);
            }*/
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
