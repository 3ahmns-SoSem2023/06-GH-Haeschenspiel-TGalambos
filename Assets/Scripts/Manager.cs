using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Manager : MonoBehaviour
{
    /*
    - button -> würfel => random color 
    - if color ist currentPlayer -> +1 Punkt für currentPlayer, destroy 1 box with the color, next player
    - if color ist black -> -1 Punkt für currentPlayer, instatite 1 box with currentPlayer color, next player
    - if color ist green -> +2 Punkte für currentPlayer, destroy 1 green box, next player
    - if scoreCount von currentPlayer = 10 -> text = "currentPlayer hat gewonnen!"
    */

    public Text redScoreText;
    public Text whiteScoreText;
    public Text blueScoreText;
    public Text yellowScoreText;

    /*
    -> white = 0
    -> yellow = 1
    -> red = 2
    -> blue = 3
    -> green = 4
    -> black = 5
    */

    public Image wuerfel;
    public Image roundIndicator;
    public Text winnerText;
    public GameObject winnerCanvas;
    private MeshRenderer activeingWhiteBox;
    private MeshRenderer activeingYellowBox;
    private MeshRenderer activeingRedBox;
    private MeshRenderer activeingBlueBox;

    private int roundCount;
    private int currentPlayer;
    private int whiteScore;
    private int yellowScore;
    private int redScore;
    private int blueScore; 

    void Start()
    {
        winnerCanvas.SetActive(false);
    }

    void Update()
    {
        //-------------------Rundensystem-----------------------
        if (roundCount == 4)
        {
            roundCount = 0;
        }

        currentPlayer = roundCount;

        if (currentPlayer == 0)
        {
            roundIndicator.GetComponent<RectTransform>().anchoredPosition = new Vector3(-725f, 433f, 0f);
        }

        if (currentPlayer== 1)
        {
            roundIndicator.GetComponent<RectTransform>().anchoredPosition = new Vector3(680f, 433f, 0f);
        }

        if (currentPlayer == 2)
        {
            roundIndicator.GetComponent<RectTransform>().anchoredPosition = new Vector3(680f, -398f, 0f);
        }

        if (currentPlayer == 3)
        {
            roundIndicator.GetComponent<RectTransform>().anchoredPosition = new Vector3(-725f, -398f, 0f);
        }
        //------------------------------------------------------

        //-------------------PunktezahlCounter------------------
            whiteScoreText.text = whiteScore + " / 10";
            yellowScoreText.text = yellowScore + " / 10";
            redScoreText.text = redScore + " / 10";
            blueScoreText.text = blueScore + " / 10";
        
        if (whiteScore >= 10)
        {
            winnerCanvas.SetActive(true); 
            winnerText.text = "White-Rabbit wins!"; 
        }

        if (yellowScore >= 10)
        {
            winnerCanvas.SetActive(true);
            winnerText.text = "Yellow-Rabbit wins!";
        }

        if (redScore >= 10)
        {
            winnerCanvas.SetActive(true);
            winnerText.text = "Red-Rabbit wins!";
        }

        if (blueScore >= 10)
        {
            winnerCanvas.SetActive(true);
            winnerText.text = "Blue-Rabbit wins!";
        }
        //------------------------------------------------------

        activeingWhiteBox = GameObject.FindGameObjectWithTag("whiteBox").GetComponent<MeshRenderer>();
        activeingYellowBox = GameObject.FindGameObjectWithTag("yellowBox").GetComponent<MeshRenderer>();
        activeingRedBox = GameObject.FindGameObjectWithTag("redBox").GetComponent<MeshRenderer>();
        activeingBlueBox = GameObject.FindGameObjectWithTag("blueBox").GetComponent<MeshRenderer>();
    }

    public void RollDice()
    {
        roundCount++;
        //Debug.Log(roundCount);
        int wuerfelNumber = Random.Range(0, 6);

        //-------------------Farbzuteilung----------------------
        if (wuerfelNumber == 0)
        {
            wuerfel.color = Color.white;
        }

        if (wuerfelNumber == 1)
        {
            wuerfel.color = Color.yellow;
        }

        if (wuerfelNumber == 2)
        {
            wuerfel.color = Color.red;
        }

        if (wuerfelNumber == 3)
        {
            wuerfel.color = Color.blue;
        }

        if (wuerfelNumber == 4)
        {
            wuerfel.color = Color.green;
        }

        if (wuerfelNumber == 5)
        {
            wuerfel.color = Color.black;
        }
        //------------------------------------------------------

        //-------------------Punktesystem-----------------------
        if (wuerfelNumber == currentPlayer)
        {
            if (currentPlayer == 0)
            {
                whiteScore++;
                activeingWhiteBox.enabled = false;
            }

            if (currentPlayer == 1)
            {
                yellowScore++;
                activeingYellowBox.enabled = false;
            }

            if (currentPlayer == 2)
            {
                redScore++;
                activeingRedBox.enabled = false;
            }

            if (currentPlayer == 3)
            {
                blueScore++;
                activeingBlueBox.enabled = false;
            }
            //Debug.Log("Punkt"); 
        }

        if (wuerfelNumber == 4)
        {
            if (currentPlayer == 0)
            {
                whiteScore += 2;
                for (int i = 0; i < 2; i++)
                {
                    activeingWhiteBox = GameObject.FindGameObjectWithTag("whiteBox").GetComponent<MeshRenderer>();
                    activeingWhiteBox.enabled = false;
                }
                GameObject.FindGameObjectWithTag("greenBox").SetActive(false);
            }

            if (currentPlayer == 1)
            {
                yellowScore += 2;
                for (int i = 0; i < 2; i++)
                {
                    activeingYellowBox = GameObject.FindGameObjectWithTag("yellowBox").GetComponent<MeshRenderer>();
                    activeingYellowBox.enabled = false;
                }
                GameObject.FindGameObjectWithTag("greenBox").SetActive(false);
            }

            if (currentPlayer == 2)
            {
                redScore += 2;
                for (int i = 0; i < 2; i++)
                {
                    activeingRedBox = GameObject.FindGameObjectWithTag("redBox").GetComponent<MeshRenderer>();
                    activeingRedBox.enabled = false;
                }
                GameObject.FindGameObjectWithTag("greenBox").SetActive(false);
            }

            if (currentPlayer == 3)
            {
                blueScore += 2 ;
                for (int i = 0; i < 2; i++)
                {
                    activeingBlueBox = GameObject.FindGameObjectWithTag("blueBox").GetComponent<MeshRenderer>();
                    activeingBlueBox.enabled = false;
                }
                GameObject.FindGameObjectWithTag("greenBox").SetActive(false);
            }
        }

        if (wuerfelNumber == 5)
        {
            if (currentPlayer == 0)
            {
                whiteScore -= 1;
                activeingWhiteBox.enabled = true;
            }
            
            if (currentPlayer == 1 && yellowScore >= 0)
            {
                yellowScore -= 1;
                activeingYellowBox.enabled = true;

            }

            if (currentPlayer == 2 && redScore >= 0)
            {
                redScore -= 1;
                activeingRedBox.enabled = true;

            }

            if (currentPlayer == 3 && blueScore >= 0)
            {
                blueScore -= 1;
                activeingBlueBox.enabled = true; 
                
            }
        }
        //------------------------------------------------------


    }

}
