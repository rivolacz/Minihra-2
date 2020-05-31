using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DressPicker : MonoBehaviour
{
    [Serializable]
    public class Dress
    {
        public Sprite Base;
        public Sprite Hair;
        public Sprite Bottom;
        public Sprite Top;
    }
    [SerializeField]
    List<Sprite> bases;
    [SerializeField]
    List<Sprite> tops;
    [SerializeField]
    List<Sprite> bottoms;
    [SerializeField]
    List<Sprite> hairs;

    [SerializeField]
    List<Dress> correctCombinations;
    [SerializeField]
    Dress currentDress;

    [SerializeField]
    Image baseImage;
    [SerializeField]
    Image topsImage;
    [SerializeField]
    Image bottomImage;
    [SerializeField]
    Image hairImage;

    [SerializeField]
    TMP_Text correctText;
    [SerializeField]
    TMP_Text incorrectText;

    int hairIndex = 0;
    int bottomIndex = 0;
    int topIndex = 0;

    private void Start()
    {
        //Pick default
        SwitchBase(0);
        SwitchHair(0);
        SwitchTop(0);
        SwitchBottom(0);
    }

    public void SwitchHair(int value)
    {
        hairIndex += value;
        if(hairIndex < 0)
        {
            hairIndex = hairs.Count - 1;
        }
        if(hairIndex > hairs.Count - 1)
        {
            hairIndex = 0;
        }
        currentDress.Hair = hairs[hairIndex];
        hairImage.sprite = currentDress.Hair;
        ValidateDress();
    }

    public void SwitchBase(int value)
    {
        if(value >= bases.Count)
        {
            value = bases.Count - 1;
        }
        if(value < 0)
        {
            value = 0;
        }
        currentDress.Base = bases[value];
        baseImage.sprite = currentDress.Base;
        ValidateDress();
    }

    public void SwitchTop(int value)
    {
        topIndex += value;
        if (topIndex < 0)
        {
            topIndex = tops.Count - 1;
        }
        if (topIndex > tops.Count - 1)
        {
            topIndex = 0;
        }
        currentDress.Top = tops[topIndex];
        topsImage.sprite = currentDress.Top;
        ValidateDress();
    }

    public void SwitchBottom(int value)
    {
        bottomIndex += value;
        if (bottomIndex < 0)
        {
            bottomIndex = bottoms.Count - 1;
        }
        if (bottomIndex > bottoms.Count - 1)
        {
            bottomIndex = 0;
        }
        currentDress.Bottom = bottoms[bottomIndex];
        bottomImage.sprite = currentDress.Bottom;
        ValidateDress();
    }


    void ValidateDress()
    {
        bool result = CheckDresses();
        if (result)
        {
            correctText.enabled = true;
            incorrectText.enabled = false;
        }
        else
        {
            correctText.enabled = false;
            incorrectText.enabled = true;
        }
    }

    bool CheckDresses()
    {   
        foreach (Dress dress in correctCombinations)
        {
            bool correct;
            if (dress == null)
            {
                Debug.Log("Missing dress");
                continue;
            }
            correct = true;
            if (currentDress.Base != dress.Base) correct = false;
            if (currentDress.Hair != dress.Hair) correct = false;
            if (currentDress.Top != dress.Top) correct = false;
            if (currentDress.Bottom != dress.Bottom) correct = false;

            if (correct)
            {
                return true;
            }
        }
        return false;
    }
}
