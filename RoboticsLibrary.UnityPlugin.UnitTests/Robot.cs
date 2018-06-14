using System;
using System.Runtime.InteropServices;

namespace RoboticsLibrary.UnityPlugin.UnitTests
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;
        
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Transform
    {
        public Vector3 Translation;
        public Vector3 Rotation;
    }

    public class Robot : IDisposable
    {
        private readonly string m_pathToMdl;
        private long m_id;
        private bool m_isDisposed = false;

        public long Id => m_id;
        public bool IsDisposed => m_isDisposed;

        public Robot(string pathToMdl)
        {
            m_pathToMdl = pathToMdl;
            m_id = CreateRobot(pathToMdl);
            if (m_id <= 0)
                throw new Exception("Creation of a robot fails");
        }

        private void ReleaseUnmanagedResources()
        {
            if (m_isDisposed)
                return;

            DeleteRobot(m_id);
            m_id = 0;
            m_isDisposed = true;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Robot()
        {
            ReleaseUnmanagedResources();
        }

        private long m_dof = 0;

        public long Dof
        {
            get
            {
                if (m_dof == 0)
                    m_dof = Robot_GetDof(m_id);
                return m_dof;
            }
        }

        public double[] GetPosition()
        {
            double[] data = new double[Dof];
            Robot_GetPosition(m_id, data);
            return data;
        }

        public void SetPosition(double[] data)
        {
            if (data == null || data.Length != Dof)
                throw new ArgumentException();
            Robot_SetPosition(m_id, data);
        }

        public void SetGoal(long tcpId, Transform transform)
        {
            if (tcpId < 0)
                throw new ArgumentOutOfRangeException(nameof(tcpId));

            Robot_SetGoal(m_id, tcpId, ref transform);
        }

        public bool SolveIK()
        {
            return Robot_SolveIk(m_id);
        }

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern long CreateRobot([MarshalAs(UnmanagedType.LPStr)] string pathToMdl);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern bool DeleteRobot(long id);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern long Robot_GetDof(long id);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void Robot_GetPosition(long id, double[] data);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void Robot_SetPosition(long id, double[] data);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void Robot_SetGoal(long id, long tcpId, ref Transform transform);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern bool Robot_SolveIk(long id);
    }
}