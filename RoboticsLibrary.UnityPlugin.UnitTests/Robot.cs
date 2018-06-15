using System;
using System.Collections.Generic;
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

    public enum Unit
    {
        Radians = 0,
        Degrees = 1
    }

    public static class MathExtension
    {
        public static double DegreesToRadians(this double d)
        {
            return d * Math.PI / 180d;
        }

        public static double RadiansToDegrees(this double d)
        {
            return d / Math.PI * 180d;
        }

        public static T DegreesToRadians<T>(this T data) where T : IList<double>
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i].DegreesToRadians();
            }

            return data;
        }

        public static T RadiansToDegrees<T>(this T data) where T : IList<double>
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i].RadiansToDegrees();
            }

            return data;
        }
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

        public double[] GetPosition(Unit unit = Unit.Radians)
        {
            double[] data = new double[Dof];
            Robot_GetPosition(m_id, data);

            switch (unit)
            {
                case Unit.Radians:
                    return data;

                case Unit.Degrees:
                    return data.RadiansToDegrees();

                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public void SetPosition(double[] data, Unit unit = Unit.Radians)
        {
            if (data == null || data.Length != Dof)
                throw new ArgumentException();

            switch (unit)
            {
                case Unit.Radians:
                    Robot_SetPosition(m_id, data);
                    break;

                case Unit.Degrees:
                    Robot_SetPosition(m_id, data.DegreesToRadians());
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public double[] GetAcceleration(Unit unit = Unit.Radians)
        {
            double[] data = new double[Dof];
            Robot_GetAcceleration(m_id, data);
            switch (unit)
            {
                case Unit.Radians:
                    return data;

                case Unit.Degrees:
                    return data.RadiansToDegrees();

                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public void SetAcceleration(double[] data, Unit unit = Unit.Radians)
        {
            if (data == null || data.Length != Dof)
                throw new ArgumentException();

            switch (unit)
            {
                case Unit.Radians:
                    Robot_SetAcceleration(m_id, data);
                    break;

                case Unit.Degrees:
                    Robot_SetAcceleration(m_id, data.DegreesToRadians());
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public void SetGoal(long tcpId, Transform transform)
        {
            if (tcpId < 0)
                throw new ArgumentOutOfRangeException(nameof(tcpId));

            Robot_SetGoal(m_id, tcpId, ref transform);
        }

        public bool SolveIk()
        {
            return Robot_SolveIk(m_id);
        }

        // Native API - DllImport

        #region DllImport

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
        private static extern void Robot_GetAcceleration(long id, double[] data);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void Robot_SetAcceleration(long id, double[] data);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void Robot_SetGoal(long id, long tcpId, ref Transform transform);

        [DllImport("RoboticsLibrary.UnityPlugin.dll",
            CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern bool Robot_SolveIk(long id);

        #endregion DllImport
    }
}