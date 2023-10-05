using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AFootball.Core.Helpers
{
    public static class InterceptCalculator
    {
        public static Vector3 CalculateInterceptionPoint(Vector3 PC, float SC, Vector3 PR, Vector3 VR)
        {
            float m_timeToInterception = 0;

            Vector3 D = PC - PR;
            float d = D.magnitude;
            float SR = VR.magnitude;

            if (SR < .0001f)
                return PR;

            float a = Mathf.Pow(SC, 2) - Mathf.Pow(SR, 2);
            float b = 2 * Vector3.Dot(D, VR);
            float c = -Vector3.Dot(D, D);
            
            var tmp = Mathf.Pow(b, 2) - (4 * (a * c));

            if (tmp < 0)
                return PR;

            var tmprt = Mathf.Sqrt(tmp);
            
            float t1 = (-(b) - tmprt) / (2 * a);
            float t2 = (-(b) + tmprt) / (2 * a);

            if (t1 < 0 && t2 < 0)
                return PR;
            
            m_timeToInterception = Math.Min( t1, t2 );
                
            if(m_timeToInterception<0) m_timeToInterception = t2;

            return ((m_timeToInterception * VR) + PR);
        }
    }
}