using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int counter = 0;
    private int player1 = 0;
    private int player2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        //score.text = "The current score is " + counter;
        score.text = "Game has begun!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pass in variable to determine whos score to increment
    public void IncrementCount(string who)
    {
        //counter++;
        //score.text = "The current score is <size=100%>" + counter + "</size> Test";
        //score.text = string.Format("The current score is {0}{1}</size> Hooray", DetermineSizeOfFont(), counter);
        //score.text = $"The current score is {DetermineSizeOfFont()}{counter}</size> Hooray";

        if (who == "player1")
        {
            player1++;
        }
        else if (who == "player2")
        {
            player2++;
        }
        
        score.text = "The current score is: " + Juicy(player1) + player1 + "</color>" + " - " + Juicy(player2) + player2 + "</color>";

        //string first = SomeCoolJuiciness().Item1;
        //string second = SomeCoolJuiciness().Item2;
        //score.text = $"The current score is {first}{counter}</size> Hooray";
    }

    // Change color of score depending on player score
    private string Juicy(int player)
    {
        string juiced = "";
        juiced = player.ToString();
        if (player < 2)
        {
            juiced = "<color=red>";
        }
        else if (player == 2)
        {
            juiced = "<color=blue>";
        }
        else if (player > 2)
        {
            juiced = "<color=green>";
        }

        return juiced;
    }

    /*
    private string DetermineSizeOfFont() //SomeCoolJuiciness()
    {
        string returnText = (counter > 5) ? "<size=20%>" : "<size=18%>";
        return returnText;
    }

    private (string, string) SomeCoolJuiciness()
    {
        //string returnText1 = (counter > 5) ? "<size=20%>" : "<size=18%>";
        string returnText2 = "size";
        //player1++;
        string returnText1 = (counter > 5) ? "<color=red>" : "<color=blue>";

        return (returnText1, returnText2);
    }*/


}
