using UnityEngine;

public class ThrusterControlObject : ControlObject
{
    public float thrust = 0;
    public string thrusterName = "DefaultThruster";

    public void SetThrust(float value)
    {
        thrust = value;
        Debug.Log($"{thrusterName} thrust set to {thrust}%");
    }
}
