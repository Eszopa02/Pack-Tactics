using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeselectVolumeButtons : MonoBehaviour
{
    public GameObject VolumeOneFull;
    public GameObject VolumeTwoFull;
    public GameObject VolumeThreeFull;
    public GameObject VolumeFourFull;
    public GameObject VolumeFiveFull;
    public GameObject VolumeSixFull;

    public GameObject VolumeOneEmpty;
    public GameObject VolumeTwoEmpty;
    public GameObject VolumeThreeEmpty;
    public GameObject VolumeFourEmpty;
    public GameObject VolumeFiveEmpty;
    public GameObject VolumeSixEmpty;

    public void VolumeOnePressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(false);
        VolumeThreeFull.SetActive(false);
        VolumeFourFull.SetActive(false);
        VolumeFiveFull.SetActive(false);
        VolumeSixFull.SetActive(false);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(true);
        VolumeThreeEmpty.SetActive(true);
        VolumeFourEmpty.SetActive(true);
        VolumeFiveEmpty.SetActive(true);
        VolumeSixEmpty.SetActive(true);
    }

    public void VolumeTwoPressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(true);
        VolumeThreeFull.SetActive(false);
        VolumeFourFull.SetActive(false);
        VolumeFiveFull.SetActive(false);
        VolumeSixFull.SetActive(false);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(false);
        VolumeThreeEmpty.SetActive(true);
        VolumeFourEmpty.SetActive(true);
        VolumeFiveEmpty.SetActive(true);
        VolumeSixEmpty.SetActive(true);
    }

    public void VolumeThreePressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(true);
        VolumeThreeFull.SetActive(true);
        VolumeFourFull.SetActive(false);
        VolumeFiveFull.SetActive(false);
        VolumeSixFull.SetActive(false);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(false);
        VolumeThreeEmpty.SetActive(false);
        VolumeFourEmpty.SetActive(true);
        VolumeFiveEmpty.SetActive(true);
        VolumeSixEmpty.SetActive(true);
    }

    public void VolumeFourPressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(true);
        VolumeThreeFull.SetActive(true);
        VolumeFourFull.SetActive(true);
        VolumeFiveFull.SetActive(false);
        VolumeSixFull.SetActive(false);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(false);
        VolumeThreeEmpty.SetActive(false);
        VolumeFourEmpty.SetActive(false);
        VolumeFiveEmpty.SetActive(true);
        VolumeSixEmpty.SetActive(true);
    }

    public void VolumeFivePressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(true);
        VolumeThreeFull.SetActive(true);
        VolumeFourFull.SetActive(true);
        VolumeFiveFull.SetActive(true);
        VolumeSixFull.SetActive(false);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(false);
        VolumeThreeEmpty.SetActive(false);
        VolumeFourEmpty.SetActive(false);
        VolumeFiveEmpty.SetActive(false);
        VolumeSixEmpty.SetActive(true);
    }

    public void VolumeSixPressed()
    {
        VolumeOneFull.SetActive(true);
        VolumeTwoFull.SetActive(true);
        VolumeThreeFull.SetActive(true);
        VolumeFourFull.SetActive(true);
        VolumeFiveFull.SetActive(true);
        VolumeSixFull.SetActive(true);
        VolumeOneEmpty.SetActive(false);
        VolumeTwoEmpty.SetActive(false);
        VolumeThreeEmpty.SetActive(false);
        VolumeFourEmpty.SetActive(false);
        VolumeFiveEmpty.SetActive(false);
        VolumeSixEmpty.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
