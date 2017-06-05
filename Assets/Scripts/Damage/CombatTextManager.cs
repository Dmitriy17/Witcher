    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
    private static CombatTextManager combatTM;
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    private RectTransform canvasTransform;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private Vector3 direction;
    public static CombatTextManager CombatTM
    {
        get
        {
            if (combatTM == null)
            {
                combatTM = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return combatTM; 
        }
    }

    public void CreatText(Vector3 position, string text, Color color)
    {
        GameObject sct = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.GetComponent<CombatText>().Initialize(speed, direction, fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
    }
}