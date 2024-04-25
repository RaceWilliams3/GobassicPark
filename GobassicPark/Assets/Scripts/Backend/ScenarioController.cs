using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using TMPro;

public class ScenarioController : MonoBehaviour
{

    public TMP_InputField idInput;
    public string thingy;
    public Scenario selectedScenario;
    public TMP_Text viewText;

    public void OnViewScenarioButtonPressed()
    {


        StartCoroutine(Main.Instance.web.GetInfo());

        if (idInput.text == null)
        {
            Debug.Log("Error! No ID Entered");
        }
        else
        {
            /*
            _createItemsCallback = (jsonArray) => {
                StartCoroutine(DisplayScenarioRoutine(jsonArray));
            }; */
        }
    }

    public void TestGetInfo()
    {
        StartCoroutine(Main.Instance.web.GetInfo());
        if (idInput.text == null)
        {
            Debug.Log("Error! No ID Entered");
        }
        else
        {
            int index;
            int.TryParse(idInput.text, out index);
            StartCoroutine(Main.Instance.web.GetScenarioRow(index));
            Invoke("FillViewedScenario", 1.25f);
        }
    }

    public void FillViewedScenario()
    {
        viewText.text = "ID: " + selectedScenario.ID.ToString() + "\n" + "Name: " + selectedScenario.Name + "\n" + "Predator Start Count: " + selectedScenario.PredatorStartCount.ToString() + "\n" + "Prey Start Count: " + selectedScenario.PreyStartCount.ToString() + "\n" + "Food Start Amount: " + selectedScenario.FoodStartAmount.ToString() + "\n" + "Overall Hunger Rate: " + selectedScenario.OverallHungerRate.ToString() + "\n" + "Food Gen Rate: " + selectedScenario.FoodGenRate.ToString();
    }



    public void UnpackJsonArray(string array)
    {
        selectedScenario = JsonUtility.FromJson<Scenario>(array);
        Debug.Log(selectedScenario.ID);
    }


}
