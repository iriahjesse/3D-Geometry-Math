using UnityEngine;
using System;


namespace XRC.Assignments.Geometry
{
    public class MyMatrix
    {
        private float[] m_Values;
        private int m_Rows;
        private int m_Cols;

        public enum RotationType
        {
            Pitch,
            Yaw,
            Roll
        }

        public MyMatrix(int r, int c)
        {
            m_Rows = r;
            m_Cols = c;
            m_Values = new float[m_Rows * m_Cols];
        }


        /// <summary>
        /// Get the value at row r (start from zero), column c (start from zero)
        /// </summary>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <returns></returns>
        public float GetValue(int r, int c)
        {
            float value = m_Values[r * m_Cols + c];
            return value;
        }

        public void SetValues(float[] v)
        {
            Array.Copy(v, m_Values, m_Rows * m_Cols);
        }

        public float[] GetValues()
        {
            return m_Values;
        }

        /// <summary>
        /// CalculateMatrix multiplication
        /// </summary>
        /// <param name="a">CalculateMatrix A</param>
        /// <param name="b">CalculateMatrix B</param>
        /// <returns></returns>
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.m_Cols != b.m_Rows)
                return null;

            MyMatrix result = new MyMatrix(a.m_Rows, b.m_Cols);
            float[] resultValues = new float[a.m_Rows * b.m_Cols];
            
            // <solution>
            // Your code here
            
            // For each row
            for (int i = 0; i < a.m_Rows; i++)
            {
                // For each column
                for (int j = 0; j < b.m_Cols; j++)
                {
                    float sum = 0f;
                    
                    // Dot product
                    for (int k = 0; k < a.m_Cols; k++)
                    {
                        float aVal = a.GetValue(i, k); // Row i, col k
                        float bVal = b.GetValue(k, j); // Row k, col j
                        sum += aVal * bVal;
                    }
                    resultValues[i * result.m_Cols + j] = sum;
                }
            }
            // </solution>
            
            result.SetValues(resultValues);
            return result;
        }

        /// <summary>
        /// This helper function should return the standard yaw, pitch, or roll matrix (3x3) 
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MyMatrix GetRotationMatrix(float angle, RotationType type)
        {
            MyMatrix result = new MyMatrix(3, 3);
            float[] resultValues = new float[9];
            
            // <solution>
            // Your code here
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            switch (type)
            {
                case RotationType.Roll: // Z-axis
                    resultValues = new float[]
                    {
                        cos, -sin, 0f,
                        sin,  cos, 0f,
                        0f,   0f,  1f
                    };
                    break;
                case RotationType.Pitch: // X-axis
                    resultValues = new float[]
                    {
                        1f, 0f,   0f,
                        0f, cos, -sin,
                        0f, sin,  cos
                    };
                    break;
                case RotationType.Yaw: // Y-axis
                    resultValues = new float[]
                    {
                        cos, 0f, sin,
                        0f,  1f, 0f,
                        -sin, 0f, cos
                        
                    };
                    break;
            }
            // </solution>

            result.SetValues(resultValues);
            return result;
        }
    }
}