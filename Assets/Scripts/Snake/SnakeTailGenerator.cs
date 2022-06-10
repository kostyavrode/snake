using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTailGenerator : MonoBehaviour
{
    [SerializeField] public TailPart tailPart;
    public List<TailPart> Generate(int tailSize)
    {
        List <TailPart> tail= new List<TailPart>();
        for(int i=0;i<tailSize;i++)
        {
            tail.Add(Instantiate(tailPart,this.transform));
        }
        return tail;
    }
}
