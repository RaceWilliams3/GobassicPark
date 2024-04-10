using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateNewEvent : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_InputField predStartCountInput;
    public TMP_InputField preyStartCountInput;
    public TMP_InputField foodStartAmountInput;
    public TMP_InputField hungerRateInput;
    public TMP_InputField foodGenRateInput;
    public TMP_InputField predTypeInput;
    public TMP_InputField preyTypeInput;
    public Button button;

    public void CreateScenario()
    {
        if (NameInput.text != null && predStartCountInput.text != null && preyStartCountInput.text != null && foodStartAmountInput.text != null && hungerRateInput.text != null && foodGenRateInput.text != null && predTypeInput.text != null && preyTypeInput.text != null)
        {
            StartCoroutine(Main.Instance.web.CreateScenario(NameInput.text, predStartCountInput.text, preyStartCountInput.text, foodStartAmountInput.text, hungerRateInput.text, foodGenRateInput.text, predTypeInput.text, preyTypeInput.text));
            //log.login.SetActive(true);
            //log.reg.SetActive(false);
            Debug.Log("Scenario Created!");
        }
        else
        {
            Debug.Log("wrong!");
        }
    }
}
