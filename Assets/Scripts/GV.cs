using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour
{
    public GameObject Proposition2;
    public GameObject Proposition3;
    private int correct;
    public int Correct
    {
        get { return correct; }
        set
        {
            correct = value;
            Debug.Log("correct: " + correct);
            if (correct == 2)
            {
                Proposition2.SetActive(true);
            }
            else if (correct == 4)
            {
                Proposition3.SetActive(true);
            }
        }
    }
}
