using System.Collections.Generic;
using UnityEngine;

public class ProgrammableController : MonoBehaviour
{
    public List<string> scriptLines = new List<string>();
    public bool run = false;

    public void StartExecution()
    {
        if (run)
        {
            ProgrammableControllerManager.Instance.ExecuteController(this);
        }
    }

    public void SetControllerState(bool state)
    {
        run = state;
    }
}
