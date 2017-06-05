using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{ 
    private float fillAmount;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }
    public float Value
    {
        set
        {
            fillAmount = Map(value, MaxValue);
        }
    }

	void Start ()
    {
	}
	
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (content.fillAmount != fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, (Time.deltaTime * lerpSpeed));
        }
    }

    private float Map(float value, float inMax)
    {
        return value / inMax;
    }
}