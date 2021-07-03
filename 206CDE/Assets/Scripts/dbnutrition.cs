using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dbnutrition : MonoBehaviour
{
    public Text itemname;
    public Text energy;
    public Text fat;
    public Text saturates;
    public Text carbohydrates;
    public Text sugar;
    public Text protein;
    public Text salt;
    public Text TESTER;
    public static string imagename = nutrition.storedimage;
    public string[] info;

    public void parseinfo()
    {
        if (nutrition.storedimage == "VanillaFrosting")
        {
                StartCoroutine(iteminfo());
        }
        else
        {
               itemname.text = "Error";
        }
            /*StartCoroutine(energyinfo());
            StartCoroutine(fatinfo());
            StartCoroutine(saturdatesinfo());
            StartCoroutine(carbsinfo());
            StartCoroutine(sugarinfo());
            StartCoroutine(proteininfo());
            StartCoroutine(saltinfo());*/
        
    }

    IEnumerator iteminfo()
    {
        
       
            WWW www = new WWW("http://s875758124.websitehome.co.uk/php/itemname.php");
            yield return www;
            string infolist = www.text;
            print(infolist);
            info = infolist.Split('|');
            itemname.text = info[0];
            energy.text = info[1];
            fat.text = info[2];
            saturates.text = info[3];
            carbohydrates.text = info[4];
            sugar.text = info[5];
            protein.text = info[6];
            salt.text = info[7];
            for (int i = 0; i < info.Length; i++)
            {
                Debug.Log(info[i]);
            }
        
    }




}