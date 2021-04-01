using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBones : MonoBehaviour
{
    public Transform rootBone;
    public GameObject circle;
    //public GameObject dataHandler;

    public Transform thumb, index, middle, ring, pinky;
    public Dictionary<int, Transform> jMap = new Dictionary<int, Transform>();
    public Dictionary<int, GameObject> cMap = new Dictionary<int, GameObject>();

    public void Init() {
      thumb = rootBone.GetChild(0);
      index = rootBone.GetChild(1);
      middle = rootBone.GetChild(2);
      ring = rootBone.GetChild(3);
      pinky = rootBone.GetChild(4);

      jMap.Add(0, rootBone);
      jMap.Add(1, thumb);
      jMap.Add(2, thumb.GetChild(0));
      jMap.Add(3, thumb.GetChild(0).GetChild(0));
      jMap.Add(4,thumb.GetChild(0).GetChild(0).GetChild(0));
      jMap.Add(5, index);
      jMap.Add(6, index.GetChild(0));
      jMap.Add(7, index.GetChild(0).GetChild(0));
      jMap.Add(8, index.GetChild(0).GetChild(0).GetChild(0));
      jMap.Add(9, middle);
      jMap.Add(10, middle.GetChild(0));
      jMap.Add(11, middle.GetChild(0).GetChild(0));
      jMap.Add(12, middle.GetChild(0).GetChild(0).GetChild(0));
      jMap.Add(13, ring);
      jMap.Add(14, ring.GetChild(0));
      jMap.Add(15, ring.GetChild(0).GetChild(0));
      jMap.Add(16, ring.GetChild(0).GetChild(0).GetChild(0));
      jMap.Add(17, pinky);
      jMap.Add(18, pinky.GetChild(0));
      jMap.Add(19, pinky.GetChild(0).GetChild(0));
      jMap.Add(20, pinky.GetChild(0).GetChild(0).GetChild(0));
    }

    public void moveThumb()
    {
      Vector3 p = thumb.position;
      //p.x = p.x + .01f;
      thumb.position = p;
    }

    public void moveHand(JointObj[] input)
    {
      jointToBone(input[0], rootBone);
      jointToBone(input[1], thumb);
      jointToBone(input[5], index);
      jointToBone(input[9], middle);
      jointToBone(input[13], ring);
      jointToBone(input[17], pinky);


    }

    public void generateCircles()
    {
      for (int i = 0; i < 21; i++)
      {
      circle = Instantiate(circle, new Vector3(0,0,0), Quaternion.identity);
      cMap.Add(i, circle);
      }
    }

    public void setCircle(int jointNum, Vector3 position)
    {
      cMap[jointNum].transform.position = position;
    }

    public void frameToCircle(Frame frameObj)
    {
      //JointObj[] hand1 = frameObj.hand1.Length > 0 ? frameObj.hand1 : null;
      //JointObj[] hand2 = frameObj.hand2.Length > 0 ? frameObj.hand2 : null;
      if (frameObj.hand1 != null) {
        if (frameObj.hand1.Length > 0)
        {
          for (int i = 0; i < 21; i++)
          {
            JointObj joint = frameObj.hand1[i];
            Vector3 position = new Vector3((float) joint.x,(float) joint.y,(float) joint.rel_depth);
            setCircle(i, position);
          }
        }
      }


    }

    public void jointToBone(JointObj joint, Transform bone)
    {
      //float scale = 10f;
      //Vector3 jointLoc = new Vector3((float)joint.x/scale, (float)joint.y/scale, (float)joint.rel_depth/scale);
      //Debug.Log(joint.x.ToString() + "  " + joint.y.ToString() + "  " + joint.rel_depth.ToString());
      /*float test = (float)9.196997E-05;
      int rounded = (int)Math.Round(test, 0);
      Debug.Log(rounded);*/
      //bone.position = jointLoc;
    }

    public double getScaleFactor(JointObj root, JointObj firstIndex)
    {
      //scaling factor s : distance between root (palm) and first joint in index
      return Math.Sqrt(Math.Pow(firstIndex.x - root.x, 2) + Math.Pow(firstIndex.y - root.y, 2) + Math.Pow(firstIndex.rel_depth - root.rel_depth, 2) );
    }

    public void convert25to3D(JointObj child, JointObj parent)
    {
      // scale normalize z value
      //double vecLen = Math.Sqrt(Math.Pow())

      //double s = getScaleFactor();

      Transform firstIndex = this.jMap[5];
      Transform root = this.jMap[0];
    }
}
