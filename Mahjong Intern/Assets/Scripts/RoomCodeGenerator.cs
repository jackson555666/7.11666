using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomCodeGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI codeText;

    private void Start()
    {
        CreateRandomCode();
    }

    void CreateRandomCode()
    {
        string everyCharacter = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9";
        string[] splitedString = everyCharacter.Split(",");

        string tempCode = "";

        for(int i = 0;i<5;i++)
        {
            tempCode += splitedString[Random.Range(0, splitedString.Length)];
        }

        codeText.text = "Room code: " + tempCode;
    }
}
