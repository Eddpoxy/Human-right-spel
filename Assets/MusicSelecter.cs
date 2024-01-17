using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelecter : MonoBehaviour
{
    public AudioSource Track1;

    public AudioSource Track2;

    public int TrackSelecter;

    public int TrackHistory;



    // Start is called before the first frame update
    void Start()
    {
        TrackSelecter = Random.Range(0, 2);

        if (TrackSelecter == 0 && TrackHistory != 1)
        {
            Track1.Play();
            TrackHistory = 1;
        }
        else if (TrackHistory == 1 && TrackHistory != 2)
        {
            Track2.Play();
            TrackHistory = 2;
        }

    }

    // Update is called once per frame
    void Update()

    {
        if (Track1.isPlaying == false && Track2.isPlaying == false)
        {
            TrackSelecter = Random.Range(0, 2);

            if (TrackSelecter == 0 && TrackHistory != 1)
            {
                Track1.Play();
                TrackHistory = 1;
            }
            else if (TrackHistory == 1 && TrackHistory != 2)
            {
                Track2.Play();
                TrackHistory = 2;
            }

        }
    }
}



