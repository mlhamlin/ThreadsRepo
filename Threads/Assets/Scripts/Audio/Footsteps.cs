using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

    public AudioSource StepSource;
    public AudioClip[] DirtSteps;
    public AudioClip[] GrassSteps;
    public AudioClip[] WoodSteps;

    public enum Surface
    {
        Dirt, Grass, Wood
    }

    public Surface currentSurface;
    public float timeBetweenSteps;
    private float timeSinceLast = 0f;

    private int lastPlayed = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopWalking()
    {
        StepSource.Stop();
    }

    public void Walking(float deltaTime)
    {
        timeSinceLast += deltaTime;

        if (timeSinceLast < timeBetweenSteps)
        {
            return;
        }

        walkSoundNow();
    }

    private void walkSoundNow()
    {
        switch(currentSurface)
        {
            case Surface.Dirt:
                playRandom(DirtSteps);
                return;
            case Surface.Wood:
                playRandom(WoodSteps);
                return;
            case Surface.Grass:
                playRandom(GrassSteps);
                return;
        }
    }

    private void playRandom(AudioClip[] clips)
    {
        if(clips.Length == 0)
            return;

        int index = Random.Range(0, clips.Length);
        if (index == lastPlayed)
        {
            index = (index + 1) % clips.Length;
        }
        lastPlayed = index;
        StepSource.PlayOneShot(clips[index]);
        timeSinceLast = 0f;
    }
}
