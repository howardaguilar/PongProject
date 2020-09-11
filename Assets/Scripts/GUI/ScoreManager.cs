using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "The current score is " + counter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCount()
    {
        counter++;
        //score.text = "The current score is <size=100%>" + counter + "</size> Test";
        //score.text = string.Format("The current score is {0}{1}</size> Hooray", DetermineSizeOfFont(), counter);
        //score.text = $"The current score is {DetermineSizeOfFont()}{counter}</size> Hooray";
        string first = SomeCoolJuiciness().Item1;
        string second = SomeCoolJuiciness().Item2;
        score.text = $"The current score is {first}{counter}</size> Hooray";
    }

    private string DetermineSizeOfFont() //SomeCoolJuiciness()
    {
        string returnText = (counter > 5) ? "<size=20%>" : "<size=18%>";
        return returnText;
    }

    private (string, string) SomeCoolJuiciness()
    {
        //string returnText1 = (counter > 5) ? "<size=20%>" : "<size=18%>";
        string returnText2 = "size";

        string returnText1 = (counter > 5) ? "<color=red>" : "<color=blue>";

        return (returnText1, returnText2);
    }
}
