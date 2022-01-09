using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToOne : GAction 
{
    public override bool PrePerform() 
    {
        var doctorScript = GetComponent<GoToDoctor>();

        if (doctorScript.infected)
        {
            int number = Random.Range(1, 4);
            if (number == 1)
                targetTag = "One";
            else if (number == 2)
                targetTag = "Two";
            else if (number == 3)
                targetTag = "Three";
        }
        else
        {
            targetTag = "Home";
            mask.SetActive(false);
        }

        return true;
    }

    public override bool PostPerform() 
    {
        var doctorScript = GetComponent<GoToDoctor>();

        if (doctorScript.infected)
        {
            GWorld.Instance.GetWorld().ModifyState("Waiting", 1);
            GWorld.Instance.AddPatient(this.gameObject);
            beliefs.ModifyState("atHospital", 1);
        }
        else
        {
            Destroy(this.gameObject);
        }

        return true;
    }
}
