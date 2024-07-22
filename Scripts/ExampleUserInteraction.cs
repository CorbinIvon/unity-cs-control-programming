using UnityEngine;

public class ExampleUserInteraction : MonoBehaviour
{
    public void InspectControlObject(ControlObject controlObject)
    {
        var attributes = controlObject.GetPublicAttributes();
        foreach (var attribute in attributes)
        {
            Debug.Log($"{attribute.Key} = {attribute.Value}");
        }
    }

    public void ModifyControlObject(ControlObject controlObject, string attributeName, object value)
    {
        controlObject.SetPublicAttribute(attributeName, value);
        Debug.Log($"Set {attributeName} to {value}");
    }

    private void OnTriggerEnter(Collider other)
    {
        ControlObject controlObject = other.GetComponent<ControlObject>();
        if (controlObject != null)
        {
            InspectControlObject(controlObject);
            ModifyControlObject(controlObject, "thrust", 75f); // Example modification
        }
    }
}
