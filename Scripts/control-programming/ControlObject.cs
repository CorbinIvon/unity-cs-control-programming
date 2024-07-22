using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ControlObject : MonoBehaviour
{
    public virtual Dictionary<string, object> GetPublicAttributes()
    {
        Dictionary<string, object> attributes = new Dictionary<string, object>();

        Type type = GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            attributes.Add(field.Name, field.GetValue(this));
        }

        return attributes;
    }

    public virtual void SetPublicAttribute(string attributeName, object value)
    {
        Type type = GetType();
        FieldInfo field = type.GetField(attributeName, BindingFlags.Public | BindingFlags.Instance);

        if (field != null)
        {
            field.SetValue(this, Convert.ChangeType(value, field.FieldType));
        }
    }
}
