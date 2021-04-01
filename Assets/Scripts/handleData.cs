using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleData: MonoBehaviour
{
    public TextAsset jsonFile;

    public FrameList myFrameList = new FrameList();

    // acts like start - initialize the class
    public void Init()
    {
      myFrameList = JsonUtility.FromJson<FrameList>(jsonFile.text);
      //Debug.Log(myFrameList);
    }

}
