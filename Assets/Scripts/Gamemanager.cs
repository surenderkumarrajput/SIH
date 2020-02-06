using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public List<Questions> question = new List<Questions>();
    public TextMeshProUGUI questionobject;
    [HideInInspector]
    public int index = 0;
    [HideInInspector]
    public int countmanager = 0;
    public Image image;
    public List<TextMeshProUGUI> answers = new List<TextMeshProUGUI>();
    public GameObject correct, wrong,FinalPanel;
    public TextMeshProUGUI Score, FinalPanelscore,Correctanswer;
    void Start()
    {
        StartCoroutine(display());
        FinalPanel.SetActive(false);
    }
    IEnumerator display()
    {
        for (int i = 0; i < question.Count; i++)
        {
            questionobject.text = "Q " + (index+1) + " . " + question[index].questions;
        }
        for (int i = 0; i < question[index].answers.Length; i++)
        {
            answers[i].text = (i+1)+" . "+question[index].answers[i];
        }
            yield return null;

    }
    public void increaseindex()
    {
        if (index<question.Count-1)
        {
            index++;
            questionobject.text = "";
            for (int i = 0; i < question[index].answers.Length; i++)
            {
                answers[i].text = "";
            }
            StartCoroutine(display());
        }
        else
        {
            questionobject.text = "";
            for (int i = 0; i < question[index].answers.Length; i++)
            {
                answers[i].text = "";
            }
            FinalPanel.SetActive(true);
        }
    }
    public void onclick(int count)
        {
        StartCoroutine(correctFunction(count));
        FindObjectOfType<AudioManager>().Play("Click");
        }
    IEnumerator correctFunction(int ind)
        {
            if (ind == question[index].rightanswer)
            {
             correct.SetActive(true);
            image.sprite = question[index].image;
             countmanager++;
            }
            else
            {
                wrong.SetActive(true);
                Correctanswer.text = "Correct Answer -- "+question[index].answers[question[index].rightanswer];
            }
            yield return new WaitForSeconds(2f);
            increaseindex();
            correct.SetActive(false);
            wrong.SetActive(false);
    }
        public void scenechange(string scenename)
        {
          FindObjectOfType<AudioManager>().Play("Click");
          SceneManager.LoadScene(scenename);
        }
    void Update()
    {
        Score.text = "SCORE - "+countmanager.ToString()+" / "+question.Count;
        FinalPanelscore.text = "SCORE - " + countmanager.ToString() + " / " + question.Count;
    }
}
