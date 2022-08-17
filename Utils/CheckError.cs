using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CheckError /*: MonoBehaviour*/
{


    public static bool CheckIsNull(Object obj, string objName, Object context, [Optional] string optMessage)
    {
        if (obj==null)
        {
            Debug.LogError($"Obj {objName} is null in class {context.GetType()} {optMessage}", context);
            return true;
        }

        return false;
    }

    public static bool CheckIsNull(System.Object obj, string objName, Object context, [Optional] string optMessage)
    {
        if (obj == null)
        {
            Debug.LogError($"System obj: {objName} is null in class {context.GetType()} {optMessage}", context);
            return true;
        }

        return false;
    }

    public static bool CheckOutOfRange(float value, string valueName, float minInclusive, float maxInclusive, Object context, [Optional] string optMessage)
    {
        if (value < minInclusive || value > maxInclusive)
        {
            Debug.LogError($"value {valueName} in class {context.GetType()} out of range, values accepted between {minInclusive} and {maxInclusive} {optMessage}", context);
            return true;
        }

        return false;
    }
}
