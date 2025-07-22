using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMemberSelection : MonoBehaviour
{
    public GameObject InitialCrewSelection;
    public GameObject CrewOne;
    public GameObject CrewTwo;
    public GameObject CrewThree;
    public GameObject CrewFour;

    public void WhenButtonClickedOne()
    {
        if (InitialCrewSelection.activeInHierarchy == true)
        {
            InitialCrewSelection.SetActive(false);
            CrewOne.SetActive(true);
        }
    }

    public void WhenButtonClickedTwo()
    {
        if (InitialCrewSelection.activeInHierarchy == true)
        {
            InitialCrewSelection.SetActive(false);
            CrewTwo.SetActive(true);
        }
    }

    public void WhenButtonClickedThree()
    {
        if (InitialCrewSelection.activeInHierarchy == true)
        {
            InitialCrewSelection.SetActive(false);
            CrewThree.SetActive(true);
        }
    }

    public void WhenButtonClickedFour()
    {
        if (InitialCrewSelection.activeInHierarchy == true)
        {
            InitialCrewSelection.SetActive(false);
            CrewFour.SetActive(true);
        }
    }
}
