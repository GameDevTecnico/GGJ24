using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCreator : MonoBehaviour
{
    public int head = -1;
    public int leg = -1;
    public int torso = -1;
    [SerializeField] private List<Sprite> HeadParts = new List<Sprite>();
    [SerializeField] private GameObject headGameObject;
    [SerializeField] private List<Sprite> LegParts = new List<Sprite>();
    [SerializeField] private GameObject legGameObject;
    [SerializeField] private List<Sprite> TorsoParts = new List<Sprite>();
    [SerializeField] private GameObject torsoGameObject;


    void Update()
    {
        if (head >= 0)  
        {
            headGameObject.GetComponent<SpriteRenderer>().sprite = HeadParts[head];
        }
        if (leg >= 0)
        {
            legGameObject.GetComponent<SpriteRenderer>().sprite = LegParts[head];
        }
        if (torso >= 0)
        {
            torsoGameObject.GetComponent<SpriteRenderer>().sprite = TorsoParts[head];
        }
    }

    public void setLegs(int x){
        leg = x;
    }
    public void setHead(int x){
        head = x;
    }
    public void setTorso(int x){
        torso = x;
    }

}
