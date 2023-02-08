using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
   public static Action OnCardValuesReset;

   public static void OnCardValueResetInvoke()
   {
      OnCardValuesReset?.Invoke();
   }
}
