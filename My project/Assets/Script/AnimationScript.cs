using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public float minInbetweenTime;
    public float maxInbetweenTime;
    float TimebeforeAninmation;
    float curTime;
    public float InbetweenTime;
    float curTime2;
    public Animator Topanimator;
    public Animator Lowanimator;
    bool Top;
    bool Hasblinked;

    // Start is called before the first frame update
    void Start()
    {
        RandomizedTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hasblinked == true)
        {
            curTime2 += Time.deltaTime;


            if (curTime2 >= InbetweenTime)
            {
                if (Top)
                {
                    Topanimator.SetTrigger("PlayTop");


                }
                else
                {
                    Lowanimator.SetTrigger("PlayBottom");
                }

                //reset timer
                curTime = 0;
                Hasblinked = false;
                RandomizedTimer();
                Debug.Log(TimebeforeAninmation);

            }
        }
        else
        {
            curTime += Time.deltaTime;


            if (curTime >= TimebeforeAninmation)
            {
                //play animation
                float Determinator = Random.value;
                if (Determinator < 0.5f)
                {
                    Top = true;

                }
                else
                {
                    Top = false;
                }

                //reset timer
                curTime2 = 0;
                Hasblinked = true;


            }

            //Debug.Log(curTime);
        }


    }

    void RandomizedTimer()
    {
        TimebeforeAninmation = Random.Range(minInbetweenTime, maxInbetweenTime);
    }
}
