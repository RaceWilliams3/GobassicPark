using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using TMPro;
using Unity.VisualScripting;

public class ScenarioController : MonoBehaviour
{
    public GameObject SceneContainer;

    public string NameInput;
    public int predStartCountInput;
    public int preyStartCountInput;
    public int foodStartAmountInput;
    public int hungerRateInput;
    public int foodGenRateInput;
    public int predTypeInput;
    public int preyTypeInput;

    public TMP_InputField idInput;
    public string thingy;
    public Scenario selectedScenario;
    public TMP_Text viewText;

    public GameObject predator;
    public GameObject prey;
    public GameObject food;

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

    public void startScenario()
    {
        SceneContainer.SetActive(false);
        predStartCountInput = Int32.Parse(selectedScenario.PredatorStartCount.ToString());
        preyStartCountInput = Int32.Parse(selectedScenario.PreyStartCount.ToString());
        foodStartAmountInput = Int32.Parse(selectedScenario.FoodStartAmount.ToString());
        hungerRateInput = Int32.Parse(selectedScenario.OverallHungerRate.ToString());
        foodGenRateInput = Int32.Parse(selectedScenario.FoodGenRate.ToString());
        spawnGobs(predStartCountInput, preyStartCountInput, foodStartAmountInput, hungerRateInput, foodGenRateInput);
    }

    public void spawnGobs(int predNumber,int preyNumber, int foodAmount, int hungerRate, int foodGen)
    {
        print(predNumber + " Predators spawned");
        print(preyNumber + " Prey spawned");

        for (int i = 1; i<= predNumber; i++)
        {
            print("predator created");
            var position = new Vector3(UnityEngine.Random.Range(-18, 18), 1, UnityEngine.Random.Range(-18, 18));
            Instantiate(predator, position, Quaternion.identity);
        }

        for (int i = 1; i <= preyNumber; i++)
        {
            print("prey created");
            var position = new Vector3(UnityEngine.Random.Range(-18, 18), 1, UnityEngine.Random.Range(-18, 18));
            Instantiate(prey, position, Quaternion.identity);
        }

        for (int i = 1; i <= foodAmount; i++)
        {
            print("food created");
            var position = new Vector3(UnityEngine.Random.Range(-18, 18), 1, UnityEngine.Random.Range(-18, 18));
            Instantiate(food, position, Quaternion.identity);
        }

    }


    public void UnpackJsonArray(string array)
    {
        selectedScenario = JsonUtility.FromJson<Scenario>(array);
        Debug.Log(selectedScenario.ID);
    }


}
