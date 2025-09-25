using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRC.Assignments.Geometry
{ 
    public class FloorColor : MonoBehaviour
    {
        [SerializeField]
        private Transform m_Target;
        private const float k_DistanceThreshold = 5.0f;
        private Renderer m_Renderer;

        void Start()
        {
            m_Renderer = GetComponent<Renderer>();
        }

        void Update()
        {
            Color color = CalculateColor(transform.position, m_Target.position, m_Target.forward, k_DistanceThreshold);
            m_Renderer.material.SetColor("_Color", color);
        }

        public static Color CalculateColor(Vector3 position, Vector3 targetPosition, Vector3 targetForward, float distanceThreshold = k_DistanceThreshold)
        {
            Color color = new Color(0.5f, 0.5f, 0.5f);
            
            // TODO - Modify the color value according to instructions
            // <solution>
            // Your code here
            // Radial color effect:
            float d = Vector3.Distance(position, targetPosition);
            float alpha = Mathf.Max((distanceThreshold - d) / distanceThreshold, 0f);
            color = new Color(1f - alpha, 0f, alpha); // Red to blue
            
            // Directional color effect:
            Vector3 v = targetPosition - position;
            v.y = 0; // Flatten onto X-Z plane
            v.Normalize(); // Make directional
            
            Vector3 f = targetForward;
            f.y = 0;
            f.Normalize();
            
            float dot = Vector3.Dot(v, f);
            if (dot < -0.7f) {
                color.g = 1f; // Make tile yellow
            }
            // </solution>

            return color;
        }
    }
}