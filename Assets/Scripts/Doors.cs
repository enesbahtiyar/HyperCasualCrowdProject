using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Doors : MonoBehaviour
{
    enum BonusType { Addition, Difference, Product, Division }

    [Header(" Elements ")]
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] TextMeshPro rightDoorText;
    [SerializeField] TextMeshPro leftDoorText;

    [Header(" Settings ")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rigthDoorBonusAmount;

    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorBonusAmount;

    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
    }

    void Update()
    {

    }


    private void ConfigureDoors()
    {
        //configure the right door


        switch(rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rigthDoorBonusAmount;
                break;

            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rigthDoorBonusAmount;
                break;

            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rigthDoorBonusAmount;
                break;

            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rigthDoorBonusAmount;
                break;
            default:
                break;
        }

        switch(leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
            default:
                break;
        }        
    }

}
