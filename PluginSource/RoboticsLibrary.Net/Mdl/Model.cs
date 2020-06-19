using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RoboticsLibrary.Net.Mdl
{
    public class Model : IDisposable
    {
        private IntPtr m_ptr;

        public Model()
        {
            m_ptr = Native.RL_MDL_Model_New();
            if (m_ptr == IntPtr.Zero)
            {
                throw new Exception();
            }
        }

        public Model(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException();

            if (!File.Exists(path))
                throw new FileNotFoundException();

            m_ptr = Native.RL_MDL_XmlFactory_Create(path);
            if (m_ptr == IntPtr.Zero)
            {
                throw new Exception();
            }
        }

        ~Model()
        {
            ReleaseUnmanagedResources();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        private void ReleaseUnmanagedResources()
        {
            if (m_ptr == IntPtr.Zero)
                return;

            Native.RL_MDL_Model_Delete(m_ptr);
            m_ptr = IntPtr.Zero;
        }

        public double[] GetAcceleration()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetAcceleration(m_ptr, result);
            return result;
        }

        public UInt64 GetDof()
        {
            return Native.RL_MDL_Model_GetDof(m_ptr);
        }

        public UInt64 GetDofPosition()
        {
            return Native.RL_MDL_Model_GetDofPosition(m_ptr);
        }

        public double[] GetPosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetPosition(m_ptr, result);
            return result;
        }

        public double[] GetHomePosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetHomePosition(m_ptr, result);
            return result;
        }

        public double[] GetMaximum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetMaximum(m_ptr, result);
            return result;
        }

        public double[] GetMinimum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetMinimum(m_ptr, result);
            return result;
        }

        public double[] GetTorque()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetTorque(m_ptr, result);
            return result;
        }

        public double[] GetSpeed()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetSpeed(m_ptr, result);
            return result;
        }

        public double[] GetVelocity()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            Native.RL_MDL_Model_GetVelocity(m_ptr, result);
            return result;
        }

        private static class Native
        {
            private const string DllName = "RoboticsLibrary.Native.dll";

            [DllImport(DllName)]
            internal static extern IntPtr RL_MDL_Model_New();

            [DllImport(DllName, CharSet = CharSet.Ansi)]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "Globalization", "CA2101", Justification = "By design")]
            internal static extern IntPtr RL_MDL_XmlFactory_Create(
                [MarshalAs(UnmanagedType.LPStr)] string path);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_Delete(IntPtr ptr);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetAcceleration(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern UInt64 RL_MDL_Model_GetDof(IntPtr ptr);

            [DllImport(DllName)]
            internal static extern UInt64 RL_MDL_Model_GetDofPosition(IntPtr ptr);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetPosition(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetHomePosition(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetMaximum(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetMinimum(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetTorque(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetSpeed(IntPtr ptr, double[] vector);

            [DllImport(DllName)]
            internal static extern void RL_MDL_Model_GetVelocity(IntPtr ptr, double[] vector);
        }
    }
}