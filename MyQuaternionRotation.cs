using UnityEngine;

namespace XRC.Assignments.Geometry
{
    public class MyQuaternionRotation : MonoBehaviour
    {
        // Note: You are only allowed to use MyQuaternion class, not Unity's Quaternion class

        [SerializeField]
        private AngleGenerator m_AngleGenerator;

        // Vertices
        private MeshFilter m_MeshFilter;
        private Vector3[] m_OriginalVertices;
        private Vector3[] m_TransformedVertices;


        private void Start()
        {
            m_MeshFilter = GetComponent<MeshFilter>();
            m_OriginalVertices = m_MeshFilter.mesh.vertices;
            m_TransformedVertices = new Vector3[m_OriginalVertices.Length];
        }

        void Update()
        {
            // Get the angle to be used
            float radAngle = Mathf.Deg2Rad * m_AngleGenerator.angle;

            // Calculate the quaternion and transform the vertices
            MyQuaternion myQuaternion = CalculateQuaternion(radAngle);
            m_TransformedVertices = TransformVertices(m_OriginalVertices, myQuaternion);

            // Update the mesh with transformed vertices
            m_MeshFilter.mesh.vertices = m_TransformedVertices;
        }


        private Vector3[] TransformVertices(Vector3[] originalVertices, MyQuaternion myQuaternion)
        {
            MyQuaternion myQuaternionPoint = new MyQuaternion();

           
            // <solution>
            // Your code here
            Vector3[] transformedVertices = new Vector3[originalVertices.Length];
            MyQuaternion inverseQuaternion = MyQuaternion.Inverse(myQuaternion);

            for (int i = 0; i < originalVertices.Length; i++)
            {
                Vector3 v = originalVertices[i];

                // Create quaternion for the point
                myQuaternionPoint.a = 0;
                myQuaternionPoint.b = v.x;
                myQuaternionPoint.c = v.y;
                myQuaternionPoint.d = v.z;

                // Apply rotation
                MyQuaternion rotatedP = myQuaternion * myQuaternionPoint * inverseQuaternion;
                
                transformedVertices[i] = new Vector3(rotatedP.b, rotatedP.c, rotatedP.d);
            }
            // </solution>

            return transformedVertices;
        }

        private MyQuaternion CalculateQuaternion(float angle)
        {
            MyQuaternion myQuaternionYaw = new MyQuaternion();
            MyQuaternion myQuaternionRoll = new MyQuaternion();
            MyQuaternion myQuaternionPitch = new MyQuaternion();

            MyQuaternion myResultQuaternion = new MyQuaternion();
            
            // Order of rotation (to match Unity's Quaternion.Euler): first roll, then pitch, and finally yaw.
            // <solution>
            // Your code here
            
            myQuaternionRoll.AngleAxis(angle, new Vector3(0, 0, 1)); // Roll (Z axis)
            myQuaternionPitch.AngleAxis(angle, new Vector3(1, 0, 0)); // Pitch (X axis
            myQuaternionYaw.AngleAxis(angle, new Vector3(0, 1, 0)); // Yaw (Y axis
     
            // Order: roll * pitch * yaw
            myResultQuaternion = myQuaternionYaw * myQuaternionPitch * myQuaternionRoll;

            // </solution>

            return myResultQuaternion;
        }
    }
}