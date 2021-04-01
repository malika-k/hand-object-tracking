using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject handleData;
    public GameObject moveBones;
    public Slider frameSlider;
    public Text frameText;
    public Text timeText;

    public int frameRate;

    public Frame currentFrameObj;
    public FrameList frameInfo;

    private int numFrames;
    private int frame;
    private float timer;
    private int currentFrame;

    // Start is called before the first frame update
    void Start()
    {
      if (frameRate==0)
      {
        frameRate = 30;
      }

      handleData.GetComponent<handleData>().Init();
      moveBones.GetComponent<MoveBones>().Init();

      numFrames = handleData.GetComponent<handleData>().myFrameList.frames.Length;
      frameInfo = handleData.GetComponent<handleData>().myFrameList;
      frame = 0;
      timer = 0;
      currentFrame = 0;

      frameSlider.minValue = 0;
      frameSlider.maxValue = numFrames - 1;
      frameSlider.wholeNumbers = true;
      moveBones.GetComponent<MoveBones>().generateCircles();
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      timeText.text = "Time: " + timer.ToString();

      moveBones.GetComponent<MoveBones>().moveThumb();

      if (currentFrame < numFrames - 1)
      {
          frame = (int) (timer * frameRate); //frameSlider.value;
      }

      if (currentFrame != frame){
        frameSlider.value = frame;
        frameText.text = "Frame " + frame.ToString();
        moveBones.GetComponent<MoveBones>().frameToCircle(frameInfo.frames[frame]);
        currentFrameObj = frameInfo.frames[frame];

        currentFrame = frame;
      }


      //moveBones.GetComponent<MoveBones>().generateCircle();
      //JointObj[] hand1 = handleData.GetComponent<handleData>().myFrameList.frames[frame].hand1;
    }
}
