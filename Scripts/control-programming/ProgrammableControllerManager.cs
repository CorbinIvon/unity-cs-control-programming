using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammableControllerManager : MonoBehaviour
{
    public static ProgrammableControllerManager Instance;
    public float executionRate = 0.2f; // Lines per second

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ExecuteController(ProgrammableController controller)
    {
        if (controller.run)
        {
            StartCoroutine(ExecuteScript(controller));
        }
    }

    private IEnumerator ExecuteScript(ProgrammableController controller)
    {
        foreach (string line in controller.scriptLines)
        {
            ExecuteLine(line);
            yield return new WaitForSeconds(1 / executionRate);
        }
    }

    private void ExecuteLine(string line)
    {
        string[] parts = line.Split('=');
        if (parts.Length == 2)
        {
            string objectName = parts[0].Trim();
            string value = parts[1].Trim();

            GameObject obj = GameObject.Find(objectName);
            if (obj != null)
            {
                ControlObject controlObject = obj.GetComponent<ControlObject>();
                if (controlObject != null)
                {
                    controlObject.SetPublicAttribute("thrust", float.Parse(value));
                }
            }
        }
    }
}
