using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using TMPro;

public class ScenarioController : MonoBehaviour
{

    Action<string> _createItemsCallback;
    public TMP_Text scenarioName;
    public TMP_Text predStartCount;
    public TMP_Text preyStartCount;
    public TMP_Text foodStartAmount;
    public TMP_Text overallHungerRate;
    public TMP_Text foodGenRate;
    public TMP_Text predatorType;
    public TMP_Text preyType;

    public TMP_InputField idInput;
    public string thingy;

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

   /* public void CreateItems()
    {
        string userid = Main.Instance.userInfo.userID;
        StartCoroutine(Main.Instance.web.GetItemsIDs(userid, _createItemsCallback));
    } */

    IEnumerator DisplayScenarioRoutine(string jsonArraystring)
    {
        JSONArray jsonArray = JSON.Parse(jsonArraystring) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            //string scenarioId = jsonArray[i].AsObject["scenarioID"];
            string id = jsonArray[i].AsObject["ID"]; ;

            JSONObject itemInfoJson = new JSONObject();

            // Create a callback to get info from web.cs
            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(Main.Instance.web.GetScenario(id, getItemInfoCallback));

            //Wait until the callback is called from WEB
            yield return new WaitUntil(() => isDone == true);

            /*Instantiate Gameobject
            GameObject itemGo = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
            Item item = itemGo.AddComponent<Item>(); 

            item.ID = id;
            item.ItemID = itemId;

            itemGo.transform.SetParent(this.transform);
            itemGo.transform.localScale = Vector3.one;
            itemGo.transform.localPosition = Vector3.zero; */

            //Fill Information
            scenarioName.text = "Scenario Name: " + itemInfoJson["Name"];
            predStartCount.text = itemInfoJson["PredatorStartCount"];
            preyStartCount.text = itemInfoJson["PreyStartCount"];
            foodStartAmount.text = itemInfoJson["FoodStartAmount"];
            overallHungerRate.text = itemInfoJson["OverallHungerRate"];
            foodGenRate.text = itemInfoJson["FoodGenRate"];
            predatorType.text = itemInfoJson["PredatorType"];
            preyType.text = itemInfoJson["PreyType"];


            /* Create a callback to get SPrite from web.cs
            Action<Sprite> getItemIconCallback = (downloadedSprite) => {
                itemGo.transform.Find("Image").GetComponent<Image>().sprite = downloadedSprite;
            };
            StartCoroutine(Main.Instance.web.GetItemIcon(itemId, getItemIconCallback));

            //Set Sell Button
            itemGo.transform.Find("SellButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                string idInInventory = id;
                string iId = itemId;
                string userId = Main.Instance.userInfo.userID;

                StartCoroutine(Main.Instance.web.SellItem(idInInventory, iId, userId));
            });
            */
        }

        yield return null;
    }

    public void TestGetInfo()
    {
        StartCoroutine(Main.Instance.web.GetInfo());
        StartCoroutine(Main.Instance.web.GetScenarioRow(1));
    }



}
