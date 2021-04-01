using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJson;

    [System.Serializable]
    public class Player
    {
      public string name;
      public int health;
      public int mana;
    }

    [System.Serializable]
    public class PlayerList
    {
      public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    void Start()
    {
      myPlayerList = JsonUtility.FromJson<PlayerList>(textJson.text);
    }

    void Update()
    {

    }
}
