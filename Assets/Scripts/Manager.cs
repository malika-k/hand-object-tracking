using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject handleData;
    public GameObject moveBones;
    public Text frameText;
    public int numFrames;
    public int frame;
    public float interval;
    public FrameList frameInfo;
    public Slider frameSlider;

    public Frame currentFrameObj;

    // Start is called before the first frame update
    void Start()
    {
      handleData.GetComponent<handleData>().Init();
      moveBones.GetComponent<MoveBones>().Init();

      numFrames = handleData.GetComponent<handleData>().myFrameList.frames.Length;
      frameInfo = handleData.GetComponent<handleData>().myFrameList;
      frame = 0;

      frameSlider.minValue = 0;
      frameSlider.maxValue = numFrames - 1;
      frameSlider.wholeNumbers = true;

      moveBones.GetComponent<MoveBones>().generateCircles();
    }

    // Update is called once per frame
    void Update()
    {
      moveBones.GetComponent<MoveBones>().moveThumb();

      frame = (int) frameSlider.value ;
      frameText.text = "Frame " + frame.ToString();

      moveBones.GetComponent<MoveBones>().frameToCircle(frameInfo.frames[frame]);
      currentFrameObj = frameInfo.frames[frame];
      //moveBones.GetComponent<MoveBones>().generateCircle();
      //JointObj[] hand1 = handleData.GetComponent<handleData>().myFrameList.frames[frame].hand1;


      /*
      if (hand1 != null)
      {
        moveBones.GetComponent<MoveBones>().moveHand(hand1);
      }
      Debug.Log(moveBones.GetComponent<MoveBones>().thumb.position);
      */

    }
}
