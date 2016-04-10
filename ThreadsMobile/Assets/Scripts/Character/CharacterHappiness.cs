using UnityEngine;
using System.Collections;
using System;

public class CharacterHappiness : MonoBehaviour {

    public Sprite[] ScaleImages;

    public SpriteRenderer img;

    private int MIN = -20;
    private int MAX = 30;
    private int StepSize;

    private int scaleCount;

    private int scoreVal;
    public int score
    {
        get
        {
            return scoreVal;
        }
        set
        {
            scoreVal = value;
            UpdateImage();
        }
    }

    void Awake ()
    {
        scaleCount = ScaleImages.Length;
        StepSize = (MAX - MIN) / scaleCount;
    }

    private void UpdateImage()
    {
        int index = Mathf.FloorToInt((scoreVal - MIN) / StepSize);
        index = Mathf.Clamp(index, 0, ScaleImages.Length - 1);
        Debug.Log("index " + index);
        img.sprite = ScaleImages[index];
    }
}
