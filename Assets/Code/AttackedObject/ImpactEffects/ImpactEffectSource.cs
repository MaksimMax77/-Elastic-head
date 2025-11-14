using System;
 using UnityEngine;

 namespace Code.AttackedObject.ImpactEffects
 {
     public class ImpactEffectSource : MonoBehaviour
     {
         public event Action<Vector3> OnImpact;

         public void ImpactInvoke(Vector3 point)
         {
             OnImpact?.Invoke(point);
         }
     }
 }